using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// TODO: Add comments
    /// </summary>
    public interface MmgScaleHandler
    {
        /// <summary>
        /// TODO: Add comments
        /// </summary>
        /// <param name="v"></param>
        /// <param name="orig"></param>
        public void MmgHandleScale(MmgVector2 v, MmgObj orig);
    }
}