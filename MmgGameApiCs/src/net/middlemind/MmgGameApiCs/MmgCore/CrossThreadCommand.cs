using System;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// TODO: Add comment
    /// </summary>
    public class CrossThreadCommand
    {
        /// <summary>
        /// TODO: Add comment
        /// </summary>
        public string name;

        /// <summary>
        /// TODO: Add comment
        /// </summary>
        public object[] payload;

        /// <summary>
        /// TODO: Add comment
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Payload"></param>
        public CrossThreadCommand(string Name, object[] Payload)
        {
            name = Name;
            payload = Payload;
        }
    }
}