using System;
using net.middlemind.MmgGameApiCs.MmgTestSpace;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// A centralized main class that can run the different executable classes in the library.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 10/14/2020
    /// </summary>
    public class MmgCentralMain
    {
        /// <summary>
        /// Static main entry point.
        /// </summary>
        /// <param name="args">String array of arguments, append the executable name before its arguments.</param>
        public static void Main(string[] args)
        {
            if(args == null || args.Length == 0)
            {
                Console.WriteLine("No arguments found.");
                return;
            }

            string[] nArgs = new string[args.Length - 1];
            Array.Copy(args, 1, nArgs, 0, nArgs.Length);

            string t = "";
            for(int i = 0; i < nArgs.Length; i++)
            {
                t += (i + 1) + ": " + nArgs[i] + ",";
            }
            MmgHelper.wr("AdjustedArgs: " + t);

            if (args[0] != null && args[0].ToLower().Equals("controllerreadtest"))
            {
                ControllerReadTest.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("mmgtestspace"))
            {
                MmgTestScreens.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("mmgapigame"))
            {
                MmgApiGame.AltMain(nArgs);

            }
            else
            {
                MmgTestScreens.AltMain(nArgs);

            }
        }
    }
}
