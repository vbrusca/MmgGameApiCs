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
            else if (args[0] != null && args[0].ToLower().Equals("chapter13"))
            {
                net.middlemind.PongClone.Chapter13.PongClone.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chapter14"))
            {
                net.middlemind.PongClone.Chapter14.PongClone.AltMain(nArgs);

            }
            else if (args[0] != null && (args[0].ToLower().Equals("chapter15") || args[0] != null && args[0].ToLower().Equals("chapter15_completegame")))
            {
                net.middlemind.PongClone.Chapter15_CompleteGame.PongClone.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chapter16"))
            {
                net.middlemind.DungeonTrap.Chapter16.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chapter17"))
            {
                net.middlemind.DungeonTrap.Chapter17.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chapter18"))
            {
                net.middlemind.DungeonTrap.Chapter18.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chapter19"))
            {
                net.middlemind.DungeonTrap.Chapter19.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chapter19_demoscreen"))
            {
                net.middlemind.DungeonTrap.Chapter19_DemoScreen.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chapter20_phase1"))
            {
                net.middlemind.DungeonTrap.Chapter20_Phase1.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chapter20_phase2"))
            {
                net.middlemind.DungeonTrap.Chapter20_Phase2.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chapter20_phase3") || args[0] != null && args[0].ToLower().Equals("chapter20_phase3_completegame"))
            {
                net.middlemind.DungeonTrap.Chapter20_Phase3_CompleteGame.DungeonTrap.AltMain(nArgs);

            }
            else
            {
                MmgTestScreens.AltMain(nArgs);

            }
        }
    }
}