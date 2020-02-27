namespace PriceChecker
{
    partial class FrmHotels
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
            this.dgHotels = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStar = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.cxActiveOnly = new System.Windows.Forms.CheckBox();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHotelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCheckAllotment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgHotels)).BeginInit();
            this.SuspendLayout();
            // 
            // dgHotels
            // 
            this.dgHotels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHotels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmHotelName,
            this.clmCheckAllotment,
            this.clmIsActive,
            this.clmEdit});
            this.dgHotels.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgHotels.Location = new System.Drawing.Point(0, 61);
            this.dgHotels.Name = "dgHotels";
            this.dgHotels.RowHeadersWidth = 62;
            this.dgHotels.RowTemplate.Height = 28;
            this.dgHotels.Size = new System.Drawing.Size(1346, 497);
            this.dgHotels.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Star:";
            // 
            // txtStar
            // 
            this.txtStar.Location = new System.Drawing.Point(78, 17);
            this.txtStar.Name = "txtStar";
            this.txtStar.Size = new System.Drawing.Size(100, 26);
            this.txtStar.TabIndex = 2;
            this.txtStar.Text = "0";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(287, 11);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(79, 38);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(1007, 17);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(90, 38);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cxActiveOnly
            // 
            this.cxActiveOnly.AutoSize = true;
            this.cxActiveOnly.Checked = true;
            this.cxActiveOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cxActiveOnly.Location = new System.Drawing.Point(203, 19);
            this.cxActiveOnly.Name = "cxActiveOnly";
            this.cxActiveOnly.Size = new System.Drawing.Size(78, 24);
            this.cxActiveOnly.TabIndex = 4;
            this.cxActiveOnly.Text = "Active";
            this.cxActiveOnly.UseVisualStyleBackColor = true;
            // 
            // clmId
            // 
            this.clmId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmId.DataPropertyName = "HotelId";
            this.clmId.HeaderText = "Id";
            this.clmId.MinimumWidth = 8;
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            this.clmId.Width = 59;
            // 
            // clmHotelName
            // 
            this.clmHotelName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmHotelName.DataPropertyName = "HotelName";
            this.clmHotelName.HeaderText = "Hotel Name";
            this.clmHotelName.MinimumWidth = 8;
            this.clmHotelName.Name = "clmHotelName";
            this.clmHotelName.ReadOnly = true;
            // 
            // clmCheckAllotment
            // 
            this.clmCheckAllotment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmCheckAllotment.DataPropertyName = "CheckAllotment";
            this.clmCheckAllotment.HeaderText = "Check Allotment";
            this.clmCheckAllotment.MinimumWidth = 8;
            this.clmCheckAllotment.Name = "clmCheckAllotment";
            this.clmCheckAllotment.ReadOnly = true;
            this.clmCheckAllotment.Width = 118;
            // 
            // clmIsActive
            // 
            this.clmIsActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmIsActive.DataPropertyName = "IsActive";
            this.clmIsActive.HeaderText = "IsActive";
            this.clmIsActive.MinimumWidth = 8;
            this.clmIsActive.Name = "clmIsActive";
            this.clmIsActive.ReadOnly = true;
            this.clmIsActive.Width = 71;
            // 
            // clmEdit
            // 
            this.clmEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmEdit.HeaderText = "";
            this.clmEdit.MinimumWidth = 8;
            this.clmEdit.Name = "clmEdit";
            this.clmEdit.ReadOnly = true;
            this.clmEdit.Text = "Edit";
            this.clmEdit.UseColumnTextForLinkValue = true;
            this.clmEdit.Width = 27;
            // 
            // FrmHotels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 558);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cxActiveOnly);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtStar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgHotels);
            this.Name = "FrmHotels";
            this.Text = "FrmHotels";
            this.Load += new System.EventHandler(this.FrmHotels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgHotels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgHotels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStar;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.CheckBox cxActiveOnly;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHotelName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCheckAllotment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmIsActive;
        private System.Windows.Forms.DataGridViewLinkColumn clmEdit;
    }
}