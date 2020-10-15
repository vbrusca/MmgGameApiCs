using System;
using net.middlemind.MmgGameApiCs.MmgTestSpace;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// A centralized main class that can run the different executable classes in the library.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// </summary>
    public class MmgCentralMain
    {

        /**
         * Static main entry point.
         * 
         * @param args  String array of arguments, append the executable name before its arguments.
         */
        public static void ain(string[] args)
        {
            if(args == null || args.Length == 0)
            {
                Console.WriteLine("No arguments found.");
                return;
            }

            string[] nArgs = new string[args.Length - 1];
            Array.Copy(args, 1, nArgs, 0, nArgs.Length);

            if (args[0] != null && args[0].ToLower().Equals("controllerreadtest"))
            {
                //ControllerReadTest.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("mmgtestspace"))
            {
               // MmgTestScreens.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("mmgapigame"))
            {
                MmgApiGame.AltMain(nArgs);

            }
        }
    }
}
