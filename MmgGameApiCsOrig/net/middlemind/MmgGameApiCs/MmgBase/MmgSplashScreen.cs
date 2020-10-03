﻿using System;
using System.Threading;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class that represents a splash screen. 
    /// Created by Middlemind Games 06/01/2005
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgSplashScreen : MmgGameScreen, MmgUpdateHandler
    {
        /// <summary>
        /// Inner class used to time how long to display the splash screen. 
        /// Created by Middlemind Games 06/01/2005
        ///
        /// @author Victor G.Brusca
        /// </summary>
        public class MmgSplashScreenTimer
        {
            /// <summary>
            /// The display time to show the given splash screen.
            /// </summary>
            private long displayTime;

            /// <summary>
            /// The update handler to handle update event messages.
            /// </summary>
            private MmgUpdateHandler update;

            /// <summary>
            /// Generic constructor sets the display time in ms.
            /// </summary>
            /// <param name="DisplayTime">Splash screen display time in ms.</param>
            public MmgSplashScreenTimer(long DisplayTime)
            {
                displayTime = DisplayTime;
            }

            /// <summary>
            /// Sets the update handler for this runnable. Calls back to the update handler once the display time has passed.
            /// </summary>
            /// <param name="Update">A class that supports the MmgUpdateHandler interface.</param>
            public virtual void SetUpdateHandler(MmgUpdateHandler Update)
            {
                update = Update;
            }

            /// <summary>
            /// Start the display wait thread.
            /// </summary>
            public void run()
            {
                try
                {
                    Thread.Sleep((int)displayTime);

                    if (update != null)
                    {
                        MmgHelper.wr("MmgHandleUpdate");
                        update.MmgHandleUpdate(null);
                    }
                }
                catch (Exception e)
                {

                }
            }
        }

        /// <summary>
        /// The display time to show this splash screen.
        /// </summary>
        private int displayTime;

        /// <summary>
        /// The update handler to handle update events.
        /// </summary>
        private MmgUpdateHandler update;

        /// <summary>
        /// The default display time.
        /// </summary>
        public static int DEFAULT_DISPLAY_TIME_MS = 3000;

        /// <summary>
        /// Constructor that sets the display time to the default display time.
        /// </summary>
        public MmgSplashScreen() : base()
        {
            SetDisplayTime(DEFAULT_DISPLAY_TIME_MS);
        }

        /// <summary>
        /// Constructor that sets the splash screen display time.
        /// </summary>
        /// <param name="DisplayTime">The display time for this splash screen, in milliseconds.</param>
        public MmgSplashScreen(int DisplayTime) : base()
        {
            SetDisplayTime(DisplayTime);
        }

        /// <summary>
        /// Constructor that sets the splash screen attributes based on the values of the given argument.
        /// </summary>
        /// <param name="obj">The display time in milliseconds.</param>
        public MmgSplashScreen(MmgSplashScreen obj) : base(obj)
        {
            SetDisplayTime(obj.GetDisplayTime());

            if (obj.GetBackground() == null)
            {
                SetBackground(obj.GetBackground());
            }
            else
            {
                SetBackground(obj.GetBackground().Clone());
            }

            if (obj.GetFooter() == null)
            {
                SetFooter(obj.GetFooter());
            }
            else
            {
                SetFooter(obj.GetFooter().Clone());
            }

            SetHasParent(obj.GetHasParent());

            if (obj.GetHeader() == null)
            {
                SetHeader(obj.GetHeader());
            }
            else
            {
                SetHeader(obj.GetHeader().Clone());
            }

            SetHeight(obj.GetHeight());
            SetIsVisible(obj.GetIsVisible());

            if (obj.GetLeftCursor() == null)
            {
                SetLeftCursor(obj.GetLeftCursor());
            }
            else
            {
                SetLeftCursor(obj.GetLeftCursor().Clone());
            }

            if (obj.GetMenu() == null)
            {
                SetMenu(obj.GetMenu());
            }
            else
            {
                SetMenu(obj.GetMenu().CloneTyped());
            }

            SetMenuCursorLeftOffsetX(obj.GetMenuCursorLeftOffsetX());
            SetMenuCursorLeftOffsetY(obj.GetMenuCursorLeftOffsetY());
            SetMenuCursorRightOffsetX(obj.GetMenuCursorRightOffsetX());
            SetMenuCursorRightOffsetY(obj.GetMenuCursorRightOffsetY());
            SetMenuIdx(obj.GetMenuIdx());
            SetMenuOn(obj.GetMenuOn());
            SetMenuStart(obj.GetMenuStart());
            SetMenuStop(obj.GetMenuStop());

            if (obj.GetMessage() == null)
            {
                SetMessage(obj.GetMessage());
            }
            else
            {
                SetMessage(obj.GetMessage().Clone());
            }

            if (obj.GetMmgColor() == null)
            {
                SetMmgColor(obj.GetMmgColor());
            }
            else
            {
                SetMmgColor(obj.GetMmgColor().Clone());
            }

            SetName(obj.GetName());

            if (obj.GetObjects() == null)
            {
                SetObjects(obj.GetObjects());
            }
            else
            {
                SetObjects(obj.GetObjects().CloneTyped());
            }

            SetParent(obj.GetParent());

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                SetPosition(obj.GetPosition().Clone());
            }

            if (obj.GetRightCursor() == null)
            {
                SetRightCursor(obj.GetRightCursor());
            }
            else
            {
                SetRightCursor(obj.GetRightCursor().Clone());
            }

            SetWidth(obj.GetWidth());
        }

        /// <summary>
        /// Starts the splash screen display.
        /// </summary>
        public virtual void StartDisplay()
        {
            MmgSplashScreenTimer s = new MmgSplashScreenTimer(displayTime);
            s.SetUpdateHandler(this);
            //Runnable r = s;
            //Thread t = new Thread(r);
            //t.start();

            ThreadStart ts = new ThreadStart(s.run);
            Thread t = new Thread(ts);
            t.Start();
        }

        /// <summary>
        /// Sets the update event handler.
        /// </summary>
        /// <param name="Update">The update event handler.</param>
        public virtual void SetUpdateHandler(MmgUpdateHandler Update)
        {
            update = Update;
        }

        /// <summary>
        /// Gets the update event handler.
        /// </summary>
        /// <returns>The update event handler.</returns>
        public MmgUpdateHandler GetUpdateHandler()
        {
            return update;
        }

        /// <summary>
        /// Handles update events.
        /// </summary>
        /// <param name="obj">The update event to handle.</param>
        public void MmgHandleUpdate(Object obj)
        {
            if (update != null)
            {
                update.MmgHandleUpdate(obj);
            }
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgSplashScreen(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgSplashScreen CloneTyped()
        {
            return new MmgSplashScreen(this);
        }

        /// <summary>
        /// Gets the current display time.
        /// </summary>
        /// <returns>The current display time.</returns>
        public int GetDisplayTime()
        {
            return displayTime;
        }

        /// <summary>
        /// Sets the current display time.
        /// </summary>
        /// <param name="i">The current display time.</param>
        public void SetDisplayTime(int i)
        {
            displayTime = i;
        }

        /// <summary>
        /// Draws this object to the screen.
        /// </summary>
        /// <param name="p">The MmgPen to draw this object with.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true && pause == false)
            {
                base.MmgDraw(p);
            }
        }

        /// <summary>
        /// Tests if this object is equal to another MmgSplashScreen object.
        /// </summary>
        /// <param name="obj">An MmgSplashScreen object instance to compare to.</param>
        /// <returns>Returns true if the objects are considered equal and false otherwise.</returns>
        public bool equals(MmgSplashScreen obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            bool ret = false;
            if (
                base.equals((MmgGameScreen)obj)
                && obj.GetDisplayTime() == GetDisplayTime()
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}
