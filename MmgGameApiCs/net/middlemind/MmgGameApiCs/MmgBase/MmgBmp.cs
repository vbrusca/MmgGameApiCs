using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that wraps the lower level bitmap object.
    /// Created by Middlemind Games 08/29/2016
    ///
    /// @author Victor G.Brusca
    /// </summary>      
    public class MmgBmp : MmgObj
    {
        /// <summary>
        /// Drawing mode to determine the best way to handle drawing a bitmap.
        /// </summary>        
        public enum MmgBmpDrawMode
        {
            DRAW_BMP_FULL,
            DRAW_BMP_BASIC_CACHE,
            DRAW_BMP_BASIC
        };

        /// <summary>
        /// The initial value to use for bitmap IDs in unique id mode.
        /// </summary>
        private static int ID_SRC = 0;

        /// <summary>
        /// The origin of this object.
        /// </summary>
        private MmgVector2 origin;

        /// <summary>
        /// The scaling to apply to this object, if defined.
        /// </summary>
        private MmgVector2 scaling;

        /// <summary>
        /// The source drawing rectangle if defined.
        /// </summary>
        private MmgRect srcRect;

        /// <summary>
        /// The destination drawing rectangle if defined.
        /// </summary>
        private MmgRect dstRect;

        /// <summary>
        /// The image representing this object, if defined.
        /// </summary>
        private Texture2D b;

        /// <summary>
        /// The rotation to apply to this object, if defined.
        /// </summary>
        private float rotation;

        /// <summary>
        /// 
        /// </summary>
        private SpriteEffects fx;

        /// <summary>
        /// 
        /// </summary>
        private float layerDepth;

        /// <summary>
        /// The string representation of this objects id.
        /// </summary>
        private String idStr;

        /// <summary>
        /// The integer representation of this objects id.
        /// </summary>
        private int id;

        /// <summary>
        /// A temporary MmgObj instance used in the Equals method.
        /// </summary>
        private MmgObj o1;

        /// <summary>
        /// A temporary MmgObj instance used in the Equals method.
        /// </summary>
        private MmgObj o2;

        /// <summary>
        /// The strategy to use when drawing bitmaps.
        /// </summary>
        public MmgBmpDrawMode DRAW_MODE = MmgBmpDrawMode.DRAW_BMP_BASIC;

        /// <summary>
        /// Generic constructor.
        /// </summary>
        public MmgBmp() : base()
        {
            origin = new MmgVector2(0, 0);
            scaling = new MmgVector2(1, 1);
            srcRect = MmgRect.GetUnitRect();
            dstRect = MmgRect.GetUnitRect();
            b = null;
            rotation = 0f;
            fx = SpriteEffects.None;
            layerDepth = 0f;
            SetBmpId();
        }

        /// <summary>
        /// Construct from a previous instance of MmgObj.
        /// </summary>
        /// <param name="obj">The object to create this class from.</param>
        public MmgBmp(MmgObj obj) : base(obj)
        {
            origin = new MmgVector2(0, 0);
            scaling = new MmgVector2(1, 1);
            srcRect = MmgRect.GetUnitRect();
            dstRect = MmgRect.GetUnitRect();
            b = null;
            rotation = 0f;
            fx = SpriteEffects.None;
            layerDepth = 0f;
            SetBmpId();
        }

        /// <summary>
        /// Construct from a previous instance of MmgBmp.
        /// </summary>
        /// <param name="bmp">The object to create this class from.</param>
        public MmgBmp(MmgBmp obj) : base()
        {
            SetRotation(obj.GetRotation());

            if (obj.GetOrigin() == null)
            {
                SetOrigin(obj.GetOrigin());
            }
            else
            {
                SetOrigin(obj.GetOrigin().Clone());
            }

            if (obj.GetSrcRect() == null)
            {
                SetSrcRect(obj.GetSrcRect());
            }
            else
            {
                SetSrcRect(obj.GetSrcRect().Clone());
            }

            if (obj.GetDstRect() == null)
            {
                SetDstRect(obj.GetDstRect());
            }
            else
            {
                SetDstRect(obj.GetDstRect().Clone());
            }

            SetTexture2D(obj.GetTexture2D());

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                SetPosition(obj.GetPosition().Clone());
            }

            if (obj.GetScaling() == null)
            {
                SetScaling(obj.GetScaling());
            }
            else
            {
                SetScaling(obj.GetScaling().Clone());
            }

            SetWidth(obj.GetUnscaledWidth());
            SetHeight(obj.GetUnscaledHeight());
            SetIsVisible(obj.GetIsVisible());

            if (obj.GetMmgColor() == null)
            {
                SetMmgColor(obj.GetMmgColor());
            }
            else
            {
                SetMmgColor(obj.GetMmgColor().Clone());
            }

            SetBmpId();

            SetSpriteFx(obj.GetSpriteFx());
            SetLayerDepth(obj.GetLayerDepth());
        }

        /// <summary>
        /// Construct from a lower level Image objects.
        /// </summary>
        /// <param name="t">The object to create this instance from.</param>
        public MmgBmp(Texture2D t) : base()
        {
            SetRotation(0f);
            SetOrigin(MmgVector2.GetOriginVec());
            SetScaling(MmgVector2.GetUnitVec());
            MmgRect r = new MmgRect(MmgVector2.GetOriginVec(), t.Width, t.Height);
            SetSrcRect(r);
            SetDstRect(null);
            SetTexture2D(t);

            SetPosition(MmgVector2.GetOriginVec());
            SetWidth(b.Width);
            SetHeight(b.Height);
            SetIsVisible(true);
            SetMmgColor(null);
            SetBmpId();

            SetSpriteFx(SpriteEffects.None);
            SetLayerDepth(0);
        }

        /// <summary>
        /// Construct this instance from a lower level image object and some rendering hints.
        /// </summary>
        /// <param name="t">The lower level Image object to create this instance from.</param>
        /// <param name="Src">The source drawing rectangle.</param>
        /// <param name="Dst">The destination drawing rectangle.</param>
        /// <param name="Origin">The origin this image should be rotated from.</param>
        /// <param name="Scaling">The scaling values to use when drawing this image.</param>
        /// <param name="Rotation">The rotation values to use when drawing this image.</param>
        public MmgBmp(Texture2D t, MmgRect Src, MmgRect Dst, MmgVector2 Origin, MmgVector2 Scaling, float Rotation) : base()
        {
            SetRotation(Rotation);
            SetOrigin(Origin);
            SetScaling(Scaling);
            SetSrcRect(Src);
            SetDstRect(Dst);
            SetTexture2D(t);
            SetLayerDepth(0);

            SetPosition(MmgVector2.GetOriginVec());
            SetWidth(b.Width);
            SetHeight(b.Height);
            SetIsVisible(true);
            SetMmgColor(null);
            SetBmpId();
        }

        /// <summary>
        /// Construct this instance from a lower level image object and some rendering hints.
        /// </summary>
        /// <param name="t">The lower level Image object to create this instance from.</param>
        /// <param name="Src">The source drawing rectangle.</param>
        /// <param name="Dst">The destination drawing rectangle.</param>
        /// <param name="Origin">The origin this image should be rotated from.</param>
        /// <param name="Scaling">The scaling values to use when drawing this image.</param>
        /// <param name="Rotation">The rotation values to use when drawing this image.</param>
        /// <param name="Fx"></param>
        public MmgBmp(Texture2D t, MmgRect Src, MmgRect Dst, MmgVector2 Origin, MmgVector2 Scaling, float Rotation, SpriteEffects Fx) : base()
        {
            SetRotation(Rotation);
            SetOrigin(Origin);
            SetScaling(Scaling);
            SetSrcRect(Src);
            SetDstRect(Dst);
            SetTexture2D(t);
            SetLayerDepth(0);

            SetPosition(MmgVector2.GetOriginVec());
            SetWidth(b.Width);
            SetHeight(b.Height);
            SetIsVisible(true);
            SetMmgColor(null);
            SetBmpId();

            SetSpriteFx(Fx);
        }

        /// <summary>
        /// Construct this instance from a lower level image object and some rendering hints.
        /// </summary>
        /// <param name="t">The lower level Image object to create this instance from.</param>
        /// <param name="Position">The position this object should be drawn at.</param>
        /// <param name="Origin">The origin this image should be rotated from.</param>
        /// <param name="Scaling">The scaling values to use when drawing this image.</param>
        /// <param name="Rotation">The rotation values to use when drawing this image.</param>
        public MmgBmp(Texture2D t, MmgVector2 Position, MmgVector2 Origin, MmgVector2 Scaling, float Rotation) : base()
        {
            SetRotation(Rotation);
            SetOrigin(Origin);
            SetScaling(Scaling);
            MmgRect r = new MmgRect(Position, t.Width, t.Height);
            SetSrcRect(r);
            SetDstRect(null);
            SetTexture2D(t);
            SetLayerDepth(0);

            SetPosition(Position);
            SetWidth(b.Width);
            SetHeight(b.Height);
            SetIsVisible(true);
            SetMmgColor(null);
            SetBmpId();
        }

        /// <summary>
        /// Construct this instance from a lower level image object and some rendering hints.
        /// </summary>
        /// <param name="t">The lower level Image object to create this instance from.</param>
        /// <param name="Position">The position this object should be drawn at.</param>
        /// <param name="Origin">The origin this image should be rotated from.</param>
        /// <param name="Scaling">The scaling values to use when drawing this image.</param>
        /// <param name="Rotation">The rotation values to use when drawing this image.</param>
        /// <param name="Fx"></param>
        public MmgBmp(Texture2D t, MmgVector2 Position, MmgVector2 Origin, MmgVector2 Scaling, float Rotation, SpriteEffects Fx)
        {
            SetRotation(Rotation);
            SetOrigin(Origin);
            SetScaling(Scaling);
            MmgRect r = new MmgRect(Position, t.Width, t.Height);
            SetSrcRect(r);
            SetDstRect(null);
            SetTexture2D(t);
            SetLayerDepth(0);

            SetPosition(Position);
            SetWidth(b.Width);
            SetHeight(b.Height);
            SetIsVisible(true);
            SetMmgColor(null);
            SetBmpId();

            SetSpriteFx(Fx);
        }

        /// <summary>
        /// Returns an id string, used in image caching, based on rotation.
        /// </summary>
        /// <param name="rotation">The rotation value to use in id string creation.</param>
        /// <returns>A new id string.</returns>        
        public string GetIdStr(float rotation)
        {
            return (idStr + "_" + rotation);
        }

        /// <summary>
        /// Returns an id string, used in image caching, based on scaling.
        /// </summary>
        /// <param name="scaling">The scaling value to use in id string creation.</param>
        /// <returns>A new id string.</returns>
        public string GetIdStr(MmgVector2 scaling)
        {
            return (idStr + "_" + scaling.GetXFloat() + "x" + scaling.GetYFloat());
        }

        /// <summary>
        /// Returns an id string taking the rotation and scaling into consideration. Used in image caching as a unique id to store a local copy of the image.
        /// </summary>
        /// <param name="rotation">The rotation value to use in id string creation.</param>
        /// <param name="scaling">The scaling value to use in id string creation.</param>
        /// <returns>A new id string.</returns>
        public string GetIdStr(float rotation, MmgVector2 scaling)
        {
            return (idStr + "_" + rotation + "_" + scaling.GetXFloat() + "x" + scaling.GetYFloat());
        }

        /// <summary>
        /// Id helper method, takes rotation into account when making an id.
        /// </summary>
        /// <param name="rotation">The rotation of the bitmap.</param>
        /// <returns>The unique id of the bitmap.</returns>
        public int GetId(float rotation)
        {
            
            return Int32.Parse((id + "0" + (int)(rotation)));
        }

        /// <summary>
        /// Id helper method, takes scaling into account when making an id.
        /// </summary>
        /// <param name="scaling">The scaling to apply to the object.</param>
        /// <returns>The unique id of the bitmap.</returns>
        public int GetId(MmgVector2 scaling)
        {
            return Int32.Parse((idStr + "0" + (int)(scaling.GetXFloat() * 10) + "0" + (int)(scaling.GetYFloat() * 10)));
        }

        /// <summary>
        /// If helper method, takes rotation, and scaling into account when making an id.
        /// </summary>
        /// <param name="rotation">The rotation of the bitmap.</param>
        /// <param name="scaling">The scaling of the bitmap.</param>
        /// <returns>The unique id of the bitmap.</returns>
        public int GetId(float rotation, MmgVector2 scaling)
        {
            return Int32.Parse((idStr + "0" + (int)(rotation) + "0" + (int)(scaling.GetXFloat() * 10) + "0" + (int)(scaling.GetYFloat() * 10)));
        }

        /// <summary>
        /// Get the unique id of the bitmap in string form.
        /// </summary>
        /// <returns>The string form of the unique id.</returns>
        public string GetBmpIdStr()
        {
            return idStr;
        }

        /// <summary>
        /// Sets the string form of the id.
        /// </summary>
        /// <param name="IdStr">A unique id string.</param>
        public void SetBmpIdStr(string IdStr)
        {
            idStr = IdStr;
        }

        /// <summary>
        /// Gets the string form of the id.
        /// </summary>
        /// <returns>A unique id integer.</returns>
        public int GetBmpId()
        {
            return id;
        }

        /// <summary>
        /// Sets the unique id integer and string representations using a common method.
        /// </summary>
        private void SetBmpId()
        {
            id = MmgBmp.ID_SRC;
            idStr = (id + "");
            MmgBmp.ID_SRC++;
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj) new MmgBmp(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public override MmgBmp CloneTyped()
        {
            return new MmgBmp(this);
        }

        /// <summary>
        /// Returns the image of this bitmap.
        /// </summary>
        /// <returns>This bitmaps image.</returns>
        public Texture2D GetTexture2D()
        {
            return b;
        }

        /// <summary>
        /// Sets the image of this bitmap.
        /// </summary>
        /// <param name="d">The image to set for this bitmap.</param>
        public void SetTexture2D(Texture2D d)
        {
            b = d;
        }

        /// <summary>
        /// Gets the source drawing rectangle of this bitmap. Only used by drawing
        /// methods in the MmgPen class that supports, source, or source, destination
        /// drawing methods.
        /// </summary>
        /// <returns>The source drawing rectangle.</returns>
        public MmgRect GetSrcRect()
        {
            return srcRect;
        }

        /// <summary>
        /// Sets the source drawing rectangle. Only used by drawing methods in the
        /// MmgPen class that supports, source, or source, destination drawing
        /// methods.
        /// </summary>
        /// <param name="r">The source drawing rectangle.</param>
        public void SetSrcRect(MmgRect r)
        {
            srcRect = r;
        }

        /// <summary>
        /// Gets the destination drawing rectangle.
        /// </summary>
        /// <returns>The destination drawing rectangle.</returns>
        public MmgRect GetDstRect()
        {
            return dstRect;
        }

        /// <summary>
        /// Sets the destination drawing rectangle.
        /// </summary>
        /// <param name="r">The destination drawing rectangle.</param>
        public void SetDstRect(MmgRect r)
        {
            dstRect = r;
        }

        public float GetRotation()
        {
            return rotation;
        }

        public void SetRotation(float r)
        {
            rotation = r;
        }

        public MmgVector2 GetOrigin()
        {
            return origin;
        }

        public void SetOrigin(MmgVector2 v)
        {
            origin = v;
        }

        public MmgVector2 GetScaling()
        {
            return scaling;
        }

        public void SetScaling(MmgVector2 v)
        {
            scaling = v;
        }

        public SpriteEffects GetSpriteFx()
        {
            return fx;
        }

        public void SetSpriteFx(SpriteEffects Fx)
        {
            fx = Fx;
        }

        public float GetLayerDepth()
        {
            return layerDepth;
        }

        public void SetLayerDepth(float f)
        {
            layerDepth = f;
        }

        public double GetScaledHeight()
        {
            if (GetScaling() == null)
            {
                return base.GetHeight();
            }
            else
            {
                return ((double)base.GetHeight() * GetScaling().GetXDouble());
            }
        }

        public int GetUnscaledHeight()
        {
            return base.GetHeight();
        }

        public override int GetHeight()
        {
            return (int)GetScaledHeight();
        }

        public float GetHeightFloat()
        {
            return (float)GetScaledHeight();
        }

        public int GetUnscaledWidth()
        {
            return base.GetWidth();
        }

        public double GetScaledWidth()
        {
            if (GetScaling() == null)
            {
                return base.GetWidth();
            }
            else
            {
                return ((double)base.GetWidth() * GetScaling().GetYDouble());
            }
        }

        public override int GetWidth()
        {
            return (int)GetScaledWidth();
        }

        public float GetWidthFloat()
        {
            return (float)GetScaledWidth();
        }

        public override void MmgDraw(MmgPen p)
        {
            if (GetIsVisible() == true)
            {
                p.DrawBmp(this);
            }
            else
            {
                //do nothing
            }
        }

    }
}
