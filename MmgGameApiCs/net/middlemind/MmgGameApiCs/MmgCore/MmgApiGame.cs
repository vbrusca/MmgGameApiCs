﻿using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// Java swing game that runs the Tyre DAT file. 
    /// STATIC MAIN ENTRY POINT EXAMPLE
    /// Created by Middlemind Games 08/01/2015
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgApiGame
    {
        /// <summary>
        /// The main JPanel that houses the different game screens.
        /// </summary>
        public static MainFrame mf;

        /// <summary>
        /// The frame rate worker thread.
        /// </summary>
        public static RunFrameRate fr;

        /// <summary>
        /// The thread that is associated with the frame rate worker thread.
        /// </summary>
        public static Thread t;

        /// <summary>
        /// The target window width.
        /// </summary>
        public static int WIN_WIDTH = 858;

        /// <summary>
        /// The target window height. 
        /// </summary>
        public static int WIN_HEIGHT = 600;

        /// <summary>
        /// The game panel width. 
        /// </summary>
        public static int PANEL_WIDTH = 854;

        /// <summary>
        /// The game panel height.
        /// </summary>
        public static int PANEL_HEIGHT = 596; //416;

        /// <summary>
        /// The game width.
        /// </summary>
        public static int GAME_WIDTH = 854;

        /// <summary>
        /// The game height.
        /// </summary>
        public static int GAME_HEIGHT = 416;

        /// <summary>
        /// The frame rate for the game, frames per second.
        /// </summary>
        public static long FPS = 16L;

        /// <summary>
        /// Base engine config files.
        /// </summary>
        public static string ENGINE_CONFIG_FILE = "../cfg/engine_config.xml";

        /// <summary>
        /// The GamePanel used to render the game in a MainFrame instance.
        /// </summary>
        public static GamePanel pnlGame;

        /// <summary>
        /// A copy of the command line arguments passed to the Java application.
        /// </summary>
        public static string[] ARGS = null;

        /// <summary>
        /// Method that searches an array for a string match.
        /// </summary>
        /// <param name="v">The string to find a match for.</param>
        /// <param name="s">The command line argument that matched the test string, v.</param>
        /// <returns></returns>
        public static string ArrayHasEntryLike(string v, string[] s)
        {
            if (v == null || s == null)
            {
                return null;
            }

            string tmp = v.ToLower();
            int len = s.Length;
            for (int i = 0; i < len; i++)
            {
                if (s[i] != null)
                {
                    if (s[i].ToLower().Contains(tmp) == true || s[i].ToLower().Equals(tmp) == true)
                    {
                        return s[i];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// A static method that loads native libraries that allow access to gamepads and controllers.
        /// </summary>
        public static void LoadNativeLibraries()
        {
            try
            {
                int p = (int)Environment.OSVersion.Platform;
                string OS = "win"; //System.getProperty("os.name").toLowerCase();

                if(p == 4 || p == 128 || RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
                {
                    OS = "linux";
                }
                else if(p == 6 || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    OS = "mac";
                }
                else if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    OS = "win";
                }

                MmgHelper.wr("Found platform: " + OS);
                //MmgHelper.wr("LibPath: " + System.getProperty("java.library.path"));
                //System.load("/Users/victor/Documents/files/netbeans_workspace/MmgGameApiJava/lib/jinput-platform/native-libs/libjinput-osx.jnilib");

                if (isWindows(OS))
                {
                    MmgHelper.wr("This is Windows");
                    //System.loadLibrary("jinput-dx8_64");

                }
                else if (isMac(OS))
                {
                    MmgHelper.wr("This is Mac");
                    //System.loadLibrary("jinput-osx");

                }
                else if (isUnix(OS))
                {
                    MmgHelper.wr("This is Unix or Linux");
                    //System.loadLibrary("jinput-linux64");

                }
                else if (isSolaris(OS))
                {
                    MmgHelper.wr("This is Solaris");
                    //System.loadLibrary("jinput-linux");

                }
                else
                {
                    MmgHelper.wr("Your OS is not supported!!");

                }

            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
            }
        }

        /// <summary>
        /// A static class method for checking if this Java application is running on Windows.
        /// </summary>
        /// <param name="OS">The current OS, System.getProperty("os.name").toLowerCase(), that this Java application is running on.</param>
        /// <returns>A bool value indicating if the Java application is running on Windows.</returns>
        public static bool isWindows(string OS)
        {
            return (OS.IndexOf("win") >= 0);
        }

        /// <summary>
        /// A static class method for checking if this Java application is running on a Mac.
        /// </summary>
        /// <param name="OS">The current OS, System.getProperty("os.name").toLowerCase(), that this Java application is running on.</param>
        /// <returns>A bool value indicating if the Java application is running on a Mac.</returns>
        public static bool isMac(string OS)
        {
            return (OS.IndexOf("mac") >= 0);
        }

        /// <summary>
        /// A static class method for checking if this Java application is running on Linux.
        /// </summary>
        /// <param name="OS">The current OS, System.getProperty("os.name").toLowerCase(), that this Java application is running on.</param>
        /// <returns>A bool value indicating if the Java application is running on Linux.</returns>
        public static bool isUnix(string OS)
        {
            return (OS.IndexOf("nix") >= 0 || OS.IndexOf("nux") >= 0 || OS.IndexOf("aix") > 0);
        }

        /// <summary>
        /// A static class method for checking if this Java application is running on Sun OS.
        /// </summary>
        /// <param name="OS">The current OS, System.getProperty("os.name").toLowerCase(), that this Java application is running on.</param>
        /// <returns>A bool value indicating if the Java application is running on Sun OS.</returns>
        public static bool isSolaris(string OS)
        {
            return (OS.IndexOf("sunos") >= 0);
        }

        /// <summary>
        /// Sets the value of the field specified by the field reflection object.
        /// </summary>
        /// <param name="ent">Entry object that wraps the XML entry.</param>
        /// <param name="f">Class member that needs to be updated.</param>
        public static void SetField(DatConstantsEntry ent, FieldInfo f)
        {
            if (ent.type != null && ent.type.Equals("int") == true)
            {
                f.SetValue(null, int.Parse(ent.val));

            }
            else if (ent.type != null && ent.type.Equals("long") == true)
            {
                f.SetValue(null, long.Parse(ent.val));

            }
            else if (ent.type != null && ent.type.Equals("float") == true)
            {
                f.SetValue(null, float.Parse(ent.val));

            }
            else if (ent.type != null && ent.type.Equals("double") == true)
            {
                f.SetValue(null, double.Parse(ent.val));

            }
            else if (ent.type != null && ent.type.Equals("short") == true)
            {
                f.SetValue(null, Int16.Parse(ent.val));

            }
            else if (ent.type != null && ent.type.Equals("string") == true)
            {
                f.SetValue(null, ent.val);

            }
            else if (ent.type != null && ent.type.Equals("bool") == true)
            {
                f.SetValue(null, bool.Parse(ent.val));

            }
            else
            {
                f.SetValue(null, int.Parse(ent.val));
            }
        }

        /// <summary>
        /// Static main method.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        public static void main(string[] args)
        {
            if (GameSettings.LOAD_NATIVE_LIBRARIES)
            {
                LoadNativeLibraries();
            }

            //Store program arguments for future reference
            ARGS = args;
            if (args != null && args.Length > 0)
            {
                MmgHelper.wr("Found command line arguments!");
                string res = null;

                res = ArrayHasEntryLike("WIN_WIDTH=", args);
                if (res != null)
                {
                    WIN_WIDTH = int.Parse(res.Split("=")[1]);
                }

                res = ArrayHasEntryLike("WIN_HEIGHT=", args);
                if (res != null)
                {
                    WIN_HEIGHT = int.Parse(res.Split("=")[1]);
                }

                res = ArrayHasEntryLike("PANEL_WIDTH=", args);
                if (res != null)
                {
                    PANEL_WIDTH = int.Parse(res.Split("=")[1]);
                }

                res = ArrayHasEntryLike("PANEL_HEIGHT=", args);
                if (res != null)
                {
                    PANEL_HEIGHT = int.Parse(res.Split("=")[1]);
                }

                res = ArrayHasEntryLike("FPS=", args);
                if (res != null)
                {
                    FPS = int.Parse(res.Split("=")[1]);
                }

                //NOT APPLICABLE ON MONOGAME DESKTOP GL PROJECT
                //res = ArrayHasEntryLike("OPENGL=false", args);
                //if (res == null)
                //{
                //    System.setProperty("sun.java2d.opengl", "true");
                //}

                res = ArrayHasEntryLike("ENGINE_CONFIG_FILE=", args);
                if (res != null)
                {
                    ENGINE_CONFIG_FILE = res.Split("=")[1];
                }

                res = ArrayHasEntryLike("ODROID=true", args);
                if (res != null)
                {
                    WIN_WIDTH = 480;
                    WIN_HEIGHT = 320;
                    PANEL_WIDTH = 478;
                    PANEL_HEIGHT = 318;
                    GAME_WIDTH = 478;
                    GAME_HEIGHT = 318;
                }
            }

            //LOAD ENGINE CONFIG FILE
            try
            {
                if (MmgApiGame.ENGINE_CONFIG_FILE != null && MmgApiGame.ENGINE_CONFIG_FILE.Equals("") == false)
                {
                    GameSettingsImporter dci = new GameSettingsImporter();
                    bool r = dci.ImportGameSettings(MmgApiGame.ENGINE_CONFIG_FILE);
                    MmgHelper.wr("Engine config load result: " + r);

                    int len = dci.GetValues().keySet().size();
                    string[] keys = dci.GetValues().keySet().toArray(new String[len]);
                    string key;
                    DatConstantsEntry ent = null;
                    FieldInfo f = null;

                    for (int i = 0; i < len; i++)
                    {
                        try
                        {
                            key = keys[i];
                            ent = dci.GetValues().get(key);

                            if (ent.from != null && ent.from.Equals("GameSettings") == true)
                            {
                                //f = GameSettings.class.getField(ent.key);
                                if (f != null)
                                {
                                    MmgHelper.wr("Importing " + ent.from + " field: " + ent.key + " with value: " + ent.val + " with type: " + ent.type + " from: " + ent.from);
                                    SetField(ent, f);
                                }
                            }
                            else if (ent.from != null && ent.from.Equals("Helper") == true)
                            {
                                //f = GameSettings.class.getField(ent.key);
                                if (f != null)
                                {
                                    MmgHelper.wr("Importing " + ent.from + " field: " + ent.key + " with value: " + ent.val + " with type: " + ent.type + " from: " + ent.from);
                                    SetField(ent, f);
                                }
                            }
                            else if (ent.from != null && ent.from.Equals("StaticMain") == true)
                            {
                                //f = MmgApiGame.class.getField(ent.key);
                                if (f != null)
                                {
                                    MmgHelper.wr("Importing " + ent.from + " field: " + ent.key + " with value: " + ent.val + " with type: " + ent.type + " from: " + ent.from);
                                    SetField(ent, f);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            MmgHelper.wr("Ignoring dat constants field: " + ent.key + " with value: " + ent.val + " with type: " + ent.type);
                            MmgHelper.wrErr(e);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
            }

            //Set program specific resource loading directories
            GameSettings.PROGRAM_IMAGE_LOAD_DIR += GameSettings.NAME;
            GameSettings.PROGRAM_SOUND_LOAD_DIR += GameSettings.NAME;

            MmgHelper.wr("Window Width: " + WIN_WIDTH);
            MmgHelper.wr("Window Height: " + WIN_HEIGHT);
            MmgHelper.wr("Panel Width: " + PANEL_WIDTH);
            MmgHelper.wr("Panel Height: " + PANEL_HEIGHT);
            MmgHelper.wr("Game Width: " + GAME_WIDTH);
            MmgHelper.wr("Game Height: " + GAME_HEIGHT);

            mf = new MainFrame(MmgApiGame.WIN_WIDTH, MmgApiGame.WIN_HEIGHT, MmgApiGame.PANEL_WIDTH, MmgApiGame.PANEL_HEIGHT, MmgApiGame.GAME_WIDTH, MmgApiGame.GAME_HEIGHT);
            pnlGame = new GamePanel(mf, MmgApiGame.PANEL_WIDTH, MmgApiGame.PANEL_HEIGHT, (MmgApiGame.WIN_WIDTH - MmgApiGame.PANEL_WIDTH) / 2, (MmgApiGame.WIN_HEIGHT - MmgApiGame.PANEL_HEIGHT) / 2, MmgApiGame.GAME_WIDTH, MmgApiGame.GAME_HEIGHT);
            mf.SetGamePanel(pnlGame);
            mf.InitComponents();
            fr = new RunFrameRate(mf, FPS);

            mf.setSize(MmgApiGame.WIN_WIDTH, MmgApiGame.WIN_HEIGHT);
            mf.setResizable(false);
            mf.setVisible(true);
            mf.setName(GameSettings.NAME);

            if (GameSettings.DEVELOPMENT_MODE_ON == false)
            {
                mf.setTitle(GameSettings.TITLE);
            }
            else
            {
                mf.setTitle(GameSettings.TITLE + " - " + GameSettings.DEVELOPER_COMPANY + " (" + GameSettings.VERSION + ")");
            }

            mf.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            mf.GetGamePanel().PrepBuffers();
            t = new Thread(fr);
            t.Start();
        }
    }
}