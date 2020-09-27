using System;
using Microsoft.Xna.Framework;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that wraps the lower level color object. 
    /// Created by Middlemind Games 08/29/2016
    ///
    /// @author Victor G.Brusca
    /// </summary>
    public class MmgColor
    {
        /// <summary>
        /// The color of this object.
        /// </summary>
        private Color c;

        /// <summary>
        /// Constructor of this object.
        /// </summary>
        public MmgColor()
        {
            c = Color.White;
        }

        /// <summary>
        /// Constructor that sets its properties from an input MmgColor object.
        /// </summary>
        /// <param name="obj">Input MmgColor object.</param>
        public MmgColor(MmgColor obj)
        {
            SetColor(obj.GetColor());
        }

        /// <summary>
        /// Constructor that sets the color to the given argument.
        /// </summary>
        /// <param name="C">The color to set the object.</param>
        public MmgColor(Color C)
        {
            c = C;
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual MmgColor Clone()
        {
            return new MmgColor(this);
        }

        /// <summary>
        /// Static helper method returns white.
        /// </summary>
        /// <returns>The color white.</returns>
        public static MmgColor GetWhite()
        {
            return new MmgColor(Color.White);
        }

        /// <summary>
        /// Static helper method returns black.
        /// </summary>
        /// <returns>The color black.</returns>
        public static MmgColor GetBlack()
        {
            return new MmgColor(Color.Black);
        }

        /// <summary>
        /// Static helper method returns red.
        /// </summary>
        /// <returns>The color red.</returns>
        public static MmgColor GetRed()
        {
            return new MmgColor(Color.Red);
        }

        /// <summary>
        /// Static helper method returns blue.
        /// </summary>
        /// <returns>The color blue.</returns>
        public static MmgColor GetBlue()
        {
            return new MmgColor(Color.Blue);
        }

        /// <summary>
        /// Static helper method returns green.
        /// </summary>
        /// <returns>The color green.</returns>
        public static MmgColor GetGreen()
        {
            return new MmgColor(Color.Green);
        }

        /// <summary>
        /// Static helper method returns cyan.
        /// </summary>
        /// <returns>The color cyan.</returns>
        public static MmgColor GetCyan()
        {
            return new MmgColor(Color.Cyan);
        }

        /// <summary>
        /// Static helper method returns gray.
        /// </summary>
        /// <returns>The color gray.</returns>
        public static MmgColor GetGray()
        {
            return new MmgColor(Color.Gray);
        }

        /// <summary>
        /// Static helper method returns dark gray.
        /// </summary>
        /// <returns>The color dark gray.</returns>
        public static MmgColor GetDarkGray()
        {
            return new MmgColor(Color.DarkGray);
        }

        /// <summary>
        /// Static helper method returns light gray.
        /// </summary>
        /// <returns>The color light gray.</returns>
        public static MmgColor GetLightGray()
        {
            return new MmgColor(Color.LightGray);
        }

        /// <summary>
        /// Static helper method returns magenta.
        /// </summary>
        /// <returns>The color magenta.</returns>
        public static MmgColor GetMagenta()
        {
            return new MmgColor(Color.Magenta);
        }

        /// <summary>
        /// Static helper method returns orange.
        /// </summary>
        /// <returns>The color orange.</returns>
        public static MmgColor GetOrange()
        {
            return new MmgColor(Color.Orange);
        }

        /// <summary>
        /// Static helper method returns pink.
        /// </summary>
        /// <returns>The color pink.</returns>
        public static MmgColor GetPink()
        {
            return new MmgColor(Color.Pink);
        }

        /// <summary>
        /// Static helper method returns yellow.
        /// </summary>
        /// <returns>The color yellow.</returns>
        public static MmgColor GetYellow()
        {
            return new MmgColor(Color.Yellow);
        }

        /// <summary>
        /// Static helper method returns lime green.
        /// </summary>
        /// <returns>The color lime green.</returns>
        public static MmgColor GetLimeGreen()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#DAF7A6");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns yellow orange.
        /// </summary>
        /// <returns>The color yellow orange.</returns>
        public static MmgColor GetYellowOrange()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#FFC300");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns red orange.
        /// </summary>
        /// <returns>The color red orange.</returns>
        public static MmgColor GetRedOrange()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#FF5733");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /// <summary>
        /// Static helper method returns purple red.
        /// </summary>
        /// <returns>The color purple red.</returns>
        public static MmgColor GetPurpleRed()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#C70039");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /*
         * Static helper method returns dark red.
         * 
         * @return      The color dark red.
         */
        public static MmgColor GetDarkRed()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#900C3F");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /*
         * Static helper method returns dark blue.
         * 
         * @return      The color dark blue.
         */
        public static MmgColor GetDarkBlue()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#0000A0");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /*
         * Static helper method returns light blue.
         * 
         * @return      The color light blue.
         */
        public static MmgColor GetLightBlue()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#ADD8E6");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /*
         * Static helper method returns olive.
         * 
         * @return      The color olive.
         */
        public static MmgColor GetOlive()
        {
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#808000");
            return new MmgColor(new Color(c.R, c.G, c.B, c.A));
        }

        /**
         * Static helper method returns brown.
         * 
         * @return      The color brown.
         */
        public static MmgColor GetBrown()
        {
            return new MmgColor(Color.decode("#A52A2A"));
        }

        /**
         * Static helper method returns maroon.
         * 
         * @return      The color maroon.
         */
        public static MmgColor GetMaroon()
        {
            return new MmgColor(Color.decode("#800000"));
        }

        /**
         * Static helper method returns gun metal gray.
         * 
         * @return      The color gun metal gray.
         */
        public static MmgColor GetGunMetalGray()
        {
            return new MmgColor(Color.decode("#2C3539"));
        }

        /**
         * Static helper method returns night.
         * 
         * @return      The color night.
         */
        public static MmgColor GetNight()
        {
            return new MmgColor(Color.decode("#0C090A"));
        }

        /**
         * Static helper method returns midnight.
         * 
         * @return      The color midnight.
         */
        public static MmgColor GetMidnight()
        {
            return new MmgColor(Color.decode("#2B1B17"));
        }

        /**
         * Static helper method returns charcoal.
         * 
         * @return      The color charcoal.
         */
        public static MmgColor GetCharcoal()
        {
            return new MmgColor(Color.decode("#34282C"));
        }

        /**
         * Static helper method returns dark slate gray.
         * 
         * @return      The color dark slate gray.
         */
        public static MmgColor GetDarkSlateGray()
        {
            return new MmgColor(Color.decode("#25383C"));
        }

        /**
         * Static helper method returns oil.
         * 
         * @return      The color oil.
         */
        public static MmgColor GetOil()
        {
            return new MmgColor(Color.decode("#3B3131"));
        }

        /**
         * Static helper method returns calm blue.
         * 
         * @return      The color calm blue.
         */
        public static MmgColor GetCalmBlue()
        {
            return new MmgColor(Color.decode("#3B8EFF"));
        }

        /**
         * Static helper method returns black cat.
         * 
         * @return      The color black cat.
         */
        public static MmgColor GetBlackCat()
        {
            return new MmgColor(Color.decode("#413839"));
        }

        /**
         * Static helper method returns iridium.
         * 
         * @return      The color iridium.
         */
        public static MmgColor GetIridium()
        {
            return new MmgColor(Color.decode("#3D3C3A"));
        }

        /**
         * Static helper method returns gray wolf.
         * 
         * @return      The color gray wolf.
         */
        public static MmgColor GetGrayWolf()
        {
            return new MmgColor(Color.decode("#504A4B"));
        }

        /**
         * Static helper method returns gray dolphin.
         * 
         * @return      The color gray dolphin.
         */
        public static MmgColor GetGrayDolphin()
        {
            return new MmgColor(Color.decode("#5C5858"));
        }

        /**
         * Static helper method returns carbon gray.
         * 
         * @return      The color carbon gray.
         */
        public static MmgColor GetCarbonGray()
        {
            return new MmgColor(Color.decode("#625D5D"));
        }

        /**
         * Static helper method returns battleship gray.
         * 
         * @return      The color battleship gray.
         */
        public static MmgColor GetBattleshipGray()
        {
            return new MmgColor(Color.decode("#848482"));
        }

        /**
         * Static helper method returns gray cloud.
         * 
         * @return      The color gray cloud.
         */
        public static MmgColor GetGrayCloud()
        {
            return new MmgColor(Color.decode("#B6B6B4"));
        }

        /**
         * Static helper method returns gray goose.
         * 
         * @return      The color gray goose.
         */
        public static MmgColor GetGrayGoose()
        {
            return new MmgColor(Color.decode("#D1D0CE"));
        }

        /**
         * Static helper method returns platinum.
         * 
         * @return      The color platinum.
         */
        public static MmgColor GetPlatinum()
        {
            return new MmgColor(Color.decode("#E5E4E2"));
        }

        /**
         * Static helper method returns metallic silver.
         * 
         * @return      The color metallic silver.
         */
        public static MmgColor GetMetallicSilver()
        {
            return new MmgColor(Color.decode("#BCC6CC"));
        }

        /**
         * Static helper method returns blue gray.
         * 
         * @return      The color blue gray
         */
        public static MmgColor GetBlueGray()
        {
            return new MmgColor(Color.decode("#98AFC7"));
        }

        /**
         * Static helper method returns slate blue.
         * 
         * @return      The color slate blue.
         */
        public static MmgColor GetSlateBlue()
        {
            return new MmgColor(Color.decode("#737CA1"));
        }

        //steel blue: #4863A0
        //navy blue: #000080
        //blue whale: #342D7E
        //sapphire blue: #2554C7
        //blue orcid: #1F45FC
        //blue lotus: #6960EC
        //crystal blue: #5CB3FF
        //power blue: #C6DEFF
        //blue green: #7BCCB5
        //teal: #008080
        //sea green: #4E8975
        //camouflage green: #78866B
        //dark forest green: #254117
        //clover green: #3EA055
        //zombie green: #54C571
        //mint green: #98FF98
        //harvest gold: #EDE275
        //corn yellow: #FFF380
        //blonde: #FBF6D9
        //tan brown: #ECE5B6
        //peach: #FFE5B4
        //mustard: #FFDB58
        //bright gold: #FDD017
        //cantaloupe: #FFA62F
        //deep peach: #FFCBA4
        //sand: #C2B280
        //brass: #B5A642
        //bronze: #CD7F32
        //copper: #B87333
        //wood: #966F33
        //mocha: #493D26
        //coffee: #6F4E37
        //sepia: #7F462C
        //pumpkin: #F87217
        //mango: #FF8040
        //dark orange: #F88017
        //tangerine: #E78A61
        //light coral: #E77471
        //scarlet: #FF2400
        //lava red: #E42217
        //grape fruit: #DC381F
        //cherry red: #C24641
        //cranberry: #9F000F
        //burgundy: #8C001A
        //chestnut: #954535
        //maroon: #810541
        //plum: #7D0552
        //puce: #7F5A58
        //rose: #E8ADAA
        //rose gold: #ECC5C0
        //light pink: #FAAFBA
        //flamingo pink: #F9A7B0
        //hot pink: #F660AB
        //magenta: #FF00FF
        //purple iris: #571B7E
        //purple haze: #4E387E
        //grape: #5E5A80
        //dark violet: #842DCE
        //lavender blue: #E3E4FA

        /**
         * Static helper method that decodes an HTML color.
         * 
         * @param htmlColor     The HTML color to decode.
         * @return              A new MmgColor object with the HTML color.
         */
        public static MmgColor GetDecodedColor(String htmlColor)
        {
            return new MmgColor(Color.decode(htmlColor));
        }

        /**
         * Static helper method that returns a transparent color.
         * 
         * @return      A new MmgColor object that has transparent color.
         */
        public static MmgColor GetTransparent()
        {
            return new MmgColor(new Color(0f, 0f, 0f, 1f));
        }

        public Color GetColor()
        {
            return c;
        }

        public void SetColor(Color C)
        {
            c = C;
        }

    }
}