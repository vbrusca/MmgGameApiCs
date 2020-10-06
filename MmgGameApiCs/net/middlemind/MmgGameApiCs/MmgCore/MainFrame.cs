using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// The main frame of the game, extends the JFrame class. 
    /// Handles housing the GamePanel, JPanel, that draws each game state by making the corresponding game screen the active screen.
    /// Created by Middlemind Games 08/01/2015
    ///
    /// @author Victor G.Brusca
    /// </summary>
    public class MainFrame
    {
        /// <summary>
        /// The GamePanel, extends JFrame, class that handles drawing the different game states.
        /// </summary>
        public GamePanel pnlGame;

        /// <summary>
        /// The window width.
        /// </summary>
        public readonly int winWidth;

        /// <summary>
        /// The window height.
        /// </summary>
        public readonly int winHeight;

        /// <summary>
        /// The X offset of this frame.
        /// </summary>
        public readonly int myX;

        /// <summary>
        /// The Y offset of this frame. 
        /// </summary>
        public readonly int myY;

        /// <summary>
        /// The game panel width. 
        /// </summary>
        public readonly int panelWidth;

        /// <summary>
        /// The game panel height. 
        /// </summary>
        public readonly int panelHeight;

        /// <summary>
        /// The game panel width.
        /// </summary>
        public readonly int gameWidth;

        /// <summary>
        /// The game panel height.
        /// </summary>
        public readonly int gameHeight;

        /// <summary>
        /// Constructor that sets the window width and height, and defaults the X, Y offsets to 0. 
        /// It also sets the JFrame and game width and height to that of the window width and height.
        /// </summary>
        /// <param name="WinWidth">The desired window width.</param>
        /// <param name="WinHeight">The desired window height.</param>
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

        /// <summary>
        /// Constructor that sets the window width and height, the JFrame width and height, and the game width and height.
        /// </summary>
        /// <param name="WinWidth">The desired window width.</param>
        /// <param name="WinHeight">The desired window height.</param>
        /// <param name="PanWidth">The desired JFrame width.</param>
        /// <param name="PanHeight">The desired JFrame height.</param>
        /// <param name="GameWidth">The desired game width.</param>
        /// <param name="GameHeight">The desired game height.</param>
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

        /// <summary>
        /// Sets the display text of the frame rate label.
        /// </summary>
        /// <param name="fr">A long representing the current drawing frame rate, or the frame rate if no time lock is applied.</param>
        /// <param name="rfr">A long representing the locked frame rate.</param>
        public virtual void SetFrameRate(long fr, long rfr)
        {
            if (pnlGame != null)
            {
                GamePanel.FPS = "Drawing FPS: " + fr + " Actual FPS: " + rfr;
            }
        }

        /// <summary>
        /// Sets the GamePanel for this class to use as the game being displayed.
        /// </summary>
        /// <param name="gp">The GamePanel to display.</param>
        public virtual void SetGamePanel(GamePanel gp)
        {
            pnlGame = gp;
        }

        /// <summary>
        /// Gets the current GamePanel this classing is using to display a game.
        /// </summary>
        /// <returns>The current GamePanel being displayed.</returns>
        public virtual GamePanel GetGamePanel()
        {
            return pnlGame;
        }

        /// <summary>
        /// Gets the current window width of the application.
        /// </summary>
        /// <returns>The current window width.</returns>
        public virtual int GetWindowWidth()
        {
            return winWidth;
        }

        /// <summary>
        /// Gets the current window height of the application.
        /// </summary>
        /// <returns>The current window height.</returns>
        public virtual int GetWindowHeight()
        {
            return winHeight;
        }

        /// <summary>
        /// Gets the X offset of the GamePanel in this JFrame.
        /// </summary>
        /// <returns>The X offset of the GamePanel's rendering location in the JFrame.</returns>
        public virtual int GetOffsetX()
        {
            return myX;
        }

        /// <summary>
        /// Gets the Y offset of the GamePanel in this JFrame.
        /// </summary>
        /// <returns>The Y offset of the GamePanel's rendering location in the JFrame.</returns>
        public virtual int GetOffsetY()
        {
            return myY;
        }

        /// <summary>
        /// Gets the width of the GamePanel in this JFrame.
        /// </summary>
        /// <returns>The width of the GamePanel in this JFrame.</returns>
        public virtual int GetGamePanelWidth()
        {
            return panelWidth;
        }

        /// <summary>
        /// Gets the height of the GamePanel in this JFrame.
        /// </summary>
        /// <returns>The height of the GamePanel in this JFrame.</returns>
        public virtual int GetGamePanelHeight()
        {
            return panelHeight;
        }

        /// <summary>
        /// Gets the width of the game that's rendered by the GamePanel in this JFrame.
        /// </summary>
        /// <returns>The width of the game that's rendered by the GamePanel in this JFrame.</returns>
        public virtual int GetGameWidth()
        {
            return gameWidth;
        }

        /// <summary>
        /// Gets the height of the game that's rendered by the GamePanel in this JFrame.
        /// </summary>
        /// <returns>The height of the game that's rendered by the GamePanel in this JFrame.</returns>
        public virtual int GetGameHeight()
        {
            return gameHeight;
        }

        /// <summary>
        /// Initializes the components used by this JFrame.
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

        /// <summary>
        /// Forces the GamePanel to repaint itself.
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
