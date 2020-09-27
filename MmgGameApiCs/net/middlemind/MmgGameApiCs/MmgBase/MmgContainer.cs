using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that represents a container of MmgObj objects. 
    /// Created by Middlemind Games 08/29/2016
    /// 
    /// @author Victor G.Brusca
    /// </summary>
    public class MmgContainer : MmgObj
    {
        /// <summary>
        /// The initial size of the collection object.
        /// </summary>
        public static int INITIAL_SIZE = 10;

        /// <summary>
        /// Private enumeration that lists the stamp, un-stamp actions that can be
        /// performed on a child.Stamping marks the child as being associated with the
        /// container.
        /// </summary>
        private enum ChildAction
        {
            STAMP,
            UNSTAMP
        }

        /// <summary>
        /// An enumeration that controls the render mode allowing you to either control the rendering via the isDirty flag or to render every game frame. 
        /// </summary>
        private enum RenderMode
        {
            RENDER_ALWAYS,
            RENDER_ONLY_WHEN_DIRTY
        }

        /// <summary>
        /// A private field that holds the current RenderMode value.
        /// </summary>
        private RenderMode mode = RenderMode.RENDER_ALWAYS;

        /// <summary>
        /// The List that holds the MmgObj objects.
        /// </summary>
        private List<object> container;

        /// <summary>
        /// A class helper variable.
        /// </summary>
        private object[] a;

        /// <summary>
        /// A class helper variable.
        /// </summary>
        private MmgObj mo;

        /// <summary>
        /// A class helper variable.
        /// </summary>
        private int i;

        /// <summary>
        /// A boolean flag that marks this object as dirty and allows the MmgUpdate call to be called on child objects. 
        /// </summary>
        private bool isDirty;

        /// <summary>
        /// A private local variable used in the MmgUpdate method to flag if the update was handled this frame. 
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// 
        /// </summary>
        public MmgContainer() : base()
        {
            SetContainer(new List<object>(INITIAL_SIZE));
            SetIsDirty(true);
        }

        /// <summary>
        /// Constructor that sets the base objects properties equal to the given
        /// arguments properties.
        /// </summary>
        /// <param name="obj">The object to get MmgObj properties from.</param>
        public MmgContainer(MmgObj obj) : base(obj)
        {
            SetContainer(new List<object>(INITIAL_SIZE));
            SetIsDirty(true);
        }

        /// <summary>
        /// Constructor that initializes an ArrayList of objects contained by this container object.
        /// </summary>
        /// <param name="objects">The objects to add to this container.</param>
        public MmgContainer(List<object> objects) : base()
        {
            SetContainer(objects);
            SetIsDirty(true);
        }

        /// <summary>
        /// Constructor that initializes this class based on the attributes of a given argument.
        /// </summary>
        /// <param name="obj">An MmgContainer class to use to set all the attributes of this class.</param>
        public MmgContainer(MmgContainer obj) : base()
        {
            List<MmgObj> tmp1 = obj.GetContainer();
            if (tmp1 != null)
            {
                int len = tmp1.Count;
                List<MmgObj> tmp2 = new List<MmgObj>(len);
                for (int j = 0; j < len; j++)
                {
                    tmp2.Add(tmp1[j].CloneTyped());
                }
                SetContainer(tmp2);
            }
            else
            {
                SetContainer(tmp1);
            }

            if (obj.GetPosition() != null)
            {
                SetPosition(obj.GetPosition().Clone());
            }
            else
            {
                SetPosition(obj.GetPosition());
            }

            SetWidth(obj.GetWidth());
            SetHeight(obj.GetHeight());
            SetIsVisible(obj.GetIsVisible());

            if (obj.GetMmgColor() != null)
            {
                SetMmgColor(obj.GetMmgColor().Clone());
            }
            else
            {
                SetMmgColor(obj.GetMmgColor());
            }
            SetIsDirty(true);
        }

        /*
         * A setter method that sets the isDirty flag.
         * 
         * @param b     The boolean value to set the isDirty flag to.
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        public virtual void SetIsDirty(bool b)
        {
            isDirty = b;
        }

        /// <summary>
        /// A getter method that returns the state of the isDirty boolean.
        /// </summary>
        /// <returns>The boolean value of the isDirty flag.</returns>
        public virtual bool GetIsDirty()
        {
            return isDirty;
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgContainer(this);
        }

        public void Add(MmgObj obj)
        {
            container.Add(obj);
        }

        public void Remove(MmgObj obj)
        {
            container.Remove(obj);
        }

        public int GetCount()
        {
            return container.Count;
        }

        public object[] GetArray()
        {
            return container.ToArray();
        }

        public void Clear()
        {
            container.Clear();
        }

        public List<object> GetContainer()
        {
            return container;
        }

        public void SetContainer(List<object> a)
        {
            container = a;
        }

        public override void MmgDraw(MmgPen p)
        {
            if (GetIsVisible() == true)
            {
                if (container != null)
                {
                    a = container.ToArray();
                    for (i = 0; i < a.Length; i++)
                    {
                        mo = (MmgObj)a[i];
                        if (mo != null && mo.GetIsVisible() == true)
                        {
                            mo.MmgDraw(p);
                        }
                        else
                        {
                            //do nothing
                        }
                    }

                }
            }
            else
            {
                //do nothing
            }
        }

    }
}
