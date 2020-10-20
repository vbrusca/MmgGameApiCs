using System;
using System.Collections.Generic;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// TODO: Add comment
    /// </summary>
    public class CrossThreadWrite
    {
        /// <summary>
        /// TODO: Add comment
        /// </summary>
        public List<CrossThreadCommand> commands = new List<CrossThreadCommand>();

        /// <summary>
        /// TODO: Add comment
        /// </summary>
        /// <param name="name"></param>
        /// <param name="payload"></param>
        public void AddCommand(string name, object[] payload)
        {
            commands.Add(new CrossThreadCommand(name, payload));
        }
    }
}