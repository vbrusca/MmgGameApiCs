﻿using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.DungeonTrap.Chapter24_Phase3_CompleteGame
{
    /// <summary>
    /// A class that represents a small table.
    ///
    /// @author Victor G. Brusca, Middlemind Games
    /// 09/19/2020
    /// </summary>
    public class MdtObjPushTableSmall : MdtObjPush
    {
        /// <summary>
        /// A basic constructor for the small table class.
        /// </summary>
        /// <param name="Screen"></param>
        public MdtObjPushTableSmall(ScreenGame Screen)
        {
            SetSubj(MmgHelper.GetBasicCachedBmp("table_lg.png"));
            SetMdtType(MdtObjType.OBJECT);
            SetMdtSubType(MdtObjSubType.OBJECT_TABLE_1);
            SetScreen(Screen);
            SetWidth(subj.GetWidth());
            SetHeight(subj.GetHeight());
            SetPushSpeed(ScreenGame.GetSpeedPerFrame(250));

            MmgBmp src = MmgHelper.GetBasicCachedBmp("explosion_anim_spritesheet_lg.png");
            MmgSpriteSheet ssSrc = new MmgSpriteSheet(src, 32, 32);
            subjBreaks = new MmgSprite(ssSrc.GetFrames());
            subjBreaks.SetMsPerFrame(50);
        }

        /// <summary>
        /// A constructor for the small table class that let's you specify the subject.
        /// </summary>
        /// <param name="Subj">The subject of the class.</param>
        /// <param name="SubjBreaks">The subject break animation.</param>
        /// <param name="Screen">The game's ScreenGame class.</param>
        public MdtObjPushTableSmall(MmgBmp Subj, MmgSprite SubjBreaks, ScreenGame Screen)
            : base(Subj, SubjBreaks, MdtObjType.OBJECT, MdtObjSubType.OBJECT_TABLE_1, Screen)
        {
            SetPushSpeed(ScreenGame.GetSpeedPerFrame(250));
        }
    }
}