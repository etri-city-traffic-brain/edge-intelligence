namespace SetupSmartCross.Forms
{
    partial class MapMonitoring
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.elementHostMap = new System.Windows.Forms.Integration.ElementHost();
            this.SuspendLayout();
            // 
            // elementHostMap
            // 
            this.elementHostMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostMap.Location = new System.Drawing.Point(0, 0);
            this.elementHostMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.elementHostMap.Name = "elementHostMap";
            this.elementHostMap.Size = new System.Drawing.Size(658, 546);
            this.elementHostMap.TabIndex = 22;
            this.elementHostMap.Text = "elementHost1";
            this.elementHostMap.Child = null;
            // 
            // MapMonitoring
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.elementHostMap);
            this.Name = "MapMonitoring";
            this.Size = new System.Drawing.Size(658, 546);
            this.Load += new System.EventHandler(this.MapMonitoring_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHostMap;
    }
}
