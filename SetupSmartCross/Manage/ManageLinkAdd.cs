using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using RexMapControl.Section;
using DevExpress.XtraGrid.Columns;
using RexMapControl.Object;
using DevExpress.XtraRichEdit.API.Native;
using Common;

namespace SetupSmartCross.Manage
{
    public partial class ManageLinkAdd : DevExpress.XtraEditors.XtraForm
    {
        private SectionLine sectionLine;
        private List<ObjectLinkPoint> dataList = new List<ObjectLinkPoint>();

        private bool isModify = false;
        private string _name;

        private int MinSpeed = 5;
        private int MaxSpeed = 90;
        public string name
        {
            get
            {
                return _name;
            }

        }

        private string _linkID;
        public string linkID
        {
            get
            {
                return _linkID;
            }
        }
        private string lastLinkID = null;

        #region 로그
        public void MakeLog(string sLog, int bScreen = 1)
        {
            string sMsg;

            sMsg = string.Format("[{0}] {1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, sLog);
            if (MV.LogCtrl != null)
                MV.LogCtrl.AddLog(sMsg, bScreen);

            Console.WriteLine(sMsg);
        }
        #endregion

        public ManageLinkAdd(bool isModify, SectionLine sectionLine)
        {
            InitializeComponent();
            this._linkID = sectionLine.objectLink.link_id == null ? "0" : sectionLine.objectLink.link_id;
            this.isModify = isModify;
            this.sectionLine = sectionLine;
            init();
        }

        public ManageLinkAdd(DataRowView dr)
        {
            InitializeComponent();
            this.isModify = true;
            this._linkID = dr["ID"].ToString();
            ModifyInit(dr);
        }

        public ManageLinkAdd()
        {
            InitializeComponent();
        }

        private void ModifyInit(DataRowView dr)
        {
            tbLinkID.Text = this._linkID;
            tbLinkName.Text = dr["NAME"].ToString();
            tbStartCross.Text = dr["s_cross_id"].ToString();
            tbEndCross.Text = dr["e_cross_id"].ToString();
            tbDistance.Text = dr["distance"].ToString();
            tbMinTravelTime.Text = dr["min_traveltime"].ToString();
            tbMaxTravelTime.Text = dr["max_traveltime"].ToString();
            tbFastSpeed.Text = dr["fast_speed"].ToString();
            tbSlowSpeed.Text = dr["slow_speed"].ToString();

            float distance = float.Parse(tbDistance.Text);
            this.distance = distance;
            int minTime = int.Parse(tbMinTravelTime.Text);
            int maxTime = int.Parse(tbMaxTravelTime.Text);

            tbMaxSpeed.Text = ((int)Math.Ceiling((distance * 3.6) / minTime)).ToString();
            tbMinSpeed.Text = ((int)Math.Ceiling((distance * 3.6) / maxTime)).ToString();

            if (dr["view_flag"].ToString() == "1")
                ckIsShow.Checked = true;

            DataTable dt = new DataTable();
            if (MV.DbManager.Fill(string.Format(MV.SQL.S_MST_LINK_UPDATE, this._linkID), dt) > 0)
            {
                gcClink.DataSource = dt;
            }
        }

        private void makeLInkID()
        {
            DataTable dt = new DataTable();

            try
            {
                if (MV.DbManager.Fill(string.Format(MV.SQL.S_MST_LINK_LAST), dt) > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        lastLinkID = dt.Rows[0]["link_id"].ToString();
                        if (lastLinkID != null)
                        {
                            string data = "L";
                            lastLinkID = lastLinkID.Replace("L", "");
                            int result = 0;
                            if (Int32.TryParse(lastLinkID, out result))
                            {
                                data += String.Format("{0:000000}", ++result);
                            }
                            tbLinkID.Text = data;
                        }
                    }
                    else
                    {
                        tbLinkID.Text = "L000001";
                    }
                }
                else
                {
                    tbLinkID.Text = "L000001";
                }
                _linkID = tbLinkID.Text;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                dt.Clear();
                dt.Dispose();
            }
            sectionLine.objectLink.link_id = tbLinkID.Text;
        }

