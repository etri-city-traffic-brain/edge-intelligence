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

namespace Common
{
    public enum SavePageSelect
    {
        AllPage,
        CurrentPage,
        SelectPage
    }

    public partial class SaveExcelFileOption : DevExpress.XtraEditors.XtraForm
    {

        public SavePageSelect SavePageSelect = SavePageSelect.AllPage;
        public string SelectValue = string.Empty;

        public SaveExcelFileOption()
        {
            InitializeComponent();
        }

        private void SaveExcelFileOption_Load(object sender, EventArgs e)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkAllPage.Checked == true)
            {
                SavePageSelect = SavePageSelect.AllPage;
            } 
            else if (chkCurrentPage.Checked == true)
            {
                SavePageSelect = SavePageSelect.CurrentPage;
            }
            else if (chkSelectPage.Checked == true)
            {
                SavePageSelect = SavePageSelect.SelectPage;

                if (!SelectValueCheck())
                {
                    XtraMessageBox.Show(this, "선택 페이지 값이 형식에 맞지 않습니다.", "선택 페이지", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbSelectValue.Focus();
                    return;
                }

                SelectValue = tbSelectValue.Text;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private bool SelectValueCheck()
        {
            bool result = true;

            try
            {
                string[] values = tbSelectValue.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                if (values != null && values.Count() == 2)
                {
                    int StartPage = 1;
                    int EndPage = 1;

                    if (!int.TryParse(values[0].Trim(), out StartPage) || !int.TryParse(values[1].Trim(), out EndPage))
                        result = false;

                    if (StartPage > EndPage)
                    {
                        result = false;
                    }
                }
                else
                    result = false;
            }
            catch(Exception ex)
            {
                result = false;
            }

            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void chkSelectPage_CheckedChanged(object sender, EventArgs e)
        {
            tbSelectValue.Enabled = chkSelectPage.Checked;
        }
    }
}