
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    static class CommonFunction
    {

        public static void SimpleInvoke(Control control, Action dowork)
        {
            if (control.IsHandleCreated)
            {
                if (control.InvokeRequired)
                {
                    control.Invoke((MethodInvoker)delegate
                    {
                        dowork();
                    });
                }
                else
                    dowork();
            }
        }

        public static void SimpleWorker(Action dowork, Action completed = null)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (s, e) =>
            {
                if (dowork != null)
                    dowork();
            };
            bw.RunWorkerCompleted += (s, e) =>
            {
                if (completed != null)
                    completed();
                (s as BackgroundWorker).Dispose();
            };
            bw.RunWorkerAsync();
        }
    }


}
