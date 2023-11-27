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

namespace SetupSmartCross.Forms
{
    public partial class SearchLink : DevExpress.XtraEditors.XtraForm
    {
        private LinkTrafficLog _LinkTrafficLog = new LinkTrafficLog();
        private LinkTrafficeStats _LinkTrafficeStats = new LinkTrafficeStats();

        public SearchLink()
        {
            InitializeComponent();
            
            _LinkTrafficLog.Dock = DockStyle.Fill;
            _LinkTrafficeStats.Dock = DockStyle.Fill;

            xtraTabPageLog.Controls.Add(_LinkTrafficLog);
            xtraTabPageStats.Controls.Add(_LinkTrafficeStats);
        }

        private void SearchLink_Load(object sender, EventArgs e)
        {
        }
    }
}