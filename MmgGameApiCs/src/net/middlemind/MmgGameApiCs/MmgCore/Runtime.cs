using System;
using System.Diagnostics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    //Note: Class created to mimic the Java Runtime class used to run shell commands to determine the state of gpio pins.
    /// <summary>
    /// TODO: Add comment
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
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
            process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return process.ExitCode;
        }
    }
}