using System;
using System.Collections.Generic;

namespace net.middlemind.MmgGameApiCs.MmgCore
{

    public class CrossThreadWrite
    {
        public List<CrossThreadCommand> commands = new List<CrossThreadCommand>();


        public void AddCommand(string name, object[] payload)
        {
            commands.Add(new CrossThreadCommand(name, payload));
        }
    }
}