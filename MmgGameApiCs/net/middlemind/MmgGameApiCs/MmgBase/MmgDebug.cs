using System;

namespace MmgGameApiCs.net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// 
    /// </summary>
    public class MmgDebug
    {
        /// <summary>
        /// Flag that turns logging on or off.
        /// </summary>
        public static bool DEBUGGING_ON = true;

        /// <summary>
        /// 
        /// </summary>
        public static string appName = "MmgApi.MmgDebug";

        /// <summary>
        /// A static helper method for logging.
        /// </summary>
        /// <param name="s">The string to log.</param>
        public static void wr(string s)
        {
            if (DEBUGGING_ON == true)
            {
                //System.Diagnostics.Debug.WriteLine(appName + ": " + s);
                MmgApiUtils.wr(appName + ": " + s);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="s"></param>
        public static void wr(string key, string s)
        {
            if (DEBUGGING_ON == true)
            {
                //System.Diagnostics.Debug.WriteLine(key + ": " + s);
                MmgApiUtils.wr(key + ": " + s);
            }
        }

        /// <summary>
        /// A static helper method for timestamped logging.
        /// </summary>
        /// <param name="s">The string to log.</param>
        public static void wrTs(String s)
        {
            if (DEBUGGING_ON == true)
            {
                //System.Diagnostics.Debug.WriteLine(appName + " [" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + "]: " + s);
                MmgApiUtils.wr(appName + " [" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + "]: " + s);
            }
        }
    }
}