        private void init()
        {
            tbLinkName.Properties.MaxLength = 20;

            if (sectionLine != null)
            {
                double distance = sectionLine.GetDistance();
                if (!isModify)
                {
                    makeLInkID();
                    tbSlowSpeed.Text = "20";
                    tbFastSpeed.Text = "40";
                    ckIsShow.Checked = true;
                    btnDelete.Visible = false;
                }
                else
                {
                    ckIsShow.Checked = sectionLine.objectLink.linkCheck;
                    tbLinkID.Text = sectionLine.objectLink.link_id;
                    tbSlowSpeed.Text = sectionLine.objectLink.slowSpeed.ToString();
                    tbFastSpeed.Text = sectionLine.objectLink.fastSpeed.ToString();
                    tbLinkName.Text = sectionLine.objectLink.name;
                    //tbMaxTravelTime.Text = sectionLine.objectLink.maxTravelTime.ToString();
                    //tbMinTravelTime.Text = sectionLine.objectLink.minTravelTime.ToString();

                    MaxSpeed = (int)Math.Ceiling((sectionLine.objectLink.distance * 3.6) / sectionLine.objectLink.minTravelTime);
                    MinSpeed = (int)Math.Ceiling((sectionLine.objectLink.distance * 3.6) / sectionLine.objectLink.maxTravelTime);
                    btnDelete.Visible = true;
                }
                tbMaxSpeed.Text = MaxSpeed.ToString();
                tbMinSpeed.Text = MinSpeed.ToString();
                tbMaxTravelTime.Text = ((int)Math.Ceiling((distance / MinSpeed) * 3.6)).ToString();
                tbMinTravelTime.Text = ((int)Math.Ceiling((distance / MaxSpeed) * 3.6)).ToString();

                tbDistance.Text = sectionLine.objectLink.distance.ToString();

                tbLinkName.Text = sectionLine.objectLink.name;
                tbStartCross.Text = sectionLine.objectLink.sCrossID;
                tbEndCross.Text = sectionLine.objectLink.eCrossID;
                this.distance = distance;

                ArrayList arrPoint = sectionLine.objectLink.arrPoint;
                for (int i = 0; i < arrPoint.Count; i++)
                {
                    ObjectLinkPoint sectPoint = arrPoint[i] as ObjectLinkPoint;
                    sectPoint.seq = (i + 1).ToString();
                    dataList.Add(sectPoint);
                }
                gcClink.DataSource = dataList;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupControl1.Controls)
            {
                if (typeof(TextEdit) == control.GetType())
                {
                    if (string.IsNullOrEmpty(control.Text))
                    {
                        XtraMessageBox.Show("비어있는 값이 있습니다.");
                        return;
                    }
                }
            }

            if (isModify)
            {
                if (!string.IsNullOrEmpty(tbLinkID.Text))
                {
                    string max = tbMaxTravelTime.Text.ToString();
                    string min = tbMinTravelTime.Text.ToString();
                    string distance = tbDistance.Text.ToString();
                    string fast = tbFastSpeed.Text.ToString();
                    string slow = tbSlowSpeed.Text.ToString();
                    string view_flag = (ckIsShow.Checked) ? "1" : "0";
                    string link_name = tbLinkName.Text.ToString();

                    if (Int32.Parse(tbMinSpeed.Text) > Int32.Parse(tbMaxSpeed.Text))
                    {
                        XtraMessageBox.Show("최소 속도가 최대 속도보다 클 수 없습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (link_name != null && link_name.Length > 20)
                    {
                        XtraMessageBox.Show("구간명이 20글자를 초과 할수 없습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                    if (MV.DbManager.Excute(string.Format(MV.SQL.U_MST_LINK, tbLinkID.Text, link_name, distance, min, max, fast, slow, view_flag)) < 0)
                    {
                    }
                    else
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(tbLinkID.Text))
                {
                    string max = tbMaxTravelTime.Text.ToString();
                    string min = tbMinTravelTime.Text.ToString();
                    string distance = tbDistance.Text.ToString();
                    string link_id = tbLinkID.Text;
                    string fast = tbFastSpeed.Text;
                    string slow = tbSlowSpeed.Text;
                    string view_flag = (ckIsShow.Checked) ? "1" : "0";
                    string link_name = tbLinkName.Text.ToString();

                    if (Int32.Parse(tbMinSpeed.Text) > Int32.Parse(tbMaxSpeed.Text))
                    {
                        XtraMessageBox.Show("최소 속도가 최대 속도보다 클 수 없습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (link_name != null && link_name.Length > 20)
                    {
                        XtraMessageBox.Show("구간명이 20글자를 초과 할수 없습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MV.DbManager.Excute(string.Format(MV.SQL.I_MST_LINK, link_id, link_name, tbStartCross.Text, tbEndCross.Text, distance, min, max, fast, slow, view_flag)) < 0)
                    {
                        var a = MV.DbManager.GetErrorMsg();
                        //MV.InsertDBLog(LogType.Error, string.Format("* 구간 입력 실패\nLinkID:{0}, 시작교차로: {1}, 도착교차로: {2} .  거리: {3} . 최소시간: {4} . 최대시간: {5} . 원활속도 : {6}  . 서행속도 : {7}", tbLinkID.Text, tbStartCross.Text, tbEndCross.Text, tbDistance.Text, tbMinTravelTime.Text, tbMaxTravelTime.Text, tbFastSpeed.Text, tbSlowSpeed.Text));
                    }
                    else
                    {
                        //MV.InsertDBLog(LogType.Nomal, string.Format("* 구간 입력 성공\nLinkID:{0}, 시작교차로: {1}, 도착교차로: {2} .  거리: {3} . 최소시간: {4} . 최대시간: {5} . 원활속도 : {6}  . 서행속도 : {7}", tbLinkID.Text, tbStartCross.Text, tbEndCross.Text, tbDistance.Text, tbMinTravelTime.Text, tbMaxTravelTime.Text, tbFastSpeed.Text, tbSlowSpeed.Text));
                        for (int i = 0; i < dataList.Count; i++)
                        {
                            ObjectLinkPoint point = dataList[i] as ObjectLinkPoint;
                            if (MV.DbManager.Excute(string.Format(MV.SQL.I_MST_LINK_POINT, link_id, (i + 1), point.X, point.Y)) < 0)
                            {
                                //MV.InsertDBLog(LogType.Error, string.Format("* 구간 포인트 입력 실패\nID:{0}, 시퀀스: {1}, X: {2} . Y: {3}, 사유 : {4}", link_id, (i + 1), point.X, point.Y, MV.DbManager.GetErrorMsg()));
                                XtraMessageBox.Show("저장 실패");
                                return;
                            }
                            else
                            {
                                //MV.InsertDBLog(LogType.Nomal, string.Format("* 구간 포인트 입력 성공\nID:{0}, 시퀀스: {1}, X: {2} . Y: {3} .", link_id, (i + 1), point.X, point.Y));
                            }
                        }
                        XtraMessageBox.Show("저장 완료");
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        _name = tbLinkName.Text;
                        this.Close();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (XtraMessageBox.Show("삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            bool isPointDelete = false;
            bool isLinkDelete = false;

            if (MV.DbManager.Excute(string.Format(MV.SQL.D_MST_LINK_POINT, tbLinkID.Text)) < 0)
            {
                //MV.InsertDBLog(LogType.Error, string.Format("* 구간 포인트 삭제 실패\nLinkID:{0}", tbLinkID.Text));
            }
            else
            {
                isPointDelete = true;
            }

            if (MV.DbManager.Excute(string.Format(MV.SQL.D_MST_LINK, tbLinkID.Text)) < 0)
            {
                //MV.InsertDBLog(LogType.Error, string.Format("* 구간 삭제 실패\nLinkID:{0}", tbLinkID.Text));
            }
            else
            {
                isLinkDelete = true;
            }

            if (isPointDelete || isLinkDelete)
            {
                XtraMessageBox.Show("삭제완료", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }



        }

        private double distance = 0;

        private void teSpeed_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(tbMaxSpeed))
                {
                    if (tbMaxSpeed.Text == "0")
                        tbMaxSpeed.Text = "1";

                    tbMinTravelTime.Text = Math.Ceiling((distance / double.Parse(tbMaxSpeed.Text)) * 3.6).ToString();
                }
                else
                {
                    if (tbMinSpeed.Text == "0")
                        tbMinSpeed.Text = "1";

                    tbMaxTravelTime.Text = Math.Ceiling((distance / double.Parse(tbMinSpeed.Text)) * 3.6).ToString();
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
            }
        }
    }
}