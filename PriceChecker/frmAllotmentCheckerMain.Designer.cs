namespace PriceChecker
{
    partial class frmAllotmentCheckerMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnOpenBrowser = new System.Windows.Forms.Button();
            this.cxAllHotels = new System.Windows.Forms.CheckBox();
            this.lstHotelList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(392, 12);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(480, 563);
            this.txtProgress.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(21, 537);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(77, 33);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(104, 537);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(79, 33);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnOpenBrowser
            // 
            this.btnOpenBrowser.Location = new System.Drawing.Point(94, 21);
            this.btnOpenBrowser.Name = "btnOpenBrowser";
            this.btnOpenBrowser.Size = new System.Drawing.Size(161, 32);
            this.btnOpenBrowser.TabIndex = 7;
            this.btnOpenBrowser.Text = "Open Browser";
            this.btnOpenBrowser.UseVisualStyleBackColor = true;
            this.btnOpenBrowser.Click += new System.EventHandler(this.btnOpenBrowser_Click);
            // 
            // cxAllHotels
            // 
            this.cxAllHotels.AutoSize = true;
            this.cxAllHotels.Location = new System.Drawing.Point(94, 78);
            this.cxAllHotels.Name = "cxAllHotels";
            this.cxAllHotels.Size = new System.Drawing.Size(151, 24);
            this.cxAllHotels.TabIndex = 8;
            this.cxAllHotels.Text = "Select All Hotels";
            this.cxAllHotels.UseVisualStyleBackColor = true;
            this.cxAllHotels.CheckedChanged += new System.EventHandler(this.cxAllHotels_CheckedChanged);
            // 
            // lstHotelList
            // 
            this.lstHotelList.DisplayMember = "HotelName";
            this.lstHotelList.FormattingEnabled = true;
            this.lstHotelList.ItemHeight = 20;
            this.lstHotelList.Location = new System.Drawing.Point(18, 127);
            this.lstHotelList.Name = "lstHotelList";
            this.lstHotelList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstHotelList.Size = new System.Drawing.Size(351, 384);
            this.lstHotelList.TabIndex = 9;
            // 
            // frmAllotmentCheckerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 582);
            this.Controls.Add(this.lstHotelList);
            this.Controls.Add(this.cxAllHotels);
            this.Controls.Add(this.btnOpenBrowser);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtProgress);
            this.Name = "frmAllotmentCheckerMain";
            this.Text = "frmAllotmentCheckerMain";
            this.Load += new System.EventHandler(this.frmAllotmentCheckerMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnOpenBrowser;
        private System.Windows.Forms.CheckBox cxAllHotels;
        private System.Windows.Forms.ListBox lstHotelList;
    }
}