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
            else if (args[0] != null && args[0].ToLower().Equals("chapter16"))
            {
                net.middlemind.PongClone.Chapter16.PongClone.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chapter17"))
            {
                net.middlemind.PongClone.Chapter17.PongClone.AltMain(nArgs);

            }
            else if (args[0] != null && (args[0].ToLower().Equals("chapter18") || args[0] != null && args[0].ToLower().Equals("chapter18_completegame")))
            {
                net.middlemind.PongClone.Chapter18_CompleteGame.PongClone.AltMain(nArgs);

            } 
            else if (args[0] != null && (args[0].ToLower().Equals("chaptere1") || args[0].ToLower().Equals("chapter20"))) 
            {
                net.middlemind.DungeonTrap.Chapter20.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && (args[0].ToLower().Equals("chaptere2") || args[0].ToLower().Equals("chapter21")))
            {
                net.middlemind.DungeonTrap.Chapter21.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && (args[0].ToLower().Equals("chaptere3") || args[0].ToLower().Equals("chapter22")))
            {
                net.middlemind.DungeonTrap.Chapter22.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && (args[0].ToLower().Equals("chaptere4") || args[0].ToLower().Equals("chapter23")))
            {
                net.middlemind.DungeonTrap.Chapter23.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && (args[0].ToLower().Equals("chaptere4_demoscreen") || args[0].ToLower().Equals("chapter23_demoscreen")))
            {
                net.middlemind.DungeonTrap.Chapter23_DemoScreen.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && (args[0].ToLower().Equals("chaptere5_phase1") || args[0].ToLower().Equals("chapter24_phase1")))
            {
                net.middlemind.DungeonTrap.Chapter24_Phase1.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && (args[0].ToLower().Equals("chaptere5_phase2") || args[0].ToLower().Equals("chapter24_phase2")))
            {
                net.middlemind.DungeonTrap.Chapter24_Phase2.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && (args[0].ToLower().Equals("chaptere5_phase3") || args[0].ToLower().Equals("chaptere5_phase3_completegame") || args[0].ToLower().Equals("chapter24_phase3") || args[0] != null && args[0].ToLower().Equals("chapter24_phase3_completegame")))
            {
                net.middlemind.DungeonTrap.Chapter24_Phase3_CompleteGame.DungeonTrap.AltMain(nArgs);

            }
            else
            {
                MmgTestScreens.AltMain(nArgs);

            }
        }
    }
}