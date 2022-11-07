using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SetupSmartCross.Diagnostics
{

    public class CPU
    {
        private string _ProcessName;

        private PerformanceCounter _modifiedCpu;

        public float UsagePercent
        {
            get
            {
                float value = 0;
                try
                {
                    value = string.IsNullOrEmpty(_ProcessName) ? _modifiedCpu.NextValue() : _modifiedCpu.NextValue() / Environment.ProcessorCount;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
                }
                return value;
            }
        }

        public CPU(string ProcessName = "")
        {
            _ProcessName = ProcessName;
            if (string.IsNullOrEmpty(_ProcessName))
                _modifiedCpu = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
            else
                _modifiedCpu = new PerformanceCounter("Process", "% Processor Time", _ProcessName, true);
        }

        public void Close()
        {
            if (_modifiedCpu != null)
            {
                _modifiedCpu.Dispose();
                _modifiedCpu = null;
            }
        }

    }
}
