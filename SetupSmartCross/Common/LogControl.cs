using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.IO;

namespace Common
{
    public class LogControl
    {
        private string[] m_sDay = new string[7];
        private string m_sSubPath;
        private string m_sLastSaveDate;
        private ListView m_pListView;
        private ArrayList m_List;
        private System.Threading.Timer m_pTimer = null;
        private int m_nMaxScreenLine;

        public bool m_bEnabled;
        private bool m_bTerminated;

        public Thread thread = null;

        public LogControl(string sSubPath, ListView pListView, int nMaxScreenLine)
        {
            m_bTerminated = false;
            m_bEnabled = true;
            m_sSubPath = sSubPath;
            if (!Path.IsPathRooted(m_sSubPath))
                m_sSubPath = string.Format(@"{0}\{1}", Application.StartupPath, m_sSubPath);

            m_pListView = pListView;
            m_nMaxScreenLine = nMaxScreenLine;
            m_pTimer = null;
            m_List = new ArrayList();
        }

        #region 폴더 체크 및 폴더생성
        private void chkFolder(string sPath)
        {
            DirectoryInfo di = new DirectoryInfo(sPath);
            if (di.Exists == false)
            {
                di.Create(); //경로안의 모든폴더 생성
            }
        }
        #endregion

        private void Init()
        {
            m_sDay[0] = "1_일요일";
            m_sDay[1] = "2_월요일";
            m_sDay[2] = "3_화요일";
            m_sDay[3] = "4_수요일";
            m_sDay[4] = "5_목요일";
            m_sDay[5] = "6_금요일";
            m_sDay[6] = "7_토요일";

            m_sLastSaveDate = DateTime.Now.ToString("yyyyMMdd");

            chkFolder(m_sSubPath);

            for (int i = 0; i < 7; i++) {
                chkFolder(m_sSubPath + "\\" + m_sDay[i]);
            }

            m_pTimer = new System.Threading.Timer(m_pTimer_Tick);
            //m_pTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            m_pTimer.Change(1000, 60 * 1000);
        }

        public void m_pTimer_Tick(Object state)
        {
            string sFile;
            DirectoryInfo ff = null;

            if (m_sLastSaveDate != DateTime.Now.ToString("yyyyMMdd"))
            {
                m_sLastSaveDate = DateTime.Now.ToString("yyyyMMdd");

                sFile = string.Format("{0}\\{1}\\", m_sSubPath, m_sDay[Convert.ToInt32(DateTime.Now.DayOfWeek)]);
                ff = new DirectoryInfo(sFile);

                foreach (FileInfo f in ff.GetFiles())
                {

                    if (m_sLastSaveDate == f.Name.Remove(8))
                        continue;

                    try
                    {
                        f.Delete();
                    }
                    catch (Exception ex)
                    {
                        AddLog(string.Format("[LogWorker] Exception : {0}", ex.Message), 1);
                    }
                }
            }
        }

        public void AddLog(string sLog, int nScreen)
        {
	        string	sMsg;

	        sMsg = string.Format("{0}{1}", nScreen ,sLog);
            if (sMsg != null)
            {
                lock (m_List)
                {
                    try
                    {
                        m_List.Add(sMsg);
                    }
                    catch(Exception Ex)
                    {

                    }
                }
            }	       
        }

        #region 스레드 시작
        public void StartThread()
        {
            thread = new Thread(new ParameterizedThreadStart(StartThr));
            thread.Start(this);
        }
        #endregion

        #region 스레드 종료
        public void Close()
        {
            m_bTerminated = true;
            //if (null != thread)
            //{
            //    thread.Abort();
            //    thread = null;
            //}
        }
        #endregion

        #region 스레드 동작
        private void StartThr(object obj)
        {
            Init();

            Work();

            Close();
        }
        #endregion

        private void Work()
        {
	        string	sLog ;

	        while (!m_bTerminated) { 
		        Thread.Sleep(1);

		        if (!m_bEnabled)
			        continue;

                if (m_List.Count > 0)
                {
                    try
                    {

                        object obj = m_List[0];

                        sLog = "";
                        if (obj != null)
                        {
                            sLog = obj.ToString();
                            WriteLog(sLog);
                        }
                    }
                    catch (Exception ex)
                    {
                        //AddLog(string.Format("[LogWorker] Exception : {0}", ex.Message), 1);
                    }
                    lock (m_List)
                    {

                        if (m_List.Count > 0)
                            m_List.RemoveAt(0);
                    }
                }
	        }
        }

        private void WriteLog(string sLog)
        {
            string sFileName = "";
            string sMsg = "";
            FileStream fs = null;
            StreamWriter writer = null;
	        int	nScreen = 0;

            nScreen = Convert.ToInt32(sLog.Remove(1));

	        try
            {
		        sFileName = string.Format("{0}\\{1}\\{2}.log", m_sSubPath, m_sDay[Convert.ToInt32(DateTime.Now.DayOfWeek)], DateTime.Now.ToString("yyyyMMddHH"));

                sMsg = string.Format("{0} - {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), sLog.Substring(1));

		        if (nScreen < 2) {
                    fs = new FileStream(sFileName, FileMode.Append);

                    writer = new StreamWriter(fs, System.Text.Encoding.Unicode);

                    writer.WriteLine(sMsg.ToString());
                    writer.Dispose();
                    //writer.Close();
                    fs.Dispose();
                    //fs.Close();
		        }
            }
	        catch(Exception ex)
	        {
                //AddLog(string.Format("[LogWorker] Exception : {0}, sFileName: {1}", ex.Message, sFileName), 1);
	        }

            try
            {
                if (!m_bTerminated && nScreen > 0 && m_pListView != null && m_nMaxScreenLine > 0)
                {
                    m_pListView.Invoke((MethodInvoker)delegate
                    {
                        while (!m_bTerminated && GetCount() >= m_nMaxScreenLine)
                        {
                            if (m_pListView != null)
                                m_pListView.Items.RemoveAt(GetCount() - 1);
                        }

                        if (m_pListView != null)
                        {
                            m_pListView.Items.Insert(0, sMsg);
                        }
                    });
                    
		        }
	        }
	        catch(Exception ex)
	        {
                //AddLog(string.Format("[LogWorker] Exception : {0}", ex.Message), 1);
	        }

        }

        private int GetCount()
        {
            if (m_pListView == null)
                return 0;

            return m_pListView.Items.Count;
        }

    }
}
