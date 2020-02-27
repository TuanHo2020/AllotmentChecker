namespace PriceChecker
{
    partial class FrmAllConfigs
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
            this.btnHotelList = new System.Windows.Forms.Button();
            this.btnCityList = new System.Windows.Forms.Button();
            this.btnXPathConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHotelList
            // 
            this.btnHotelList.Location = new System.Drawing.Point(54, 18);
            this.btnHotelList.Name = "btnHotelList";
            this.btnHotelList.Size = new System.Drawing.Size(170, 33);
            this.btnHotelList.TabIndex = 8;
            this.btnHotelList.Text = "Full Hotel List";
            this.btnHotelList.UseVisualStyleBackColor = true;
            this.btnHotelList.Click += new System.EventHandler(this.btnHotelList_Click);
            // 
            // btnCityList
            // 
            this.btnCityList.Location = new System.Drawing.Point(54, 126);
            this.btnCityList.Name = "btnCityList";
            this.btnCityList.Size = new System.Drawing.Size(170, 36);
            this.btnCityList.TabIndex = 11;
            this.btnCityList.Text = "City List";
            this.btnCityList.UseVisualStyleBackColor = true;
            this.btnCityList.Click += new System.EventHandler(this.btnCityList_Click);
            // 
            // btnXPathConfig
            // 
            this.btnXPathConfig.Location = new System.Drawing.Point(54, 70);
            this.btnXPathConfig.Name = "btnXPathConfig";
            this.btnXPathConfig.Size = new System.Drawing.Size(170, 30);
            this.btnXPathConfig.TabIndex = 13;
            this.btnXPathConfig.Text = "XPath Config";
            this.btnXPathConfig.UseVisualStyleBackColor = true;
            this.btnXPathConfig.Click += new System.EventHandler(this.btnXPathConfig_Click);
            // 
            // FrmAllConfigs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Controls.Add(this.btnXPathConfig);
            this.Controls.Add(this.btnCityList);
            this.Controls.Add(this.btnHotelList);
            this.Name = "FrmAllConfigs";
            this.Text = "FrmAllConfigs";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnHotelList;
        private System.Windows.Forms.Button btnCityList;
        private System.Windows.Forms.Button btnXPathConfig;
    }
}