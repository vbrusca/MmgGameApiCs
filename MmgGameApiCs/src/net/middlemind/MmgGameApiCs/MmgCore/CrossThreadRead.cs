using System;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// TODO: Add comment
    /// </summary>
    public class CrossThreadRead
    {
        /// <summary>
        /// TODO: Add comment
        /// </summary>
        public CrossThreadWrite commandList;

        /// <summary>
        /// TODO: Add comment
        /// </summary>
        /// <param name="ctw"></param>
        public CrossThreadRead(CrossThreadWrite ctw)
        {
            commandList = ctw;
        }

        /// <summary>
        /// TODO: Add comment
        /// </summary>
        /// <returns></returns>
        public CrossThreadCommand GetNextCommand()
        {
            CrossThreadCommand ret = null;
            if (commandList != null && commandList.commands.Count > 0)
            {
                //int len = commandList.commands.Count;
                ret = commandList.commands[0];
                commandList.commands.RemoveAt(0);
            }

            return ret;
        }

        /// <summary>
        /// TODO: Add comment
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if(commandList == null || commandList.commands == null || commandList.commands.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}