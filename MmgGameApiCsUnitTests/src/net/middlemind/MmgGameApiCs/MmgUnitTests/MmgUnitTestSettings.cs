using System;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;

//Converted equals and Equals
namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    public class MmgUnitTestSettings
    {
        public static bool GRAPHICS_CONFIG_LOADED = StartXnaGame();
        public static GraphicsDevice GRAPHICS_CONFIG = null;
        public static string APP_NAME = "MmgTestSpace";
        public static string ROOT_DIR = "/Users/victor/Documents/files/netbeans_workspace/MmgGameApiJava/";
        public static string RESOURCE_ROOT_DIR = ROOT_DIR + "cfg/";
        public static string APP_IMAGE_RESOURCE_ROOT_DIR = ROOT_DIR + "cfg/drawable/" + APP_NAME + "/";
        public static string APP_SOUND_RESOURCE_ROOT_DIR = ROOT_DIR + "cfg/playable/" + APP_NAME + "/";

        public static bool StartXnaGame()
        {
            try
            {
                ThreadStart ts = new ThreadStart(run);
                Thread t = new Thread(ts);
                t.Start();
                return true;
            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
                return false;
            }
        }

        public static void run()
        {
            MmgApiGame.AltMain(new string[] { });
            int i = 0;
            int max = 50;
            while (i < max)
            {
                if (MmgScreenData.GRAPHICS_CONFIG != null)
                {
                    Thread.Sleep(50);
                    GRAPHICS_CONFIG = MmgScreenData.GRAPHICS_CONFIG;
                }
            }
        }
    }
}