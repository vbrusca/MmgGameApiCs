using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// The Canvas used to render the game to. 
    /// This is the connection point between native UI rendering and the game rendering.
    /// Created by Middlemind Games 08/01/2015
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class GamePanel : GenericEventHandler, GamePadSimple
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
            GAME_SCREEN_30
        }

        /// <summary>
        /// The MainFrame that this panel is displayed in.
        /// </summary>
        public MainFrame mf;

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
        public Canvas canvas;

        /// <summary>
        /// A Java rendering API drawing strategy class.
        /// </summary>
        public BufferStrategy strategy;

        /// <summary>
        /// A BufferedImage used to render the game screen to. 
        /// The background image is then rendered to the panel once it is done drawing.
        /// </summary>
        public Texture2D background;

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
        /// Constructor, sets the MainFrame, window dimensions, and position of this Canvas.
        /// </summary>
        /// <param name="Mf">The MainFrame class this panel belongs to.</param>
        /// <param name="WinWidth">The target window width.</param>
        /// <param name="WinHeight">The target window height.</param>
        /// <param name="X">The X coordinate of this Canvas.</param>
        /// <param name="Y">The Y coordinate of this Canvas.</param>
        /// <param name="GameWidth">TODO: Add comments</param>
        /// <param name="GameHeight"></param>
        public GamePanel(MainFrame Mf, int WinWidth, int WinHeight, int X, int Y, int GameWidth, int GameHeight)
        {
            mf = Mf;
            winWidth = WinWidth;
            winHeight = WinHeight;
            GamePanel.GAME_WIDTH = GameWidth;
            GamePanel.GAME_HEIGHT = GameHeight;
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

            //canvas = new Canvas(MmgBmpScaler.GRAPHICS_CONFIG);
            //canvas.setSize(winWidth, winHeight);

            MmgHelper.wr("");
            MmgHelper.wr("GamePanel Window Width: " + winWidth);
            MmgHelper.wr("GamePanel Window Height: " + winHeight);
            MmgHelper.wr("GamePanel Offset X: " + myX);
            MmgHelper.wr("GamePanel Offset Y: " + myY);

            screenData = new MmgScreenData(winWidth, winHeight, GamePanel.GAME_WIDTH, GamePanel.GAME_HEIGHT);
            MmgHelper.wr("");
            MmgHelper.wr("--- MmgScreenData ---");
            MmgHelper.wr(MmgScreenData.toString());

            fontData = new MmgFontData();
            MmgHelper.wr("");
            MmgHelper.wr("--- MmgFontData ---");
            MmgHelper.wr(MmgFontData.toString());
            debugFont = MmgFontData.CreateDefaultFontSm();

            p = new MmgPen();
            MmgPen.ADV_RENDER_HINTS = true;

            screenSplash = new ScreenSplash(GameStates.SPLASH, this);
            screenLoading = new ScreenLoading(GameStates.LOADING, this);
            screenMainMenu = new ScreenMainMenu(GameStates.MAIN_MENU, this);

            screenSplash.SetGenericEventHandler(this);
            screenLoading.SetGenericEventHandler(this);
            screenLoading.SetSlowDown(500);

            gameScreens = new Dictionary<GameStates, MmgGameScreen>();
            gameState = GameStates.BLANK;

            /*
            canvas.addMouseMotionListener(new MouseMotionListener() {
                @Override
                public void mouseDragged(MouseEvent e)
                {
                    lastX = e.getX();
                    lastY = e.getY();
                }

                @Override
                    public void mouseMoved(MouseEvent e)
                {
                    lastX = e.getX();
                    lastY = e.getY();
                    ProcessMouseMove(lastX, lastY);
                }

            });

            canvas.addKeyListener(new KeyListener()
            {
                @Override
                    public void keyTyped(KeyEvent e)
                {
                    if (e.getKeyChar() == ' ' || e.getKeyChar() == '\n')
                    {
                        ProcessAClick(GameSettings.SRC_KEYBOARD);

                    }
                    else if (e.getKeyChar() == '+')
                    {
                        //increase speed

                    }
                    else if (e.getKeyChar() == '-')
                    {
                        //decrease speed

                    }
                    else if (e.getKeyChar() == 'p' || e.getKeyChar() == 'P')
                    {
                        if (gameState == GameStates.MAIN_GAME)
                        {
                            //pause game
                        }

                    }
                    else if (e.getKeyChar() == 'f' || e.getKeyChar() == 'F')
                    {
                        //clear game flags

                    }
                    else if (e.getKeyChar() == 'a' || e.getKeyChar() == 'A')
                    {
                        ProcessAClick(GameSettings.SRC_KEYBOARD);

                    }
                    else if (e.getKeyChar() == 'b' || e.getKeyChar() == 'B')
                    {
                        ProcessBClick(GameSettings.SRC_KEYBOARD);

                    }
                    else if (e.getKeyChar() == 'd' || e.getKeyChar() == 'D')
                    {
                        ProcessDebugClick();

                    }

                    ProcessKeyClick(e.getKeyChar(), e.getExtendedKeyCode());
                }

                @Override
                public void keyPressed(KeyEvent e)
                {
                    //Ignore Enter and Space bar presses, handle them as A and B button clicks.
                    if (e.getKeyCode() != 32 && e.getKeyCode() != 10)
                    {
                        lastKeyPressEvent = System.currentTimeMillis();
                        if (e.getKeyCode() == 40)
                        {
                            ProcessDpadPress(GameSettings.DOWN_KEYBOARD);

                        }
                        else if (e.getKeyCode() == 38)
                        {
                            ProcessDpadPress(GameSettings.UP_KEYBOARD);

                        }
                        else if (e.getKeyCode() == 37)
                        {
                            ProcessDpadPress(GameSettings.LEFT_KEYBOARD);

                        }
                        else if (e.getKeyCode() == 39)
                        {
                            ProcessDpadPress(GameSettings.RIGHT_KEYBOARD);

                        }
                        else if (e.getKeyChar() == 'a' || e.getKeyChar() == 'A')
                        {
                            ProcessAPress(GameSettings.SRC_KEYBOARD);

                        }
                        else if (e.getKeyChar() == 'b' || e.getKeyChar() == 'B')
                        {
                            ProcessBPress(GameSettings.SRC_KEYBOARD);

                        }

                        ProcessKeyPress(e.getKeyChar(), e.getExtendedKeyCode());
                    }
                }

                @Override
                public void keyReleased(KeyEvent e)
                {
                    //Ignore Enter and Space bar releases, handle them as A and B button clicks.                
                    if (e.getKeyCode() != 32 && e.getKeyCode() != 10)
                    {
                        if (e.getKeyCode() == 40)
                        {
                            ProcessDpadRelease(GameSettings.DOWN_KEYBOARD);
                            ProcessDpadClick(GameSettings.DOWN_KEYBOARD);

                        }
                        else if (e.getKeyCode() == 38)
                        {
                            ProcessDpadRelease(GameSettings.UP_KEYBOARD);
                            ProcessDpadClick(GameSettings.UP_KEYBOARD);

                        }
                        else if (e.getKeyCode() == 37)
                        {
                            ProcessDpadRelease(GameSettings.LEFT_KEYBOARD);
                            ProcessDpadClick(GameSettings.LEFT_KEYBOARD);

                        }
                        else if (e.getKeyCode() == 39)
                        {
                            ProcessDpadRelease(GameSettings.RIGHT_KEYBOARD);
                            ProcessDpadClick(GameSettings.RIGHT_KEYBOARD);

                        }
                        else if (e.getKeyChar() == 'a' || e.getKeyChar() == 'A')
                        {
                            ProcessARelease(GameSettings.SRC_KEYBOARD);

                        }
                        else if (e.getKeyChar() == 'b' || e.getKeyChar() == 'B')
                        {
                            ProcessBRelease(GameSettings.SRC_KEYBOARD);

                        }

                        ProcessKeyRelease(e.getKeyChar(), e.getExtendedKeyCode());
                    }
                }
            });

            canvas.addMouseListener(new MouseListener()
            {
                @Override
                    public void mouseClicked(MouseEvent e)
                {
                    ProcessMouseClick(e.getX(), e.getY());
                }

                @Override
                    public void mousePressed(MouseEvent e)
                {
                    ProcessMousePress(e.getX(), e.getY());
                }

                @Override
                    public void mouseReleased(MouseEvent e)
                {
                    ProcessMouseRelease(e.getX(), e.getY());
                }

                @Override
                    public void mouseEntered(MouseEvent e)
                {
                }

                @Override
                    public void mouseExited(MouseEvent e)
                {
                }

            });
            */

            if (GameSettings.GAMEPAD_1_ON) {
                gamePadHub = new GamePadHub(GameSettings.GAMEPAD_1_INDEX);
                gamePadRunner = new GamePadHubRunner(gamePadHub, GameSettings.GAMEPAD_1_POLLING_INTERVAL_MS, this);
                if (GameSettings.GAMEPAD_1_THREADED_POLLING) {
                    gpadTr = new Thread(gamePadRunner);
                    gpadTr.Start();
                }
            }

            if (GameSettings.GPIO_GAMEPAD_ON)
            {
                gpioHub = new GpioHub();
                gpioRunner = new GpioHubRunner(gpioHub, GameSettings.GPIO_GAMEPAD_POLLING_INTERVAL_MS, this);
                if (GameSettings.GPIO_GAMEPAD_THREADED_POLLING)
                {
                    gpioTr = new Thread(gpioRunner);
                    gpioTr.Start();
                }
            }

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
        /// <param name="src"></param>
        public virtual void ProcessARelease(int src)
        {
            currentScreen.ProcessARelease(src);
        }

        /// <summary>
        /// The ProcessAClick method is used to pass A button click events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src"></param>
        public virtual void ProcessAClick(int src)
        {
            currentScreen.ProcessAClick(src);
        }

        /// <summary>
        /// The ProcessBPress method is used to pass B button press events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src"></param>
        public virtual void ProcessBPress(int src)
        {
            currentScreen.ProcessBPress(src);
        }

        /// <summary>
        /// The ProcessBRelease method is used to pass A button release events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src"></param>
        public virtual void ProcessBRelease(int src)
        {
            currentScreen.ProcessBRelease(src);
        }

        /// <summary>
        /// The ProcessBClick method is used to pass A button click events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src"></param>
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
        /// <param name="code"></param>
        public virtual void ProcessKeyPress(char c, int code)
        {
            currentScreen.ProcessKeyPress(c, code);
        }

        /// <summary>
        /// The ProcessKeyRelease method is used to send key release events to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="c">The c argument is the character of the keyboard release event.</param>
        /// <param name="code"></param>
        public virtual void ProcessKeyRelease(char c, int code)
        {
            currentScreen.ProcessKeyRelease(c, code);
        }

        /// <summary>
        /// The ProcessKeyClick method is used to send key click events to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="c">The c argument is the character of the keyboard click event.</param>
        /// <param name="code"></param>
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
            canvas.createBufferStrategy(2);

            do
            {
                strategy = canvas.getBufferStrategy();
            } while (strategy == null);

            backgroundGraphics = (Graphics2D)background.getGraphics();
        }

        /// <summary>
        /// Create a BufferedImage using the default screen device and configuration.
        /// </summary>
        /// <param name="width">The desired width of the BufferedImage.</param>
        /// <param name="height">The desired height of the BufferedImage.</param>
        /// <param name="alpha">The desired transparency flag of the BufferedImage.</param>
        /// <returns>Returns a BufferedImage with the desired coordinates and transparency. </returns>
        public virtual Texture2D create(int width, int height, bool alpha)
        {
            return MmgBmpScaler.GRAPHICS_CONFIG.createCompatibleImage(width, height, alpha ? Transparency.TRANSLUCENT : Transparency.OPAQUE);
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
        public virtual Canvas GetCanvas()
        {
            return canvas;
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
            MmgHelper.wr("Switching Game State To: " + g);

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
            MmgHelper.wr("HandleGenericEvent");
            if (obj != null)
            {
                if (obj.GetGameState() == GameStates.LOADING)
                {
                    if (obj.GetId() == ScreenLoading.EVENT_LOAD_COMPLETE)
                    {
                        //Final loading steps
                        DatExternalStrings.LOAD_EXT_STRINGS();
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
            if (graphics == null)
            {
                try
                {
                    graphics = (Graphics2D)strategy.getDrawGraphics();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
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
            graphics.Dispose();
            graphics = null;
            try
            {
                strategy.show();
                Toolkit.getDefaultToolkit().sync();
                return (!strategy.contentsLost());
            }
            catch (Exception e)
            {
                return true;
            }
        }

        /// <summary>
        /// The UpdateGame method is used to call the lower level MmgUpdate method of the MmgGameScreen class, currentScreen.
        /// Send the update call count, the current time, and the time difference between this frame and the last frame.
        /// </summary>
        public virtual void UpdateGame()
        {
            updateTick++;

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
            if (PAUSE == true || EXIT == true)
            {
                //do nothing
            }
            else
            {
                UpdateGame();
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
                //clear background
                g.setColor(Color.DarkGray);
                g.fillRect(0, 0, winWidth, winHeight);

                //draw border
                g.setColor(Color.White);
                g.drawRect(MmgScreenData.GetGameLeft() - 1, MmgScreenData.GetGameTop() - 1, MmgScreenData.GetGameWidth() + 1, MmgScreenData.GetGameHeight() + 1);

                g.setColor(Color.Black);
                g.fillRect(MmgScreenData.GetGameLeft(), MmgScreenData.GetGameTop(), MmgScreenData.GetGameWidth(), MmgScreenData.GetGameHeight());

                p.SetGraphics(g);
                p.SetAdvRenderHints();
                currentScreen.MmgDraw(p);

                if (MmgHelper.LOGGING == true)
                {
                    tmpF = g.getFont();
                    g.setFont(debugFont);
                    g.setColor(debugColor);
                    g.drawString(GamePanel.FPS, 15, 15);
                    g.drawString("Var1: " + GamePanel.VAR1, 15, 35);
                    g.drawString("Var2: " + GamePanel.VAR2, 15, 55);
                    g.setFont(tmpF);
                }
            }

            //draws a scaled version of the state of the background buffer to the screen buffer if scaling is enabled
            if (scale != 1.0)
            {
                //bg.drawImage(background, sMyX, sMyY, sWinWidth, sWinHeight, 0, 0, winWidth, winHeight, null);
                bg.Draw(background, new Rectangle(sMyX, sMyY, sWinWidth, sWinHeight), new Rectangle(0, 0, winWidth, winHeight), Color.White);
            }
            else
            {
                //bg.drawImage(background, myX, myY, null);
                bg.Draw(background, new Vector2(myX, myY), Color.White);
            }

            bg.Dispose();

            UpdateScreen();
        }
    }
}