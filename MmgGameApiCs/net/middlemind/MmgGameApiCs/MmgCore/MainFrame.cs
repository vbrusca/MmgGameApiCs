using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /**
     * The main frame of the game, extends the JFrame class. 
     * Handles housing the GamePanel, JPanel, that draws each game state by making the corresponding game screen the active screen. 
     * Created by Middlemind Games 08/01/2015
     *
     * @author Victor G. Brusca
     */
    public class MainFrame : JFrame
    {

        /**
         * The GamePanel, extends JFrame, class that handles drawing the different game states.
         */
        public GamePanel pnlGame;

        /**
         * The window width.
         */
        public readonly int winWidth;

        /**
         * The window height.
         */
        public readonly int winHeight;

        /**
         * The X offset of this frame.
         */
        public readonly int myX;

        /**
         * The Y offset of this frame.
         */
        public readonly int myY;

        /**
        * The game panel width.
        */
        public readonly int panelWidth;

        /**
        * The game panel height.
        */
        public readonly int panelHeight;

        /**
        * The game panel width.
        */
        public readonly int gameWidth;

        /**
        * The game panel height.
        */
        public readonly int gameHeight;

        /*
         * Constructor that sets the window width and height, and defaults the X, Y offsets to 0. 
         * It also sets the JFrame and game width and height to that of the window width and height.
         *
         * @param WinWidth      The desired window width.
         * @param WinHeight     The desired window height.
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="WinWidth"></param>
        /// <param name="WinHeight"></param>
        public MainFrame(int WinWidth, int WinHeight)
        {
            winWidth = WinWidth;
            winHeight = WinHeight;
            panelWidth = winWidth;
            panelHeight = winHeight;
            gameWidth = winWidth;
            gameHeight = winHeight;
            myX = 0;
            myY = 0;
        }

        /*
         * Constructor that sets the window width and height, the JFrame width and height, and the game width and height.
         * 
         * @param WinWidth      The desired window width.
         * @param WinHeight     The desired window height.
         * @param PanWidth      The desired JFrame width.
         * @param PanHeight     The desired JFrame height.
         * @param GameWidth     The desired game width.
         * @param GameHeight    The desired game height.
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="WinWidth"></param>
        /// <param name="WinHeight"></param>
        /// <param name="PanWidth"></param>
        /// <param name="PanHeight"></param>
        /// <param name="GameWidth"></param>
        /// <param name="GameHeight"></param>
        public MainFrame(int WinWidth, int WinHeight, int PanWidth, int PanHeight, int GameWidth, int GameHeight)
        {
            MmgHelper.wr("MainFrame: WinWidth: " + WinWidth);
            MmgHelper.wr("MainFrame: WinHeight: " + WinHeight);
            MmgHelper.wr("MainFrame: PanelWidth: " + PanWidth);
            MmgHelper.wr("MainFrame: PanelHeight: " + PanHeight);
            MmgHelper.wr("MainFrame: GameWidth: " + GameWidth);
            MmgHelper.wr("MainFrame: GameHeight: " + GameHeight);
            winWidth = WinWidth;
            winHeight = WinHeight;
            panelWidth = PanWidth;
            panelHeight = PanHeight;
            gameWidth = GameWidth;
            gameHeight = GameHeight;
            myX = (winWidth - panelWidth) / 2;
            myY = (winHeight - panelHeight) / 2;
        }

        /*
         * Sets the display text of the frame rate label.
         *
         * @param fr        A long representing the current drawing frame rate, or the frame rate if no time lock is applied.
         * @param rfr       A long representing the locked frame rate.
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fr"></param>
        /// <param name="rfr"></param>
        public virtual void SetFrameRate(long fr, long rfr)
        {
            if (pnlGame != null)
            {
                GamePanel.FPS = "Drawing FPS: " + fr + " Actual FPS: " + rfr;
            }
        }

        /*
         * Sets the GamePanel for this class to use as the game being displayed.
         * 
         * @param gp        The GamePanel to display.
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gp"></param>
        public virtual void SetGamePanel(GamePanel gp)
        {
            pnlGame = gp;
        }

        /*
         * Gets the current GamePanel this classing is using to display a game.
         * 
         * @return      The current GamePanel being displayed. 
         */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual GamePanel GetGamePanel()
        {
            return pnlGame;
        }

        /*
         * Gets the current window width of the application.
         * 
         * @return      The current window width.
         */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetWindowWidth()
        {
            return winWidth;
        }

        /*
         * Gets the current window height of the application.
         * 
         * @return The current window height. 
         */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetWindowHeight()
        {
            return winHeight;
        }

        /*
         * Gets the X offset of the GamePanel in this JFrame.
         * 
         * @return      The X offset of the GamePanel's rendering location in the JFrame.
         */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetOffsetX()
        {
            return myX;
        }

        /*
         * Gets the Y offset of the GamePanel in this JFrame.
         * 
         * @return      The Y offset of the GamePanel's rendering location in the JFrame.
         */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetOffsetY()
        {
            return myY;
        }

        /*
         * Gets the width of the GamePanel in this JFrame.
         * 
         * @return      The width of the GamePanel in this JFrame.
         */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetGamePanelWidth()
        {
            return panelWidth;
        }

        /*
         * Gets the height of the GamePanel in this JFrame.
         * 
         * @return      The height of the GamePanel in this JFrame.
         */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetGamePanelHeight()
        {
            return panelHeight;
        }

        /*
         * Gets the width of the game that's rendered by the GamePanel in this JFrame.
         * 
         * @return      The width of the game that's rendered by the GamePanel in this JFrame.
         */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetGameWidth()
        {
            return gameWidth;
        }

        /*
         * Gets the height of the game that's rendered by the GamePanel in this JFrame.
         * 
         * @return      The height of the game that's rendered by the GamePanel in this JFrame.
         */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetGameHeight()
        {
            return gameHeight;
        }

        /*
         * Initializes the components used by this JFrame.
         */
        /// <summary>
        /// 
        /// </summary>
        public virtual void InitComponents()
        {
            MmgHelper.wr("MainFrame: Found Screen Dimen: " + winWidth + "x" + winHeight);
            MmgHelper.wr("MainFrame: Found Position: " + myX + "x" + myY);
            add(pnlGame.GetCanvas());

            pnlGame.GetCanvas().setFocusable(true);
            pnlGame.GetCanvas().requestFocus();
            pnlGame.GetCanvas().requestFocusInWindow();

            setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            /*
            addWindowListener(new WindowListener() {

                @Override
                public void windowOpened(WindowEvent e)
                {
                }

                @Override
                @SuppressWarnings("CallToPrintStackTrace")
                public void windowClosing(WindowEvent e)
                {
                    try
                    {
                        MmgHelper.wr("WindowClosing");

                        GamePanel.PAUSE = true;
                        GamePanel.EXIT = true;
                        RunFrameRate.PAUSE = true;
                        RunFrameRate.RUNNING = false;

                    }
                    catch (Exception ex)
                    {
                        MmgHelper.wrErr(ex);
                    }
                    dispose();
                }

                @Override
                    public void windowClosed(WindowEvent e)
                {
                }

                @Override
                    public void windowIconified(WindowEvent e)
                {
                }

                @Override
                    public void windowDeiconified(WindowEvent e)
                {
                }

                @Override
                    public void windowActivated(WindowEvent e)
                {
                }

                @Override
                    public void windowDeactivated(WindowEvent e)
                {
                }
            });
            */
        }

        /*
         * Forces the GamePanel to repaint itself.
         */
        /// <summary>
        /// 
        /// </summary>
        public virtual void Redraw()
        {
            if (pnlGame != null)
            {
                pnlGame.RenderGame();
            }
        }
    }
}
