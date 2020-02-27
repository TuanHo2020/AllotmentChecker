namespace PriceChecker
{
    partial class frmCities
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
            this.dgCities = new System.Windows.Forms.DataGridView();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgCities)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCities
            // 
            this.dgCities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmCityName,
            this.clmCityCode,
            this.clmEdit});
            this.dgCities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCities.Location = new System.Drawing.Point(0, 0);
            this.dgCities.Name = "dgCities";
            this.dgCities.RowTemplate.Height = 28;
            this.dgCities.Size = new System.Drawing.Size(467, 406);
            this.dgCities.TabIndex = 0;
            // 
            // clmId
            // 
            this.clmId.DataPropertyName = "cityId";
            this.clmId.HeaderText = "Id";
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            // 
            // clmCityName
            // 
            this.clmCityName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmCityName.DataPropertyName = "CityName";
            this.clmCityName.HeaderText = "City Name";
            this.clmCityName.Name = "clmCityName";
            this.clmCityName.ReadOnly = true;
            // 
            // clmCityCode
            // 
            this.clmCityCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmCityCode.DataPropertyName = "CityCode";
            this.clmCityCode.HeaderText = "City Code";
            this.clmCityCode.Name = "clmCityCode";
            this.clmCityCode.ReadOnly = true;
            this.clmCityCode.Width = 113;
            // 
            // clmEdit
            // 
            this.clmEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmEdit.HeaderText = "";
            this.clmEdit.Name = "clmEdit";
            this.clmEdit.ReadOnly = true;
            this.clmEdit.Text = "Edit";
            this.clmEdit.UseColumnTextForLinkValue = true;
            this.clmEdit.Width = 27;
            // 
            // frmCities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 406);
            this.Controls.Add(this.dgCities);
            this.Name = "frmCities";
            this.Text = "frmCities";
            this.Load += new System.EventHandler(this.frmCities_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCities;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCityCode;
        private System.Windows.Forms.DataGridViewLinkColumn clmEdit;
    }
}