﻿using System;

namespace MmgGameApiCs.net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// The base event handler class for event passing. 
    /// Created by Middlemind Games 08/29/2016
    /// 
    /// @author Victor G.Brusca
    /// </summary>
    public interface MmgEventHandler
    {

        /// <summary>
        /// Handles an MmgEvent object.
        /// </summary>
        /// <param name="e">The event to handle.</param>
        public void MmgHandleEvent(MmgEvent e);
    }
}
