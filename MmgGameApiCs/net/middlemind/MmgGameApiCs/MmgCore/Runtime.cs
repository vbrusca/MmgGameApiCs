using System;
using System.Diagnostics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// TODO: Add comment
    /// </summary>
    public class Runtime
    {
        /// <summary>
        /// TODO: Add comment
        /// </summary>
        /// <returns></returns>
        public static Runtime getRuntime()
        {
            return new Runtime();
        }

        /// <summary>
        /// TODO: Add comment
        /// </summary>
        /// <param name="cmd"></param>
        public int exec(string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return process.ExitCode;
            //return result;
        }
    }
}