using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// TODO: Add comments
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class GamePanel : Game, GenericEventHandler, GamePadSimple
    {
        /// <summary>
        /// An enumeration that lists all of the game states.
        /// Add new states here or use the general states, GAME_SCREEN_XX to control
        /// what the game displays.
        /// </summary>
        public enum GameStates
        {
            LOADING,
            BLANK,
            SPLASH,
            MAIN_MENU,
            ABOUT,
            HELP_MENU,
            HELP_PROLOGUE,
            HELP_ITEM_DESC,
            HELP_ENEMY_DESC,
            HELP_ITEM_DESC_ITEM_TEXT,
            HELP_GAME_PLAY_OVERWORLD,
            HELP_GAME_PLAY_BATTLE_MODE,
            HELP_CHAR_DESC,
            HELP_QUEST_DESC,
            HELP_ROOM_DESC,
            HELP_ROOM_DESC_ROOM_DETAILS,
            MAIN_GAME,
            MAIN_GAME_1P,
            MAIN_GAME_2P,
            SETTINGS,
            GAME_SCREEN_01,
            GAME_SCREEN_02,
            GAME_SCREEN_03,
            GAME_SCREEN_04,
            GAME_SCREEN_05,
            GAME_SCREEN_06,
            GAME_SCREEN_07,
            GAME_SCREEN_08,
            GAME_SCREEN_09,
            GAME_SCREEN_10,
            GAME_SCREEN_11,
            GAME_SCREEN_12,
            GAME_SCREEN_13,
            GAME_SCREEN_14,
            GAME_SCREEN_15,
            GAME_SCREEN_16,
            GAME_SCREEN_17,
            GAME_SCREEN_18,
            GAME_SCREEN_19,
            GAME_SCREEN_20,
            GAME_SCREEN_21,
            GAME_SCREEN_22,
            GAME_SCREEN_23,
            GAME_SCREEN_24,
            GAME_SCREEN_25,
            GAME_SCREEN_26,
            GAME_SCREEN_27,
            GAME_SCREEN_28,
            GAME_SCREEN_29,
            GAME_SCREEN_30,
            GAME_SCREEN_31,
            GAME_SCREEN_32,
            GAME_SCREEN_33,
            GAME_SCREEN_34,
            GAME_SCREEN_35,
            GAME_SCREEN_36,
            GAME_SCREEN_37,
            GAME_SCREEN_38,
            GAME_SCREEN_39,
            GAME_SCREEN_40
        }

        /// <summary>
        /// The width of the window this panel is displayed in.
        /// </summary>
        public int winWidth;

        /// <summary>
        /// The height of the window this panel is displayed in.
        /// </summary>
        public int winHeight;

        /// <summary>
        /// The X coordinate of this panel.
        /// </summary>
        public int myX;

        /// <summary>
        /// The Y coordinate of this panel.
        /// </summary>
        public int myY;

        /// <summary>
        /// The scaled width of the window this panel is displayed in.
        /// </summary>
        public int sWinWidth;

        /// <summary>
        /// The scaled height of the window this panel is displayed in.
        /// </summary>
        public int sWinHeight;

        /// <summary>
        /// The scaled X coordinate of this panel.
        /// </summary>
        public int sMyX;

        /// <summary>
        /// The scaled Y coordinate of this panel.
        /// </summary>
        public int sMyY;

        /// <summary>
        /// The target game width.
        /// </summary>
        public static int GAME_WIDTH = 854;

        /// <summary>
        /// The target game height.
        /// </summary>
        public static int GAME_HEIGHT = 416;

        /// <summary>
        /// Boolean that pauses the game.
        /// </summary>
        public static bool PAUSE = false;

        /// <summary>
        /// Boolean that exits the game.
        /// </summary>
        public static bool EXIT = false;

        /// <summary>
        /// The gameScreens field is a Dictionary that can be used to hold a reference to all game screens.
        /// </summary>
        public Dictionary<GameStates, MmgGameScreen> gameScreens;

        /// <summary>
        /// The current game screen being displayed.
        /// </summary>
        public MmgGameScreen currentScreen;

        /// <summary>
        /// An MmgPen class, used to draw Mmg API objects.
        /// </summary>
        public MmgPen p;

        /// <summary>
        /// An instance of the GameStates enumeration that holds the previous game state.
        /// </summary>
        public GameStates prevGameState;

        /// <summary>
        /// An instance of the GameStates enumeration that holds the current game state.
        /// </summary>
        public GameStates gameState;

        /// <summary>
        /// A static Dictionary instance that can be used to store objects for quick, easy access.
        /// </summary>
        public static Dictionary<string, object> VARS = new Dictionary<string, object>();

        /// <summary>
        /// A string used to store the current frame rate information in the debug header.
        /// </summary>
        public static string FPS = "Drawing FPS: 0000 Actual FPS: 00";

        /// <summary>
        /// A string used to write data to the debug header.
        /// </summary>
        public static string VAR1 = "** EMPTY **";

        /// <summary>
        /// A second string used to write data to the debug header.
        /// </summary>
        public static string VAR2 = "** EMPTY **";

        /// <summary>
        /// A canvas object used to draw to the JFrame.
        /// </summary>
        public GameWindow canvas;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private GraphicsDeviceManager gdm;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private SpriteBatch pen;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private bool visible = true;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private string name = "";

        /// <summary>
        /// A BufferedImage used to render the game screen to. 
        /// The background image is then rendered to the panel once it is done drawing.
        /// </summary>
        public RenderTarget2D background;

        /// <summary>
        /// A Java rendering API for drawing graphics to a BufferedImage.
        /// </summary>
        public SpriteBatch backgroundGraphics;

        /// <summary>
        /// A Java rendering API for drawing graphics to the JFrame.
        /// </summary>
        public SpriteBatch graphics;

        /// <summary>
        /// An optional scale value that will scale the background image before drawing it to the JFrame.
        /// </summary>
        public double scale = 1.0;

        /// <summary>
        /// An integer that records how many frames have been drawn. 
        /// The updateTick class field is updated on each UpdateGame method call.
        /// </summary>
        public int updateTick = 0;

        /// <summary>
        /// A class field used to store the current time in ms for passing time information to the update method.
        /// </summary>
        public long now;

        /// <summary>
        /// A class field used to store the previous time in ms for passing time information to the update method.
        /// </summary>
        public long prev;

        /// <summary>
        /// A Java rendering API font class used to draw debugging information like the FPS, VAR1, and VAR2 class fields.
        /// </summary>
        public SpriteFont debugFont;

        /// <summary>
        /// The Java rendering API color that is used to draw the game debugging information.
        /// </summary>
        public Color debugColor = Color.White;

        /// <summary>
        /// A place holder class field for storing the current font of the Java rendering API Pen class. 
        /// Used to hold the Pen's current font, then sets the Pen's font for drawing debug information, then restoring the Pen's previous font.
        /// </summary>
        public SpriteFont tmpF;

        /// <summary>
        /// An instance of the GameType enumeration that can be used to track if the game is a new game or a continuation of an existing game.
        /// </summary>
        public static GameType GAME_TYPE = GameType.GAME_NEW;

        /// <summary>
        /// An enumeration used to help track the type of game that was started.
        /// </summary>
        public enum GameType
        {
            GAME_NEW,
            GAME_CONTINUE,
            GAME_ONE_PLAYER,
            GAME_TWO_PLAYER,
            GAME_NETWORK_TWO_PLAYER,
            GAME_NETWORK_TWO_PLAYER_P1,
            GAME_NETWORK_TWO_PLAYER_P2,
            GAME_NETWORK_TWO_PLAYER_LEFT,
            GAME_NETWORK_TWO_PLAYER_RIGHT
        }

        /// <summary>
        /// A class field that tracks the last X position of the mouse during movement or dragging.
        /// </summary>
        public int lastX;

        /// <summary>
        /// A class field that tracks the last Y position of the mouse during movement or dragging.
        /// </summary>
        public int lastY;

        /// <summary>
        /// A class field that tracks the last time in ms that a key was pressed.
        /// </summary>
        public long lastKeyPressEvent = -1;

        /// <summary>
        /// A Java rendering API instance that is used to draw to the JFrame.
        /// </summary>
        public SpriteBatch bg;

        /// <summary>
        /// A Java rendering API instance that is used to draw the game screen to a buffered image.
        /// </summary>
        public SpriteBatch g;

        /// <summary>
        /// An instance of the ScreenSplash class that is used to draw the game's splash screen.
        /// </summary>
        public ScreenSplash screenSplash;

        /// <summary>
        /// An instance of the ScreenLoading class that is used to draw the game's loading screen.
        /// </summary>
        public ScreenLoading screenLoading;

        /// <summary>
        /// An instance of the ScreenMainMenu class that is used to draw the game's main menu screen.
        /// </summary>
        public ScreenMainMenu screenMainMenu;

        /// <summary>
        /// A class field that is used to add an offset into the mouse input X coordinate.
        /// </summary>
        public int mouseOffsetX = 0;

        /// <summary>
        /// A class field that is used to add an offset into the mouse input Y coordinate.
        /// </summary>
        public int mouseOffsetY = 0;

        /// <summary>
        /// A class field that initializes a static class that holds screen size and position data.
        /// </summary>
        public MmgScreenData screenData;

        /// <summary>
        /// A class field that initializes a static class the holds font creation and size data.
        /// </summary>
        public MmgFontData fontData;

        /// <summary>
        /// A GamePadHub instance used for processing USB gamepad input.
        /// </summary>
        public GamePadHub gamePadHub;

        /// <summary>
        /// A GamePadRunner instance used for polling gamepad input from the GamePadHub.
        /// </summary>
        public GamePadHubRunner gamePadRunner;

        /// <summary>
        /// A Thread used to process the USB gamepad input if threaded polling is enabled in the GameSettings class.
        /// </summary>
        public Thread gpadTr;

        /// <summary>
        /// A GpioPadHub instance used for processing GPIO gamepad input.
        /// </summary>
        public GpioHub gpioHub;

        /// <summary>
        /// A GpioPadRunner instance used for polling gamepad input from the GpioPadHub.
        /// </summary>
        public GpioHubRunner gpioRunner;

        /// <summary>
        /// A Thread used to process the GPIO gamepad input if threaded polling is enabled in the GameSettings class.
        /// </summary>
        public Thread gpioTr;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private MmgBmp sqrWhite = null;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private MmgBmp sqrBlack = null;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private Color DarkGray = new Color(64, 64, 64);

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private MmgFont mmgDebugFont = null;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private MmgBmp test = null;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private List<Keys> keysDown;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private List<string> buttonsDown;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private KeyboardState stateK;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private KeyboardState statePrevK;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private bool keyShiftDown = false;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private bool keyCapsLockOn = false;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private MouseState stateM;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private MouseState statePrevM;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="WinWidth"></param>
        /// <param name="WinHeight"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="GameWidth"></param>
        /// <param name="GameHeight"></param>
        public GamePanel(int WinWidth, int WinHeight, int X, int Y, int GameWidth, int GameHeight) : base()
        {
            keysDown = new List<Keys>();
            buttonsDown = new List<string>();
            gdm = new GraphicsDeviceManager(this);

            winWidth = WinWidth;
            winHeight = WinHeight;
            MmgApiGame.GAME_WIDTH = GameWidth;
            MmgApiGame.GAME_HEIGHT = GameHeight;
            sWinWidth = (int)(winWidth * scale);
            sWinHeight = (int)(winHeight * scale);

            MmgHelper.wr("GamePanel: WinWidth: " + WinWidth);
            MmgHelper.wr("GamePanel: WinHeight: " + WinHeight);
            MmgHelper.wr("GamePanel: GameWidth: " + GameWidth);
            MmgHelper.wr("GamePanel: GameHeight: " + GameHeight);

            myX = X;
            myY = Y;
            sMyX = myX + (winWidth - sWinWidth);
            sMyY = myY + (winHeight - sWinHeight);

            now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            prev = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            Exiting += windowClosing;
            Activated += windowActivated;
        }

        //NOTES: Added to the Monogame port to mimic the Java window closing implementation.
        /// <summary>
        /// TODO: Add comment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void windowActivated(object sender, EventArgs e)
        {
            canvas = Window;
            setSize(MmgApiGame.WIN_WIDTH, MmgApiGame.WIN_HEIGHT);
            setResizable(false);
            setVisible(true);
            setName(GameSettings.NAME);
        }

        //NOTES: Added to the Monogame port to mimic the Java window closing implementation.
        /// <summary>
        /// TODO: Add comment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void windowClosing(object sender, EventArgs e)
        {
            try
            {
                MmgHelper.wr("GamePanel: WindowClosing");
                GamePanel.PAUSE = true;
                GamePanel.EXIT = true;
                //RunFrameRate.PAUSE = true;
                //RunFrameRate.RUNNING = false;
                Dispose();
                Environment.Exit(0);
                //Environment.FailFast("0");
            }
            catch (Exception ex)
            {
                MmgHelper.wrErr(ex);
            }
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public void setSize(int w, int h)
        {
            gdm.PreferredBackBufferWidth = w;
            gdm.PreferredBackBufferHeight = h;
            gdm.ApplyChanges();            
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="b"></param>
        public void setResizable(bool b)
        {
            canvas.AllowUserResizing = b;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="n"></param>
        public void setName(string n)
        {
            name = n;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="b"></param>
        public void setVisible(bool b)
        {
            visible = b;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="s"></param>
        public void setTitle(string s)
        {
            canvas.Title = s;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        protected override void LoadContent()
        {
            MmgHelper.wr("===============LoadContent");

            MmgScreenData.GRAPHICS_CONFIG = gdm.GraphicsDevice;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            MmgScreenData.CONTENT_MANAGER = this.Content;
            graphics = new SpriteBatch(MmgScreenData.GRAPHICS_CONFIG);

            sqrWhite = MmgHelper.CreateFilledBmp(1, 1, MmgColor.GetWhite());
            sqrBlack = MmgHelper.CreateFilledBmp(1, 1, MmgColor.GetBlack());

            MmgHelper.wr("");
            MmgHelper.wr("GamePanel Window Width: " + winWidth);
            MmgHelper.wr("GamePanel Window Height: " + winHeight);
            MmgHelper.wr("GamePanel Offset X: " + myX);
            MmgHelper.wr("GamePanel Offset Y: " + myY);

            screenData = new MmgScreenData(winWidth, winHeight, MmgApiGame.GAME_WIDTH, MmgApiGame.GAME_HEIGHT);
            MmgHelper.wr("");
            MmgHelper.wr("--- MmgScreenData ---");
            MmgHelper.wr(MmgScreenData.toString());

            fontData = new MmgFontData();
            MmgHelper.wr("");
            MmgHelper.wr("--- MmgFontData ---");
            MmgHelper.wr(MmgFontData.toString());
            debugFont = MmgFontData.CreateDefaultFontSm();
            mmgDebugFont = new MmgFont(debugFont, "Test", 0, 0, MmgColor.GetWhite());

            MmgHelper.wr("FontHeight: " + mmgDebugFont.GetHeight() + ", " + MmgFontData.GetFontSize());

            p = new MmgPen();
            MmgPen.ADV_RENDER_HINTS = true;
            PrepBuffers();

            screenSplash = new ScreenSplash(GameStates.SPLASH, this);
            screenLoading = new ScreenLoading(GameStates.LOADING, this);
            screenMainMenu = new ScreenMainMenu(GameStates.MAIN_MENU, this);

            screenSplash.SetGenericEventHandler(this);
            screenLoading.SetGenericEventHandler(this);
            screenLoading.SetSlowDown(500);

            gameScreens = new Dictionary<GameStates, MmgGameScreen>();
            gameState = GameStates.BLANK;

            if (GameSettings.GAMEPAD_1_ON)
            {
                gamePadHub = new GamePadHub(GameSettings.GAMEPAD_1_INDEX);
                gamePadRunner = new GamePadHubRunner(gamePadHub, GameSettings.GAMEPAD_1_POLLING_INTERVAL_MS, this);
                if (GameSettings.GAMEPAD_1_THREADED_POLLING)
                {
                    ThreadStart ts = new ThreadStart(gamePadRunner.run);
                    gpadTr = new Thread(ts);
                    gpadTr.Start();
                }
            }

            if (GameSettings.GPIO_GAMEPAD_ON)
            {
                gpioHub = new GpioHub();
                gpioRunner = new GpioHubRunner(gpioHub, GameSettings.GPIO_GAMEPAD_POLLING_INTERVAL_MS, this);
                if (GameSettings.GPIO_GAMEPAD_THREADED_POLLING)
                {
                    ThreadStart ts = new ThreadStart(gpioRunner.run);
                    gpioTr = new Thread(ts);
                    gpioTr.Start();
                }
            }

            test = MmgHelper.GetBasicBmp(GameSettings.IMAGE_LOAD_DIR + "logo_large2.png");

            SwitchGameState(GameStates.SPLASH);
        }

        /// <summary>
        /// The ProcessDpadPress method is used to pass dpad press information from the GamePanel class down to the MmgGameScreen class implementation, currentScreen. 
        /// The dir code can come from different sources, keyboard, GPIO gamepad, or a USB game controller.
        /// </summary>
        /// <param name="dir">The dir argument is a code that represents which dpad direction was processed.</param>
        public virtual void ProcessDpadPress(int dir)
        {
            currentScreen.ProcessDpadPress(dir);
        }

        /// <summary>
        /// The ProcessDpadRelease method is used to pass dpad release information from the GamePanel class down to the MmgGameScreen class implementation, currentScreen. 
        /// The dir code can come from different sources, keyboard, GPIO gamepad, or a USB game controller.
        /// </summary>
        /// <param name="dir">The dir argument is a code that represents which dpad direction was processed.</param>
        public virtual void ProcessDpadRelease(int dir)
        {
            currentScreen.ProcessDpadRelease(dir);
        }

        /// <summary>
        /// The ProcessDpadClick method is used to pass dpad click information from the GamePanel class down to the MmgGameScreen class implementation, currentScreen. 
        /// The dir code can come from different sources, keyboard, GPIO gamepad, or a USB game controller.
        /// </summary>
        /// <param name="dir">The dir argument is a code that represents which dpad direction was processed.</param>
        public virtual void ProcessDpadClick(int dir)
        {
            currentScreen.ProcessDpadClick(dir);
        }

        /// <summary>
        /// The ProcessAPress method is used to pass A button press events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src">TODO: Add comment</param>
        public virtual void ProcessAPress(int src)
        {
            currentScreen.ProcessAPress(src);
        }

        /// <summary>
        /// The ProcessARelease method is used to pass A button release events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src">TODO: Add comment</param>
        public virtual void ProcessARelease(int src)
        {
            currentScreen.ProcessARelease(src);
        }

        /// <summary>
        /// The ProcessAClick method is used to pass A button click events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src">TODO: Add comment</param>
        public virtual void ProcessAClick(int src)
        {
            currentScreen.ProcessAClick(src);
        }

        /// <summary>
        /// The ProcessBPress method is used to pass B button press events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src">TODO: Add comment</param>
        public virtual void ProcessBPress(int src)
        {
            currentScreen.ProcessBPress(src);
        }

        /// <summary>
        /// The ProcessBRelease method is used to pass A button release events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src">TODO: Add comment</param>
        public virtual void ProcessBRelease(int src)
        {
            currentScreen.ProcessBRelease(src);
        }

        /// <summary>
        /// The ProcessBClick method is used to pass A button click events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src">TODO: Add comment</param>
        public virtual void ProcessBClick(int src)
        {
            currentScreen.ProcessBClick(src);
        }

        /// <summary>
        /// The ProcessDebugClick method is used to send debug click events to the MmgGameScreen class implementation, currentScreen.
        /// The event can be used to print screen specific information in response to the event.
        /// </summary>
        public virtual void ProcessDebugClick()
        {
            currentScreen.ProcessDebugClick();
        }

        /// <summary>
        /// The ProcessKeyPress method is used to send key press events to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="c">The c argument is the character of the keyboard press event.</param>
        /// <param name="code">TODO: Add comment</param>
        public virtual void ProcessKeyPress(char c, int code)
        {
            currentScreen.ProcessKeyPress(c, code);
        }

        /// <summary>
        /// The ProcessKeyRelease method is used to send key release events to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="c">The c argument is the character of the keyboard release event.</param>
        /// <param name="code">TODO: Add comment</param>
        public virtual void ProcessKeyRelease(char c, int code)
        {
            currentScreen.ProcessKeyRelease(c, code);
        }

        /// <summary>
        /// The ProcessKeyClick method is used to send key click events to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="c">The c argument is the character of the keyboard click event.</param>
        /// <param name="code">TODO: Add comment</param>
        public virtual void ProcessKeyClick(char c, int code)
        {
            currentScreen.ProcessKeyClick(c, code);
        }

        /// <summary>
        /// The ProcessMouseMove method is used to send mouse move information to the MmgGameScreen class implementation, currentScreen.
        /// The coordinates are automatically adjusted to the offset of the game screen within the game panel.An optional mouseOffset is applied
        /// to the mouse X, Y coordinates.
        /// </summary>
        /// <param name="x">The x argument is the X position of the mouse as received from the mouse listener.</param>
        /// <param name="y">The y argument is the Y position of the mouse as received from the mouse listener.</param>
        public virtual void ProcessMouseMove(int x, int y)
        {
            currentScreen.ProcessMouseMove((x - mouseOffsetX - myX), (y - mouseOffsetY - myY));
        }

        /// <summary>
        /// The ProcessMousePress method is used to send mouse press information to the MmgGameScreen class implementation, currentScreen.
        /// The coordinates are automatically adjusted to the offset of the game screen within the game panel.An optional mouseOffset is applied
        /// to the mouse X, Y coordinates.
        /// </summary>
        /// <param name="x">The x argument is the X position of the mouse as received from the mouse listener.</param>
        /// <param name="y">The y argument is the Y position of the mouse as received from the mouse listener.</param>
        public virtual void ProcessMousePress(int x, int y)
        {
            currentScreen.ProcessMousePress((x - mouseOffsetX - myX), (y - mouseOffsetY - myY));
        }

        /// <summary>
        /// The ProcessMouseRelease method is used to send mouse release information to the MmgGameScreen class implementation, currentScreen.
        /// The coordinates are automatically adjusted to the offset of the game screen within the game panel.An optional mouseOffset is applied
        /// to the mouse X, Y coordinates.
        /// </summary>
        /// <param name="x">The x argument is the X position of the mouse as received from the mouse listener.</param>
        /// <param name="y">The y argument is the Y position of the mouse as received from the mouse listener.</param>
        public virtual void ProcessMouseRelease(int x, int y)
        {
            currentScreen.ProcessMouseRelease((x - mouseOffsetX - myX), (y - mouseOffsetY - myY));
        }

        /// <summary>
        /// The ProcessMouseClick method is used to send mouse click information to the MmgGameScreen class implementation, currentScreen.
        /// The coordinates are automatically adjusted to the offset of the game screen within the game panel.An optional mouseOffset is applied
        /// to the mouse X, Y coordinates.
        /// </summary>
        /// <param name="x">The x argument is the X position of the mouse as received from the mouse listener.</param>
        /// <param name="y">The y argument is the Y position of the mouse as received from the mouse listener.</param>
        public virtual void ProcessMouseClick(int x, int y)
        {
            currentScreen.ProcessMouseClick((x - mouseOffsetX - myX), (y - mouseOffsetY - myY));
        }

        /// <summary>
        /// The PrepBuffers method is used to create a new buffered image, background. It also sets the canvas
        /// buffer strategy to use double buffering.The drawing strategy is stored in the strategy class field.
        /// Lastly the backgroundGraphics class field is set from the background buffered image.
        /// </summary>
        public virtual void PrepBuffers()
        {
            // Background & Buffer
            background = create(winWidth, winHeight, false);
            backgroundGraphics = new SpriteBatch(MmgScreenData.GRAPHICS_CONFIG);
            MmgScreenData.GRAPHICS_CONFIG.SetRenderTarget(background);
            p.SetGraphics(backgroundGraphics);
            p.SetAdvRenderHints();
        }

        /// <summary>
        /// Create a BufferedImage using the default screen device and configuration.
        /// </summary>
        /// <param name="width">The desired width of the BufferedImage.</param>
        /// <param name="height">The desired height of the BufferedImage.</param>
        /// <param name="alpha">The desired transparency flag of the BufferedImage.</param>
        /// <returns>Returns a BufferedImage with the desired coordinates and transparency. </returns>
        public virtual RenderTarget2D create(int width, int height, bool alpha)
        {
            return new RenderTarget2D(MmgScreenData.GRAPHICS_CONFIG, width, height);
        }

        /// <summary>
        /// Gets the game screen Dictionary.
        /// </summary>
        /// <returns>A Dictionary of game screens, MmgGameScreen.</returns>
        public virtual Dictionary<GameStates, MmgGameScreen> GetGameScreens()
        {
            return gameScreens;
        }

        /// <summary>
        /// Sets the game screen Dictionary.
        /// </summary>
        /// <param name="GameScreens">A Dictionary of game screens, MmgGameScreen.</param>
        public virtual void SetGameScreens(Dictionary<GameStates, MmgGameScreen> GameScreens)
        {
            gameScreens = GameScreens;
        }

        /// <summary>
        /// Gets the Canvas instance for drawing on the JFrame.
        /// </summary>
        /// <returns>The Canvas class instance for drawing on the JFrame.</returns>
        public virtual GameWindow GetCanvas()
        {
            return base.Window;
        }

        /// <summary>
        /// Gets the current game screen.
        /// </summary>
        /// <returns>A game screen object, MmgGameScreen.</returns>
        public virtual MmgGameScreen GetCurrentScreen()
        {
            return currentScreen;
        }

        /// <summary>
        /// Sets the current game screen.
        /// </summary>
        /// <param name="CurrentScreen">A game screen object.</param>
        public virtual void SetCurrentScreen(MmgGameScreen CurrentScreen)
        {
            currentScreen = CurrentScreen;
        }

        /// <summary>
        /// Switches the current game state, cleans up the current state, then loads
        /// up the next state.Currently does not use the gameScreens hash table.
        /// Uses direct references instead, for now.
        /// </summary>
        /// <param name="g">The game state to switch to.</param>
        public virtual void SwitchGameState(GameStates g)
        {
            MmgHelper.wr("GamePanel: Switching Game State To: " + g);

            if (gameState != prevGameState)
            {
                prevGameState = gameState;
            }

            if (g != gameState)
            {
                gameState = g;
            }
            else
            {
                return;
            }

            //unload
            if (prevGameState == GameStates.BLANK)
            {
                MmgHelper.wr("Hiding BLANK screen.");

            }
            else if (prevGameState == GameStates.LOADING)
            {
                MmgHelper.wr("Hiding LOADING screen.");
                screenLoading.Pause();
                screenLoading.SetIsVisible(false);
                screenLoading.UnloadResources();
                MmgHelper.wr("Hiding LOADING screen DONE.");

            }
            else if (prevGameState == GameStates.SPLASH)
            {
                MmgHelper.wr("Hiding SPLASH screen.");
                screenSplash.Pause();
                screenSplash.SetIsVisible(false);
                screenSplash.UnloadResources();

            }
            else if (prevGameState == GameStates.MAIN_MENU)
            {
                MmgHelper.wr("Hiding MAIN_MENU screen.");
                //mainMenuScreen.Pause();
                //mainMenuScreen.SetIsVisible(false);
                //mainMenuScreen.UnloadResources();

            }
            else if (prevGameState == GameStates.ABOUT)
            {
                MmgHelper.wr("Hiding ABOUT screen.");
                //aboutScreen.Pause();
                //aboutScreen.SetIsVisible(false);
                //aboutScreen.UnloadResources();

            }
            else if (prevGameState == GameStates.HELP_MENU)
            {
                MmgHelper.wr("Hiding HELP screen.");
                //helpScreen.Pause();
                //helpScreen.SetIsVisible(false);
                //helpScreen.UnloadResources();

            }
            else if (prevGameState == GameStates.MAIN_GAME)
            {
                MmgHelper.wr("Hiding MAIN GAME screen.");
                screenMainMenu.Pause();
                screenMainMenu.SetIsVisible(false);
                screenMainMenu.UnloadResources();

            }
            else if (prevGameState == GameStates.SETTINGS)
            {
                MmgHelper.wr("Hiding SETTINGS screen.");
                //settingsScreen.Pause();
                //settingsScreen.SetIsVisible(false);
                //settingsScreen.UnloadResources();

            }

            //load
            MmgHelper.wr("Switching Game State To: " + gameState);
            if (gameState == GameStates.BLANK)
            {
                MmgHelper.wr("Showing BLANK screen.");

            }
            else if (gameState == GameStates.LOADING)
            {
                MmgHelper.wr("Showing LOADING screen.");
                screenLoading.LoadResources();
                screenLoading.UnPause();
                screenLoading.SetIsVisible(true);
                screenLoading.StartDatLoad();
                currentScreen = screenLoading;

            }
            else if (gameState == GameStates.SPLASH)
            {
                MmgHelper.wr("Showing SPLASH screen.");
                screenSplash.LoadResources();
                screenSplash.UnPause();
                screenSplash.SetIsVisible(true);
                screenSplash.StartDisplay();
                currentScreen = screenSplash;

            }
            else if (gameState == GameStates.MAIN_MENU)
            {
                MmgHelper.wr("Showing MAIN_MENU screen.");
                screenMainMenu.LoadResources();
                screenMainMenu.UnPause();
                screenMainMenu.SetIsVisible(true);
                currentScreen = screenMainMenu;

            }
            else if (gameState == GameStates.ABOUT)
            {
                MmgHelper.wr("Showing ABOUT screen.");
                //aboutScreen.LoadResources();
                //aboutScreen.UnPause();
                //aboutScreen.SetIsVisible(true);
                //currentScreen = aboutScreen;

            }
            else if (gameState == GameStates.HELP_MENU)
            {
                MmgHelper.wr("Showing HELP screen.");
                //helpScreen.LoadResources();
                //helpScreen.UnPause();
                //helpScreen.SetIsVisible(true);
                //currentScreen = helpScreen;

            }
            else if (gameState == GameStates.MAIN_GAME)
            {
                MmgHelper.wr("Showing MAIN GAME screen.");
                //mainGameScreen.LoadResources();
                //mainGameScreen.UnPause();
                //mainGameScreen.SetIsVisible(true);
                //currentScreen = mainGameScreen;

            }
            else if (gameState == GameStates.SETTINGS)
            {
                MmgHelper.wr("Showing SETTINGS screen.");
                //settingsScreen.LoadResources();
                //settingsScreen.UnPause();
                //settingsScreen.SetIsVisible(true);
                //currentScreen = settingsScreen;

            }
        }

        /// <summary>
        /// A generic event, GenericEventHandler, callback method. Used to handle
        /// generic events from certain game screens, MmgGameScreen.
        /// </summary>
        /// <param name="obj">A GenericEventMessage instance that has information about the generic event that was fired.</param>
        public virtual void HandleGenericEvent(GenericEventMessage obj)
        {
            MmgHelper.wr("GamePanel: HandleGenericEvent");
            if (obj != null)
            {
                if (obj.GetGameState() == GameStates.LOADING)
                {
                    if (obj.GetId() == ScreenLoading.EVENT_LOAD_COMPLETE)
                    {
                        //Final loading steps
                        DatExternalStrings.LOAD_EXT_STRINGS();
                        MmgHelper.wr("HandleMainMenuEvent: MmgHandleEvent: Switch to MainMenu.");
                        SwitchGameState(GameStates.MAIN_MENU);
                    }

                }
                else if (obj.GetGameState() == GameStates.SPLASH)
                {
                    if (obj.GetId() == ScreenSplash.EVENT_DISPLAY_COMPLETE)
                    {
                        SwitchGameState(GameStates.LOADING);
                    }
                }
            }
        }

        /// <summary>
        /// Returns a Graphics2D instance that is based on the default screen configuration used for drawing on the JFrame.
        /// </summary>
        /// <returns>A Graphics2D instance that is used to draw on the JFrame.</returns>
        public virtual SpriteBatch GetBuffer()
        {
            return graphics;
        }

        /// <summary>
        /// Returns the application window width.
        /// </summary>
        /// <returns>The application window width.</returns>
        public virtual int GetWinWidth()
        {
            return winWidth;
        }

        /// <summary>
        /// Returns the application window height.
        /// </summary>
        /// <returns>The application window height.</returns>
        public virtual int GetWinHeight()
        {
            return winHeight;
        }

        /// <summary>
        /// Returns the X offset of the GamePanel in the JFrame window.
        /// </summary>
        /// <returns>The X offset of the GamePanel in the JFrame window.</returns>
        public virtual int GetX()
        {
            return myX;
        }

        /// <summary>
        /// Returns the Y offset of the GamePanel in the JFrame window.
        /// </summary>
        /// <returns>The Y offset of the GamePanel in the JFrame window.</returns>
        public virtual int GetY()
        {
            return myY;
        }

        /// <summary>
        /// Updates the Java rendering API Graphics2D instances with the current Canvas buffer.
        /// Resetting the graphics class field and syncing the Canvas drawing strategy is necessary with
        /// a double buffered implementation.
        ///
        /// @return      A bool indicating if the method call was successful.Returns true in the case of a sync exception.
        /// </summary>
        /// <returns></returns>
        public virtual bool UpdateScreen()
        {
            //NOTES: Monogame port doesn't need this function but it is included for compatability with the Java version.
            return true;
        }

        /// <summary>
        /// TODO: Add comment
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            if(EXIT == true)
            {
                Exit();
            }
            else if (PAUSE == true)
            {
                return;
            }

            UpdateGame();
            base.Update(gameTime);
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool HasKeyBeenClicked(Keys key, KeyboardState state)
        {
            if (state.IsKeyDown(key))
            {
                //key down
                if (!keysDown.Contains(key))
                {
                    keysDown.Add(key);
                }
                return false;
            }
            else
            {
                //key up
                if (keysDown.Contains(key))
                {
                    keysDown.Remove(key);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="bState"></param>
        /// <param name="mState"></param>
        /// <returns></returns>
        private bool HasButtonBeenClicked(ButtonState bState, MouseState mState, string key)
        {
            if (bState == ButtonState.Pressed)
            {
                //button down
                if (!buttonsDown.Contains(key))
                {
                    buttonsDown.Add(key);
                }
                return false;
            }
            else
            {
                //button up
                if (buttonsDown.Contains(key))
                {
                    buttonsDown.Remove(key);
                }
                return true;
            }
        }

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        private char ConvertKeyToChar(Keys k)
        {
            if(k == Keys.A)
            {
                if(keyShiftDown || keyCapsLockOn)
                {
                    return 'A';
                }
                else
                {
                    return 'a';
                }
            }
            else if (k == Keys.Add)
            {
                return '+';
            }
            else if(k == Keys.Apps)
            {
                return (char)((byte)93);
            }
            else if(k == Keys.B)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'B';
                }
                else
                {
                    return 'b';
                }
            }
            else if(k == Keys.Back)
            {
                return (char)((byte)8);
            }
            else if(k == Keys.C)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'C';
                }
                else
                {
                    return 'c';
                }
            }
            else if(k == Keys.CapsLock)
            {
                return (char)((byte)20);
            }
            else if(k == Keys.D)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'D';
                }
                else
                {
                    return 'd';
                }
            }
            else if(k == Keys.Decimal)
            {
                return '.';
            }
            else if(k == Keys.Delete)
            {
                return (char)((byte)46);
            }
            else if(k == Keys.Divide)
            {
                return '/';
            }
            else if(k == Keys.Down)
            {
                return (char)((byte)40);
            }
            else if(k == Keys.E)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'E';
                }
                else
                {
                    return 'e';
                }
            }
            else if(k == Keys.End)
            {
                return (char)((byte)35);
            }
            else if(k == Keys.Enter)
            {
                return '\n';
            }
            else if(k == Keys.Escape)
            {
                return (char)((byte)27);
            }
            else if(k == Keys.F)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'F';
                }
                else
                {
                    return 'f';
                }
            }
            else if(k == Keys.F1)
            {
                return (char)((byte)112);
            }
            else if(k == Keys.F2)
            {
                return (char)((byte)113);
            }
            else if (k == Keys.F3)
            {
                return (char)((byte)114);
            }
            else if (k == Keys.F4)
            {
                return (char)((byte)115);
            }
            else if (k == Keys.F5)
            {
                return (char)((byte)116);
            }
            else if (k == Keys.F6)
            {
                return (char)((byte)117);
            }
            else if (k == Keys.F7)
            {
                return (char)((byte)118);
            }
            else if (k == Keys.F8)
            {
                return (char)((byte)119);
            }
            else if (k == Keys.F9)
            {
                return (char)((byte)120);
            }
            else if (k == Keys.F10)
            {
                return (char)((byte)121);
            }
            else if (k == Keys.F11)
            {
                return (char)((byte)122);
            }
            else if (k == Keys.F12)
            {
                return (char)((byte)123);
            }
            else if(k == Keys.G)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'G';
                }
                else
                {
                    return 'g';
                }
            }
            else if(k == Keys.H)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'H';
                }
                else
                {
                    return 'h';
                }
            }
            else if(k == Keys.Home)
            {
                return (char)((byte)36);
            }
            else if(k == Keys.I)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'I';
                }
                else
                {
                    return 'i';
                }
            }
            else if (k == Keys.Insert)
            {
                return (char)((byte)45);
            }
            else if(k == Keys.J)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'J';
                }
                else
                {
                    return 'j';
                }
            }
            else if(k == Keys.K)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'K';
                }
                else
                {
                    return 'k';
                }
            }
            else if(k == Keys.L)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'L';
                }
                else
                {
                    return 'l';
                }
            }
            else if(k == Keys.Left)
            {
                return (char)((byte)37);
            }
            else if(k == Keys.LeftAlt)
            {
                return (char)((byte)164);
            }
            else if(k == Keys.LeftControl)
            {
                return (char)((byte)162);
            }
            else if(k == Keys.LeftWindows)
            {
                return (char)((byte)91);
            }
            else if(k == Keys.M)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'M';
                }
                else
                {
                    return 'm';
                }
            }
            else if(k == Keys.Multiply)
            {
                return '*';
            }
            else if(k == Keys.N)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'N';
                }
                else
                {
                    return 'n';
                }
            }
            else if(k == Keys.NumLock)
            {
                return (char)((byte)144);
            }
            else if(k == Keys.NumPad0)
            {
                return '0';
            }
            else if (k == Keys.NumPad1)
            {
                return '1';
            }
            else if (k == Keys.NumPad2)
            {
                return '2';
            }
            else if (k == Keys.NumPad3)
            {
                return '3';
            }
            else if (k == Keys.NumPad4)
            {
                return '4';
            }
            else if (k == Keys.NumPad5)
            {
                return '5';
            }
            else if (k == Keys.NumPad6)
            {
                return '6';
            }
            else if (k == Keys.NumPad7)
            {
                return '7';
            }
            else if (k == Keys.NumPad8)
            {
                return '8';
            }
            else if (k == Keys.NumPad9)
            {
                return '9';
            }
            else if(k == Keys.O)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'O';
                }
                else
                {
                    return 'o';
                }
            }
            else if(k == Keys.P)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'P';
                }
                else
                {
                    return 'p';
                }
            }
            else if(k == Keys.PageDown)
            {
                return (char)((byte)34);
            }
            else if(k == Keys.PageUp)
            {
                return (char)((byte)33);
            }
            else if(k == Keys.Pause)
            {
                return (char)((byte)19);
            }
            else if(k == Keys.PrintScreen)
            {
                return (char)((byte)44);
            }
            else if(k == Keys.Q)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'Q';
                }
                else
                {
                    return 'q';
                }
            }
            else if(k == Keys.R)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'R';
                }
                else
                {
                    return 'r';
                }
            }
            else if(k == Keys.Right)
            {
                return (char)((byte)39);
            }
            else if(k == Keys.RightAlt)
            {
                return (char)((byte)165);
            }
            else if(k == Keys.RightControl)
            {
                return (char)((byte)163);
            }
            else if(k == Keys.RightWindows)
            {
                return (char)((byte)92);
            }
            else if(k == Keys.S)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'S';
                }
                else
                {
                    return 's';
                }
            }
            else if(k == Keys.Scroll)
            {
                return (char)((byte)145);
            }
            else if(k == Keys.Space)
            {
                return ' ';
            }
            else if(k == Keys.Subtract)
            {
                return '-';
            }
            else if(k == Keys.T)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'T';
                }
                else
                {
                    return 't';
                }
            }
            else if(k == Keys.Tab)
            {
                return (char)((byte)9);
            }
            else if(k == Keys.U)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'U';
                }
                else
                {
                    return 'u';
                }
            }
            else if(k == Keys.Up)
            {
                return (char)((byte)38);
            }
            else if(k == Keys.V)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'V';
                }
                else
                {
                    return 'v';
                }
            }
            else if(k == Keys.W)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'W';
                }
                else
                {
                    return 'w';
                }
            }
            else if (k == Keys.X)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'X';
                }
                else
                {
                    return 'x';
                }
            }
            else if (k == Keys.Y)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'Y';
                }
                else
                {
                    return 'y';
                }
            }
            else if (k == Keys.Z)
            {
                if (keyShiftDown || keyCapsLockOn)
                {
                    return 'Z';
                }
                else
                {
                    return 'z';
                }
            }
            else if (k == Keys.Insert)
            {
                return (char)((byte)45);
            }
            else if (k == Keys.Delete)
            {
                return (char)((byte)46);
            }

            return '_';
        }

        /// <summary>
        /// TODO: Add comment
        /// </summary>
        private void ProcessAllPlayer1Input()
        {
            statePrevM = stateM;
            stateM = Mouse.GetState();

            //handle mouse drag
            if (stateM.LeftButton == ButtonState.Pressed && statePrevM.LeftButton == ButtonState.Pressed)
            {
                lastX = stateM.X;
                lastY = stateM.Y;
            }

            if (stateM.X != statePrevM.X || stateM.Y != statePrevM.Y)
            {
                lastX = stateM.X;
                lastY = stateM.Y;
                ProcessMouseMove(lastX, lastY);
            }

            //handle key typed
            statePrevK = stateK;
            stateK = Keyboard.GetState();
            if (HasKeyBeenClicked(Keys.Space, stateK) || HasKeyBeenClicked(Keys.Enter, stateK))
            {
                ProcessAClick(GameSettings.SRC_KEYBOARD);
            }
            else if (HasKeyBeenClicked(Keys.Add, stateK))
            {
                //increase speed
            }
            else if (HasKeyBeenClicked(Keys.Subtract, stateK))
            {
                //decrease speed
            }
            else if (HasKeyBeenClicked(Keys.P, stateK))
            {
                if (gameState == GameStates.MAIN_GAME)
                {
                    //pause game
                }
            }
            else if (HasKeyBeenClicked(Keys.F, stateK))
            {
                //clear game flags
            }
            else if (HasKeyBeenClicked(Keys.A, stateK))
            {
                ProcessAClick(GameSettings.SRC_KEYBOARD);
            }
            else if (HasKeyBeenClicked(Keys.B, stateK))
            {
                ProcessBClick(GameSettings.SRC_KEYBOARD);
            }
            else if (HasKeyBeenClicked(Keys.D, stateK))
            {
                ProcessDebugClick();
            }

            if(HasKeyBeenClicked(Keys.CapsLock, stateK))
            {
                keyCapsLockOn = !keyCapsLockOn;
            }

            if(stateK.IsKeyDown(Keys.LeftShift) || stateK.IsKeyDown(Keys.RightShift))
            {
                keyShiftDown = true;
            }
            else if(stateK.IsKeyUp(Keys.LeftShift) && stateK.IsKeyUp(Keys.RightShift))
            {
                keyShiftDown = false;
            }

            //handle key pressed
            if(stateK.GetPressedKeyCount() > 0)
            {
                lastKeyPressEvent = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            }

            if(stateK.IsKeyDown(Keys.Down))
            {
                ProcessDpadPress(GameSettings.DOWN_KEYBOARD);
            }
            else if (stateK.IsKeyDown(Keys.Up))
            {
                ProcessDpadPress(GameSettings.UP_KEYBOARD);
            }
            else if(stateK.IsKeyDown(Keys.Left))
            {
                ProcessDpadPress(GameSettings.LEFT_KEYBOARD);
            }
            else if(stateK.IsKeyDown(Keys.Right))
            {
                ProcessDpadPress(GameSettings.RIGHT_KEYBOARD);
            }
            else if(stateK.IsKeyDown(Keys.A))
            {
                ProcessAPress(GameSettings.SRC_KEYBOARD);
            }
            else if (stateK.IsKeyDown(Keys.B))
            {
                ProcessBPress(GameSettings.SRC_KEYBOARD);
            }

            //handle key released
            //MmgHelper.wr("handle key released");
            if (HasKeyBeenClicked(Keys.Down, stateK))
            {
                ProcessDpadRelease(GameSettings.DOWN_KEYBOARD);
                ProcessDpadClick(GameSettings.DOWN_KEYBOARD);
                //MmgHelper.wr("dpad down release click");
            }
            else if (HasKeyBeenClicked(Keys.Up, stateK))
            {
                ProcessDpadRelease(GameSettings.UP_KEYBOARD);
                ProcessDpadClick(GameSettings.UP_KEYBOARD);
            }
            else if (HasKeyBeenClicked(Keys.Left, stateK))
            {
                ProcessDpadRelease(GameSettings.LEFT_KEYBOARD);
                ProcessDpadClick(GameSettings.LEFT_KEYBOARD);
            }
            else if (HasKeyBeenClicked(Keys.Right, stateK))
            {
                ProcessDpadRelease(GameSettings.RIGHT_KEYBOARD);
                ProcessDpadClick(GameSettings.RIGHT_KEYBOARD);
            }
            else if (HasKeyBeenClicked(Keys.A, stateK))
            {
                ProcessARelease(GameSettings.SRC_KEYBOARD);
                ProcessAClick(GameSettings.SRC_KEYBOARD);
            }
            else if (HasKeyBeenClicked(Keys.B, stateK))
            {
                ProcessBRelease(GameSettings.SRC_KEYBOARD);
                ProcessBClick(GameSettings.SRC_KEYBOARD);
            }

            char c;
            foreach (Keys k in stateK.GetPressedKeys())
            {
                c = ConvertKeyToChar(k);

                if (k != Keys.Space && k != Keys.Enter)
                {
                    ProcessKeyPress(c, (int)c);
                }
                //MmgHelper.wr("Key: '" + c + "' Code: '" + (int)c + "' Keys: '" + k.ToString() + " has been pressed.");
            }

            foreach(Keys k in keysDown)
            {
                c = ConvertKeyToChar(k);

                if (HasKeyBeenClicked(k, stateK))
                {
                    ProcessKeyRelease(c, (int)c);
                    //MmgHelper.wr("Key: '" + c + "' Code: '" + (int)c + "' has been released.");

                    ProcessKeyClick(c, (int)c);
                    //MmgHelper.wr("Key: '" + c + "' Code: '" + (int)c + "' has been clicked.");
                }
            }

            if(stateM.LeftButton == ButtonState.Pressed)
            {
                ProcessMousePress(stateM.X, stateM.Y);
            }

            if(HasButtonBeenClicked(stateM.LeftButton, stateM, "LeftButton"))
            {
                ProcessMouseRelease(stateM.X, stateM.Y);
                ProcessMouseClick(stateM.X, stateM.Y);
            }

            if (HasButtonBeenClicked(stateM.MiddleButton, stateM, "MiddleButton"))
            {
                ProcessMouseRelease(stateM.X, stateM.Y);
                ProcessMouseClick(stateM.X, stateM.Y);
            }

            if (HasButtonBeenClicked(stateM.RightButton, stateM, "RightButton"))
            {
                ProcessMouseRelease(stateM.X, stateM.Y);
                ProcessMouseClick(stateM.X, stateM.Y);
            }

            //MmgHelper.wr("Mouse: LastX: '" + lastX + "' LastY: '" + lastY + "'");
        }

        /// <summary>
        /// TODO: Add comment
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            if(EXIT == true)
            {
                return;
            }

            GraphicsDevice.Clear(Color.CornflowerBlue);
            RenderGame();            
            base.Draw(gameTime);
        }

        /// <summary>
        /// The UpdateGame method is used to call the lower level MmgUpdate method of the MmgGameScreen class, currentScreen.
        /// Send the update call count, the current time, and the time difference between this frame and the last frame.
        /// </summary>
        public virtual void UpdateGame()
        {
            updateTick++;

            if (PAUSE == true || EXIT == true)
            {
                //do nothing
                return;
            }

            prev = now;
            now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            if (GameSettings.GAMEPAD_1_ON && GameSettings.GAMEPAD_1_THREADED_POLLING == false)
            {
                gamePadRunner.PollGamePad();
            }

            if (GameSettings.GPIO_GAMEPAD_ON && GameSettings.GPIO_GAMEPAD_THREADED_POLLING == false)
            {
                gpioRunner.PollGpio();
            }

            ProcessAllPlayer1Input();

            // update game logic here
            if (currentScreen != null)
            {
                currentScreen.MmgUpdate(updateTick, now, (now - prev));
            }
        }

        /// <summary>
        /// The RenderGame method is used to draw the entire JFrame Canvas, the debug frame rate, the debug variables, and the game screen.
        /// </summary>
        public virtual void RenderGame()
        {
            if (visible == false)
            {
                return;
            }
            
            if (EXIT == true)
            {
                return;
            }

            //update graphics
            bg = GetBuffer();
            g = backgroundGraphics;

            if (currentScreen == null || currentScreen.IsPaused() == true || currentScreen.IsReady() == false)
            {
                //do nothing
            }
            else
            {
                g.GraphicsDevice.SetRenderTarget(background);
                p.SetGraphics(g);
                p.SetAdvRenderHints();

                g.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);

                //clear background
                g.GraphicsDevice.Clear(DarkGray);
                g.Draw(sqrWhite.GetImage(), new Rectangle(MmgScreenData.GetGameLeft() - 1, MmgScreenData.GetGameTop() - 1, MmgScreenData.GetGameWidth() + 2, MmgScreenData.GetGameHeight() + 2), new Rectangle(0, 0, sqrWhite.GetWidth(), sqrWhite.GetHeight()), Color.White);
                g.Draw(sqrBlack.GetImage(), new Rectangle(MmgScreenData.GetGameLeft(), MmgScreenData.GetGameTop(), MmgScreenData.GetGameWidth(), MmgScreenData.GetGameHeight()), new Rectangle(0, 0, sqrBlack.GetWidth(), sqrBlack.GetHeight()), Color.White);

                currentScreen.MmgDraw(p);
                
                if (MmgHelper.LOGGING == true)
                {
                    g.DrawString(debugFont, GamePanel.FPS, new Vector2(15, 15 - mmgDebugFont.GetHeight() + 2), Color.White);
                    g.DrawString(debugFont, "Var1: " + GamePanel.VAR1, new Vector2(15, 35 - mmgDebugFont.GetHeight() + 2), Color.White);
                    g.DrawString(debugFont, "Var2: " + GamePanel.VAR2, new Vector2(15, 55 - mmgDebugFont.GetHeight() + 2), Color.White);
                }

                g.End();
                g.GraphicsDevice.SetRenderTarget(null);
            }
            
            bg.GraphicsDevice.SetRenderTarget(null);
            p.SetGraphics(bg);
            p.SetAdvRenderHints();

            bg.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
            //draws a scaled version of the state of the background buffer to the screen buffer if scaling is enabled
            if (scale != 1.0)
            {
                bg.Draw(background, new Rectangle(sMyX, sMyY, sWinWidth, sWinHeight), new Rectangle(0, 0, winWidth, winHeight), Color.White);
            }
            else
            {
                bg.Draw(background, new Vector2(myX, myY), Color.White);
                //bg.Draw(test.GetImage(), Vector2.One, Color.White);
            }
            bg.End();

            UpdateScreen();
        }
    }
}