﻿using System;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.MmgGameApiCs.MmgTestSpace
{
    /// <summary>
    /// A game screen class that : the MmgGameScreen base class.
    /// This class is for testing API classes.
    /// Created by Middlemind Games 02/25/2020
    /// 
    /// @author Victor G. Brusca
    /// </summary>
    public class ScreenTestMmgTextBlock : MmgGameScreen, GenericEventHandler, MmgEventHandler
    {
        /// <summary>
        /// The game state this screen has.
        /// </summary>
        protected readonly GameStates gameState;

        /// <summary>
        /// Event handler for firing generic events.
        /// Events would fire when the screen has non UI actions to broadcast.
        /// </summary>
        protected GenericEventHandler handler;

        /// <summary>
        /// The GamePanel that owns this game screen.
        /// Usually a JPanel instance that holds a reference to this game screen object.
        /// </summary>
        protected readonly GamePanel owner;

        /// <summary>
        /// An MmgTextBlock class instance used as the test object for this test game screen.
        /// </summary>
        private MmgTextBlock txtBlock;

        /// <summary>
        /// An MmgFont class instances used to display the numbers of pages, words and lines extracted from the source text.
        /// </summary>
        private MmgFont txtWords;

        /// <summary>
        /// A string class field used to store the source text that is split and displayed by the MmgTextBlock.
        /// </summary>
        private string txt;

        /// <summary>
        /// An MmgFont class instance used as the title for the test game screen.
        /// </summary>
        private MmgFont title;

        /// <summary>
        /// A bool flag indicating if there is work to do in the next MmgUpdate call.
        /// </summary>
        private bool isDirty = false;

        /// <summary>
        /// A private bool flag used in the MmgUpdate method during the update process.
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
        /// 
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        /// </summary>
        //     @SuppressWarnings("LeakingThisInConstructor")
        public ScreenTestMmgTextBlock(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMmgTextBlock.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// 
        /// <param name="Handler">A class that , the GenericEventHandler interface.</param>
        /// </summary>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.SetGenericEventHandler");
            handler = Handler;
        }

        /// <summary>
        /// Gets the GenericEventHandler this game screen uses to handle GenericEvents.
        /// 
        /// <returns>The GenericEventHandler this screen uses to handle GenericEvents.</returns>
        /// </summary>
        public virtual GenericEventHandler GetGenericEventHandler()
        {
            return handler;
        }

        /// <summary>
        /// Loads all the resources needed to display this game screen.
        /// </summary>
        public virtual void LoadResources()
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Text Block (19 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);

            txt = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec sapien eget velit hendrerit ultrices ut ac tortor. Sed a elit libero. Fusce venenatis dapibus auctor. Nullam lacinia consectetur erat id rhoncus. Nullam consequat scelerisque tincidunt. Phasellus et dolor justo. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Maecenas hendrerit ante eros, et dapibus augue eleifend ut. Integer et dapibus metus. Donec ac mi blandit elit tristique mollis sit amet vel lorem. Cras vehicula eros vel arcu dapibus tempor. In at lectus porta, mattis nisi vitae, tristique urna. Nunc eget vestibulum odio, nec convallis enim. Cras viverra turpis ut tempor feugiat. Mauris ut mauris et felis vehicula facilisis vitae quis nisl. Nam vulputate semper enim, ut iaculis nulla elementum at. Integer mattis pulvinar nunc vestibulum placerat. Nulla semper id nulla non condimentum. In efficitur dignissim libero laoreet aliquam. Sed eu metus urna. Sed semper quam quis ultrices pharetra. Aenean ante neque, pulvinar eget facilisis sit amet, tempor quis dolor. Vivamus eleifend purus vitae urna imperdiet commodo. Etiam non commodo neque. Sed iaculis luctus mollis. Maecenas id purus mollis, hendrerit diam in, sagittis erat. Nullam eu malesuada sem. Etiam dolor orci, maximus id rutrum at, cursus nec lectus. Vivamus ac eleifend nulla. Donec efficitur, quam at pretium aliquet, velit justo iaculis tortor, eget rutrum libero sem non velit. Mauris est tellus, pharetra nec tempus vitae, eleifend non neque. Nulla convallis neque nibh, eu luctus metus congue in. Pellentesque non sem a leo consequat luctus. Nullam volutpat urna sed magna imperdiet aliquam. Fusce fringilla, felis a sodales posuere, urna dui pretium enim, in rutrum neque massa id eros. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Proin rhoncus interdum nisl, in vulputate nulla gravida vel. Integer id interdum nisi. Nullam a interdum dolor, convallis molestie odio. Mauris lorem metus, pulvinar ac justo non, accumsan lobortis lorem. Donec commodo purus eu nunc varius porttitor.";

            MmgTextBlock.SHOW_CONTROL_BGROUND_STORY_BOUNDING_BOX = true;
            txtBlock = new MmgTextBlock();
            txtBlock.SetLineHeight(MmgFontData.GetTargetPixelHeightScaled() + MmgHelper.ScaleValue(5));
            txtBlock.SetHeight(MmgHelper.ScaleValue(300));
            txtBlock.SetWidth(MmgHelper.ScaleValue(400));
            txtBlock.SetPaddingX(MmgHelper.ScaleValue(txtBlock.GetPaddingX()));
            txtBlock.SetPaddingY(MmgHelper.ScaleValue(txtBlock.GetPaddingY()));
            txtBlock.PrepLinesInBox(txtBlock.GetLinesInBox());
            txtBlock.PrepTextSplit(txt, MmgFontData.GetFontNorm(), MmgFontData.GetFontSize(), MmgHelper.ScaleValue(375));
            txtBlock.SetColor(MmgColor.GetWhite());

            MmgHelper.CenterHorAndVert(txtBlock);
            txtBlock.PrepPage(0);

            //Must be done after the text split to set the position of each line of text.
            txtBlock.SetPosition(txtBlock.GetPosition());
            AddObj(txtBlock);

            MmgHelper.wr("Words: " + txtBlock.GetWordCount());
            MmgHelper.wr("Lines: " + txtBlock.GetLineCount());
            MmgHelper.wr("Pages: " + txtBlock.GetPageCount());

            txtWords = MmgFontData.CreateDefaultBoldMmgFontSm();
            txtWords.SetText("Words: " + txtBlock.GetWordCount() + "  Lines: " + txtBlock.GetLineCount() + "  Pages: " + txtBlock.GetPageCount());
            MmgHelper.CenterHor(txtWords);
            txtWords.SetY(GetY() + GetHeight() - MmgHelper.ScaleValue(30));
            AddObj(txtWords);

            ready = true;
            pause = false;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's
        /// offset.
        /// 
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        /// </summary>
        public override bool ProcessMousePress(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.ProcessScreenPress");
            return ProcessMousePress(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's
        /// offset.
        /// 
        /// <param name="x">The X coordinate of the mouse.</param>
        /// <param name="y">The Y coordinate of the mouse.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        /// </summary>
        public override bool ProcessMousePress(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.ProcessScreenPress");
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's
        /// offset.
        /// 
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        /// </summary>
        public override bool ProcessMouseRelease(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.ProcessScreenRelease");
            return ProcessMousePress(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
        /// 
        /// <param name="x">The X coordinate of the event.</param>
        /// <param name="y">The Y coordinate of the event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        /// </summary>
        public override bool ProcessMouseRelease(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.ProcessScreenRelease");
            return true;
        }

        /// <summary>
        /// A method to handle A click events.
        /// 
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessAClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.ProcessAClick");
            return true;
        }

        /// <summary>
        /// A method to handle B click events.
        /// 
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessBClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.ProcessBClick");
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.ProcessDebugClick");
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// 
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.ProcessDpadPress: " + dir);
            return true;
        }

        /// <summary>
        /// A method to handle dpad release events.
        /// 
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessDpadRelease(int dir)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.ProcessDpadRelease: " + dir);
            if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_20);

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_18);

            }
            return true;
        }

        /// <summary>
        /// A method to handle dpad click events.
        /// 
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessDpadClick(int dir)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.ProcessDpadClick: " + dir);
            return true;
        }

        /// <summary>
        /// Process a screen click.
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// 
        /// <param name="v">The coordinates of the click.</param>
        /// <returns>Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        /// </summary>
        public override bool ProcessMouseClick(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.ProcessScreenClick");
            return ProcessMouseClick(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Process a screen click.
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// 
        /// <param name="x">The X axis coordinate of the screen click.</param>
        /// <param name="y">The Y axis coordinate of the screen click.</param>
        /// <returns>Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        /// </summary>
        public override bool ProcessMouseClick(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.ProcessScreenClick");
            return true;
        }

        /// <summary>
        /// A method to handle keyboard click events.
        /// 
        /// <param name="c">The key used in the event.</param>
        /// <param name="code">The code of the key used in the event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessKeyClick(char c, int code)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.ProcessKeyClick");
            return true;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public virtual void UnloadResources()
        {
            pause = true;
            SetBackground(null);

            title = null;
            txtBlock = null;
            txt = null;
            txtWords = null;

            ClearObjs();
            ready = false;
        }

        /// <summary>
        /// Returns the game state of this game screen.
        /// 
        /// <returns>The game state of this game screen.</returns>
        /// </summary>
        public virtual GameStates GetGameState()
        {
            return gameState;
        }

        /// <summary>
        /// Base draw method, handles drawing this class.
        /// 
        /// <param name="p">The MmgPen used to draw this object.</param>
        /// </summary>
        public override void MmgDraw(MmgPen p)
        {
            if (pause == false && isVisible == true)
            {
                base.MmgDraw(p);
            }
        }

        /// <summary>
        /// The callback method to handle GenericEventMessage objects.
        /// 
        /// <param name="obj">A GenericEventMessage object instance to process.</param>
        /// </summary>
        public virtual void HandleGenericEvent(GenericEventMessage obj)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// 
        /// <param name="e">An MmgEvent object instance to process.</param>
        /// </summary>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            MmgHelper.wr("ScreenTestMmgTextBlock.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
        }
    }
}