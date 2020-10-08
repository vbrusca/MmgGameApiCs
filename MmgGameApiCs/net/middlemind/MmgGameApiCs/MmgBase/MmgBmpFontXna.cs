using System;
using System.IO;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// @author Victor G. Brusca
    /// Middlemind Games 01/13/2012
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgBmpFontXna : MmgObj
    {
        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private int[] font_xpos;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private int[] font_width;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private int font_height;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private MmgBmp fontimg;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private string text;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private byte[] carddata;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private char[] c;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private int tx;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private int i;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private int tmp;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private int n;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private int len;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private BinaryReader ifile;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private MemoryStream bai;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private MmgRect tmpDstRect;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private MmgRect tmpSrcRect;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        public MmgBmpFontXna() : base()
        {
            font_xpos = null;
            font_width = null;
            font_height = 0;
            fontimg = null;
            text = "";
            carddata = null;
            c = null;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="obj"></param>
        public MmgBmpFontXna(MmgObj obj) : base(obj)
        {
            font_xpos = null;
            font_width = null;
            font_height = 0;
            fontimg = null;
            text = "";
            carddata = null;
            c = null;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="obj"></param>
        public MmgBmpFontXna(MmgBmpFontXna obj)
        {
            SetFontXpos(obj.GetFontXpos());
            SetFontWidth(obj.GetFontWidth());
            SetFontHeight(obj.GetFontHeight());

            if (obj.GetFontImg() == null)
            {
                SetFontImg(obj.GetFontImg());
            }
            else
            {
                SetFontImg((MmgBmp)obj.GetFontImg().Clone());
            }

            SetText(obj.GetText());
            SetCardData(obj.GetCardData());
            SetCharArray(obj.GetCharArray());

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                SetPosition(obj.GetPosition().Clone());
            }

            SetWidth(obj.GetWidth());
            SetHeight(obj.GetHeight());
            SetIsVisible(obj.GetIsVisible());

            if (obj.GetMmgColor() == null)
            {
                SetMmgColor(obj.GetMmgColor());
            }
            else
            {
                SetMmgColor(obj.GetMmgColor().Clone());
            }
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="img"></param>
        /// <param name="cd"></param>
        /// <param name="Text"></param>
        public MmgBmpFontXna(MmgBmp img, byte[] cd, string Text)
        {
            LoadFont(img, cd);
            text = Text;

            SetWidth(GetTextWidth(text));
            SetHeight(fontimg.GetHeight());
            font_height = GetHeight();

            SetPosition(new MmgVector2(0, 0));
            SetIsVisible(true);
            SetMmgColor(MmgColor.GetWhite());
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <returns></returns>
        public virtual char[] GetCharArray()
        {
            return c;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="chr"></param>
        public virtual void SetCharArray(char[] chr)
        {
            c = chr;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <returns></returns>
        public virtual byte[] GetCardData()
        {
            return carddata;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="b"></param>
        public virtual void SetCardData(byte[] b)
        {
            carddata = b;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <returns></returns>
        public virtual string GetText()
        {
            return text;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="s"></param>
        public virtual void SetText(string s)
        {
            text = s;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <returns></returns>
        public virtual MmgBmp GetFontImg()
        {
            return fontimg;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="i"></param>
        public virtual void SetFontImg(MmgBmp i)
        {
            fontimg = i;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <returns></returns>
        public virtual int GetFontHeight()
        {
            return font_height;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="h"></param>
        public virtual void SetFontHeight(int h)
        {
            font_height = h;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <returns></returns>
        public virtual int[] GetFontWidth()
        {
            return font_width;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="h"></param>
        public virtual void SetFontWidth(int[] h)
        {
            font_width = h;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <returns></returns>
        public virtual int[] GetFontXpos()
        {
            return font_xpos;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="h"></param>
        public virtual void SetFontXpos(int[] h)
        {
            font_xpos = h;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <returns></returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgBmpFontXna(this);
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="abyte0"></param>
        /// <returns></returns>
        private short ToShort(byte[] abyte0)
        {
            return ToShort(abyte0, false);
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="abyte0"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private short ToShort(byte[] abyte0, bool flag)
        {
            short word0 = 0;
            if (flag)
            {
                abyte0 = reverse_order(abyte0, 2);
            }
            for (byte byte0 = 0; byte0 <= 1; byte0++)
            {
                short word1;
                if (abyte0[byte0] < 0)
                {
                    abyte0[byte0] = (byte)(abyte0[byte0] & 0x7f);
                    word1 = abyte0[byte0];
                    word1 |= 0x80;
                }
                else
                {
                    word1 = abyte0[byte0];
                }
                word0 |= word1;
                if (byte0 < 1)
                {
                    word0 <<= 8;
                }
            }

            return word0;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="abyte0"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private byte[] reverse_order(byte[] abyte0, int i)
        {
            byte[] abyte1 = new byte[i];
            for (byte byte0 = 0; byte0 <= i - 1; byte0++)
            {
                abyte1[byte0] = abyte0[i - 1 - byte0];
            }
            return abyte1;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="img"></param>
        /// <param name="cd"></param>
        public virtual void LoadFont(MmgBmp img, byte[] cd)
        {
            try
            {
                fontimg = img;
                carddata = cd;
                bai = new MemoryStream(carddata);
                ifile = new BinaryReader(bai);
                MmgDebug.wr("Data Len: " + carddata.Length);

                len = (int)ToShort(ifile.ReadBytes(2), false);
                MmgDebug.wr("Number of Chars: " + len);

                font_height = (int)ToShort(ifile.ReadBytes(2), false); ;
                MmgDebug.wr("Font Height: " + font_height);

                font_width = new int[len];
                font_xpos = new int[len];

                for (int i = 0; i < len; i++)
                {
                    font_xpos[i] = (int)ToShort(ifile.ReadBytes(2), false); ;
                    font_width[i] = (int)ToShort(ifile.ReadBytes(2), false); ;
                    MmgDebug.wr("Index: " + i + " Width: " + font_width[i] + " xpos: " + font_xpos[i]);
                }

                try
                {
                    ifile.Close();
                }
                catch (Exception ex1)
                {
                    MmgHelper.wrErr(ex1);
                }

                ifile = null;

                try
                {
                    bai.Close();
                }
                catch (Exception ex2)
                {
                    MmgHelper.wrErr(ex2);
                }

                bai = null;
            }
            catch (Exception e)
            {
                MmgDebug.wr(e.StackTrace);
            }
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="pen"></param>
        public virtual void CreateTextImg(MmgPen pen)
        {
            if (text == null || text.Equals(""))
            {
                return;
            }

            tx = 0;
            c = text.ToCharArray();
            tmpDstRect = null;
            tmpSrcRect = null;

            for (i = 0; i < text.Length; i++)
            {
                tmp = (int)c[i];
                tmp -= 32;
                if (tmp < 0 || tmp >= font_width.Length)
                {
                    Console.WriteLine("Missing key  " + i + "] " + tmp + " skipped (" + (char)tmp + ")");
                }
                else
                {
                    tmpSrcRect = new MmgRect(new MmgVector2(font_xpos[tmp], 0), font_width[tmp], font_height);
                    tmpDstRect = new MmgRect(new MmgVector2(GetPosition().GetX() + tx, GetPosition().GetY()), font_width[tmp], font_height);

                    //MmgDebug.wr("Idx: " + i + " SrcRect: " + srcRect.GetRect() + " DstRect: " + dstRect.GetRect());

                    fontimg.SetSrcRect(tmpSrcRect);
                    fontimg.SetDstRect(tmpDstRect);

                    //pen.drawBitmap(font_xpos[tmp], 0, (font_xpos[tmp] + font_width[tmp]), (0 + font_height), tx, y, (tx + font_width[tmp]), (y + font_height), fontimg);
                    pen.DrawBmp(fontimg);

                    tx += font_width[tmp];
                }
            }

        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int GetTextWidth(string str)
        {
            n = 0;
            char[] c = str.ToCharArray();
            for (i = 0; i < str.Length; i++)
            {
                tmp = (int)c[i];
                tmp -= 32;
                if (tmp < 0 || tmp >= font_width.Length)
                {

                }
                else
                {
                    n += (int)(font_width[tmp]);
                }
            }
            return n;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="p"></param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                CreateTextImg(p);
            }
        }
    }
}