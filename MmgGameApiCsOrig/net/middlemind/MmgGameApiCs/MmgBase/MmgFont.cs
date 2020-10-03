﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that wraps the lower level font class. 
    /// Created by Middlemind Games 08/29/2016
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgFont : MmgObj
    {
        /// <summary>
        /// Font of this class.
        /// </summary>
        private SpriteFont font;

        /// <summary>
        /// The text this font class is going to display.
        /// </summary>
        private string text;

        /// <summary>
        /// The integer value of the current font size.
        /// </summary>
        private int fontSize;

        /// <summary>
        /// The float value needed to scale the current font up to the specified size.
        /// </summary>
        private float fontScale;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        public MmgFont() : base()
        {
            text = "";
            font = null;
            SetWidth(0);
            SetHeight(0);
        }

        /// <summary>
        /// Constructor that sets the lower level attributes based on the given
        /// argument.
        /// </summary>
        /// <param name="obj">The MmgObj to use.</param>
        public MmgFont(MmgObj obj) : base(obj)
        {
            text = "";
            font = null;
            SetWidth(0);
            SetHeight(0);
        }

        /// <summary>
        /// Constructor that sets the lower level font class.
        /// </summary>
        /// <param name="tf">Font to use for text drawing.</param>
        public MmgFont(SpriteFont tf) : base()
        {
            text = "";
            font = tf;
            SetWidth(0);
            SetHeight(0);
        }

        /// <summary>
        /// Constructor that sets attributes based on the given argument.
        /// </summary>
        /// <param name="obj">The MmgFont class instance to use to set all the class fields.</param>
        public MmgFont(MmgFont obj) : base()
        {
            SetFont(obj.GetFont());
            SetText(obj.GetText());

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                SetPosition(obj.GetPosition().Clone());
            }

            SetIsVisible(obj.GetIsVisible());

            if (obj.GetMmgColor() == null)
            {
                SetMmgColor(obj.GetMmgColor());
            }
            else
            {
                SetMmgColor(obj.GetMmgColor().Clone());
            }

            SetHeight(obj.GetHeight());
            SetWidth(obj.GetWidth());
        }

        /// <summary>
        /// Constructor that sets the font, text, position, and color.
        /// </summary>
        /// <param name="sf">Low level font class.</param>
        /// <param name="txt">Text to draw.</param>
        /// <param name="pos">Position to draw the text.</param>
        /// <param name="cl">Color to use to draw the text.</param>
        public MmgFont(SpriteFont sf, String txt, MmgVector2 pos, MmgColor cl) : base()
        {
            SetFont(sf);
            SetText(txt);
            SetPosition(pos);
            SetIsVisible(true);
            SetMmgColor(cl);
        }

        /// <summary>
        /// Constructor that sets the font, text, position in X, Y, and color.
        /// </summary>
        /// <param name="sf">Low level font class.</param>
        /// <param name="txt">Text to draw.</param>
        /// <param name="x">Position, on the X axis.</param>
        /// <param name="y">Position, on the Y axis.</param>
        /// <param name="cl">Color to use to draw the text.</param>
        public MmgFont(SpriteFont sf, String txt, int x, int y, MmgColor cl)
        {
            SetFont(sf);
            SetText(txt);
            SetPosition(new MmgVector2(x, y));
            SetIsVisible(true);
            SetMmgColor(cl);
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgFont(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgFont CloneTyped()
        {
            return new MmgFont(this);
        }

        /// <summary>
        /// Gets the text for this object.
        /// </summary>
        /// <returns>The text for this object.</returns>
        public virtual string GetText()
        {
            return text;
        }

        /// <summary>
        /// Sets the text for this object. 
        /// Recalculates the drawing bounds of this
        /// object.
        /// </summary>
        /// <param name="s">The text for this object.</param>
        public virtual void SetText(string s)
        {
            if (s != null)
            {
                text = s;
                if ("".Equals(text) == false)
                {
                    Vector2 v2 = font.MeasureString(text);
                    SetWidth((int)v2.X);
                    SetHeight((int)v2.Y);
                }
                else
                {
                    SetWidth(0);
                    SetHeight(0);
                }
            }
            else
            {
                text = null;
                SetWidth(0);
                SetHeight(0);
            }
        }

        /// <summary>
        /// Sets the size of the font.
        /// </summary>
        /// <param name="sz">The size of the font.</param>
        public virtual void SetFontSize(int sz)
        {
            fontSize = sz;
            fontScale = (float)sz / (float)GetHeight();
        }

        /// <summary>
        /// Gets the size of the font.
        /// </summary>
        /// <returns>The size of the font.</returns>
        public virtual int GetFontSize()
        {
            return fontSize;
        }

        /// <summary>
        /// Sets the sprite font, or font to use to draw text.
        /// </summary>
        /// <param name="spf">The font to use for this MmgFont object.</param>
        public virtual void SetFont(SpriteFont spf)
        {
            font = spf;
        }

        /// <summary>
        /// Gets the font object used to draw text.
        /// </summary>
        /// <returns>The font used to draw text.</returns>
        public virtual SpriteFont GetFont()
        {
            return font;
        }

        /// <summary>
        /// The base drawing method used to draw this object.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                p.DrawText(this);
            }
        }

        /// <summary>
        /// A class method that tests for equality based on the font and text of the
        /// comparison object.
        /// </summary>
        /// <param name="obj">The MmgFont object to compare</param>
        /// <returns>A boolean indicating if the object instance is equal to the argument object instance.</returns>
        public virtual bool equals(MmgFont obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            /*
            if(!(super.equals((MmgObj)obj))) {
               MmgHelper.wr("MmgFont: MmgObj is not equals!"); 
            }

            if(!(((obj.GetFont() == null && GetFont() == null) || (obj.GetFont() != null && GetFont() != null && obj.GetFont().Equals(GetFont()))))) {
               MmgHelper.wr("MmgFont: Font is not equals!");
            }

            if(!(((obj.GetText() == null && GetText() == null) || (obj.GetText() != null && GetText() != null && obj.GetText().Equals(GetText()))))) {
               MmgHelper.wr("MmgFont: Text is not equals!");
            }
            */

            bool ret = false;
            if (
                base.equals((MmgObj)obj)
                && ((obj.GetFont() == null && GetFont() == null) || (obj.GetFont() != null && GetFont() != null && obj.GetFont().Equals(GetFont())))
                && ((obj.GetText() == null && GetText() == null) || (obj.GetText() != null && GetText() != null && obj.GetText().Equals(GetText())))
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}