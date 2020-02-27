namespace PriceChecker
{
    partial class FrmAllotmentMain
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
            this.btnAllotmentReport = new System.Windows.Forms.Button();
            this.btnAllotmentHotels = new System.Windows.Forms.Button();
            this.btnAllotmentChecker = new System.Windows.Forms.Button();
            this.btnAllConfigs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAllotmentReport
            // 
            this.btnAllotmentReport.Location = new System.Drawing.Point(22, 61);
            this.btnAllotmentReport.Name = "btnAllotmentReport";
            this.btnAllotmentReport.Size = new System.Drawing.Size(170, 37);
            this.btnAllotmentReport.TabIndex = 16;
            this.btnAllotmentReport.Text = "Allotment Report";
            this.btnAllotmentReport.UseVisualStyleBackColor = true;
            this.btnAllotmentReport.Click += new System.EventHandler(this.btnAllotmentReport_Click);
            // 
            // btnAllotmentHotels
            // 
            this.btnAllotmentHotels.Location = new System.Drawing.Point(22, 105);
            this.btnAllotmentHotels.Name = "btnAllotmentHotels";
            this.btnAllotmentHotels.Size = new System.Drawing.Size(170, 33);
            this.btnAllotmentHotels.TabIndex = 15;
            this.btnAllotmentHotels.Text = "Allotment Hotels";
            this.btnAllotmentHotels.UseVisualStyleBackColor = true;
            this.btnAllotmentHotels.Click += new System.EventHandler(this.btnAllotmentHotels_Click);
            // 
            // btnAllotmentChecker
            // 
            this.btnAllotmentChecker.Location = new System.Drawing.Point(22, 21);
            this.btnAllotmentChecker.Name = "btnAllotmentChecker";
            this.btnAllotmentChecker.Size = new System.Drawing.Size(170, 34);
            this.btnAllotmentChecker.TabIndex = 18;
            this.btnAllotmentChecker.Text = "Allotment Checker";
            this.btnAllotmentChecker.UseVisualStyleBackColor = true;
            this.btnAllotmentChecker.Click += new System.EventHandler(this.btnAllotmentChecker_Click);
            // 
            // btnAllConfigs
            // 
            this.btnAllConfigs.Location = new System.Drawing.Point(22, 144);
            this.btnAllConfigs.Name = "btnAllConfigs";
            this.btnAllConfigs.Size = new System.Drawing.Size(170, 41);
            this.btnAllConfigs.TabIndex = 19;
            this.btnAllConfigs.Text = "Configs";
            this.btnAllConfigs.UseVisualStyleBackColor = true;
            this.btnAllConfigs.Click += new System.EventHandler(this.btnAllConfigs_Click);
            // 
            // FrmAllotmentMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Controls.Add(this.btnAllConfigs);
            this.Controls.Add(this.btnAllotmentChecker);
            this.Controls.Add(this.btnAllotmentReport);
            this.Controls.Add(this.btnAllotmentHotels);
            this.Name = "FrmAllotmentMain";
            this.Text = "FrmAllotmentMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAllotmentReport;
        private System.Windows.Forms.Button btnAllotmentHotels;
        private System.Windows.Forms.Button btnAllotmentChecker;
        private System.Windows.Forms.Button btnAllConfigs;
    }
}