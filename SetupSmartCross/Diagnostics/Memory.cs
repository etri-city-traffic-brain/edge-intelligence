using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace SetupSmartCross.Diagnostics
{
    public class Memory
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPhysicallyInstalledSystemMemory(out ulong MemoryInKilobytes);

        [DllImport("psapi.dll", SetLastError = true)]
        public static extern bool GetPerformanceInfo(out PERFORMANCE_INFORMATION pPerformanceInformation, uint cb);

        [StructLayout(LayoutKind.Sequential)]
        public struct PERFORMANCE_INFORMATION
        {
            public uint cb;
            UIntPtr CommitTotal;
            UIntPtr CommitLimit;
            UIntPtr CommitPeak;
            UIntPtr PhysicalTotal;
            UIntPtr PhysicalAvailable;
            UIntPtr SystemCache;
            UIntPtr KernelTotal;
            UIntPtr KernelPaged;
            UIntPtr KernelNonpaged;
            UIntPtr PageSize;
            uint HandleCount;
            uint ProcessCount;
            uint ThreadCount;

            public void Initialize()
            {
                this.cb = (uint)Marshal.SizeOf(typeof(PERFORMANCE_INFORMATION));
            }

            ulong Page
            {
                get { return PageSize.ToUInt64(); }
            }

            public ulong Total
            {
                get
                {
                    return PhysicalTotal.ToUInt64() * Page;
                }
            }

            public ulong Available
            {
                get
                {
                    return PhysicalAvailable.ToUInt64() * Page;
                }
            }

            public ulong Cache
            {
                get
                {
                    return SystemCache.ToUInt64() * Page;
                }
            }

            public ulong KernelNonPage
            {
                get
                {
                    return KernelNonpaged.ToUInt64() * Page;
                }
            }

            public ulong KernelPage
            {
                get
                {
                    return KernelPaged.ToUInt64() * Page;
                }
            }

            public ulong Commit
            {
                get
                {
                    return CommitTotal.ToUInt64() * Page;
                }
            }
        }
        /// <summary>
        /// 프로세스명
        /// </summary>
        private string _ProcessName = string.Empty;
        public string ProcessName
        {
            get { return _ProcessName; }
        }

        /// <summary>
        ///  전체 사용가능량
        /// </summary>
        private float _Usage = 0;
        public float Usage  // 전체 사용가능량
        {
            get { return _Usage; }
        }

        /// <summary>
        /// 전체 물리적 사용가능량
        /// </summary>
        private float _InstalledMemory = 0;
        public float InstalledMemory // 전체 물리적 사용가능량
        {
            get { return _InstalledMemory; }
        }

        /// <summary>
        /// 실제 사용중인양
        /// </summary>
        private float _UseMemory = 0;
        public float UseMemory  // 실제 사용중인양
        {
            get { return _UseMemory; }
        }

        /// <summary>
        /// 실제 사용율
        /// </summary>
        public float UsagePercent // 실제 사용율
        {
            get
            {
                float memory = _Usage <= 0 ? 0 : _UseMemory / _Usage * 100;
                if (float.IsNaN(memory))
                    memory = 0;

                return memory;
            }
        }

        private PerformanceCounter _modifiedMemory;

        public Memory(string ProcessName = "")
        {
            _ProcessName = ProcessName;
            if (string.IsNullOrEmpty(_ProcessName))
                _modifiedMemory = new PerformanceCounter("Memory", "Modified Page List Bytes", true);
            else
                _modifiedMemory = new PerformanceCounter("Process", "Working Set - Private", _ProcessName, true);
        }


        public void GetMemory()
        {
            try
            {
                PERFORMANCE_INFORMATION pi = new PERFORMANCE_INFORMATION();
                pi.Initialize();
                GetPerformanceInfo(out pi, pi.cb);

                ulong modified = (ulong)_modifiedMemory.RawValue;
                ulong inuse = pi.Total - pi.Available - modified;

                if (!string.IsNullOrEmpty(_modifiedMemory.InstanceName))
                    inuse = modified;

                ulong InstalledSystemMemory = 0;
                GetPhysicallyInstalledSystemMemory(out InstalledSystemMemory);

                _InstalledMemory = (float)InstalledSystemMemory / 1024.0f / 1024.0f;

                _Usage = (float)pi.Total / 1024.0f / 1024.0f / 1024.0f;

                _UseMemory = (float)inuse / 1024.0f / 1024.0f / 1024.0f;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        public void Close()
        {
            if (_modifiedMemory != null)
            {
                _modifiedMemory.Dispose();
                _modifiedMemory = null;
            }
        }

    }
}
