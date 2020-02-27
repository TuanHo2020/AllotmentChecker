namespace PriceChecker
{
    partial class FrmHotelCloseDateViewer
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
            this.dgRecords = new System.Windows.Forms.DataGridView();
            this.clmRecordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAllotment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAcknowledged = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmRemove = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cxNotAcknowledgedOnly = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbRoomTypes = new System.Windows.Forms.ComboBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.cxNotAcknowledged = new System.Windows.Forms.CheckBox();
            this.btnExportCsv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // dgRecords
            // 
            this.dgRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmRecordId,
            this.clmDate,
            this.clmRoomType,
            this.clmAllotment,
            this.clmAcknowledged,
            this.clmRemove});
            this.dgRecords.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgRecords.Location = new System.Drawing.Point(0, 132);
            this.dgRecords.Name = "dgRecords";
            this.dgRecords.RowHeadersWidth = 62;
            this.dgRecords.RowTemplate.Height = 28;
            this.dgRecords.Size = new System.Drawing.Size(1122, 404);
            this.dgRecords.TabIndex = 0;
            // 
            // clmRecordId
            // 
            this.clmRecordId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmRecordId.DataPropertyName = "RecordId";
            this.clmRecordId.HeaderText = "RecordId";
            this.clmRecordId.MinimumWidth = 8;
            this.clmRecordId.Name = "clmRecordId";
            this.clmRecordId.ReadOnly = true;
            this.clmRecordId.Width = 111;
            // 
            // clmDate
            // 
            this.clmDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmDate.DataPropertyName = "Date";
            this.clmDate.HeaderText = "Date";
            this.clmDate.MinimumWidth = 8;
            this.clmDate.Name = "clmDate";
            this.clmDate.ReadOnly = true;
            // 
            // clmRoomType
            // 
            this.clmRoomType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmRoomType.DataPropertyName = "RoomName";
            this.clmRoomType.HeaderText = "RoomType";
            this.clmRoomType.MinimumWidth = 8;
            this.clmRoomType.Name = "clmRoomType";
            this.clmRoomType.ReadOnly = true;
            this.clmRoomType.Width = 122;
            // 
            // clmAllotment
            // 
            this.clmAllotment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmAllotment.DataPropertyName = "CurrentAllotment";
            this.clmAllotment.HeaderText = "Allotment";
            this.clmAllotment.MinimumWidth = 8;
            this.clmAllotment.Name = "clmAllotment";
            this.clmAllotment.ReadOnly = true;
            this.clmAllotment.Width = 112;
            // 
            // clmAcknowledged
            // 
            this.clmAcknowledged.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmAcknowledged.DataPropertyName = "Acknowledged";
            this.clmAcknowledged.FalseValue = "false";
            this.clmAcknowledged.HeaderText = "Acknowledged";
            this.clmAcknowledged.MinimumWidth = 8;
            this.clmAcknowledged.Name = "clmAcknowledged";
            this.clmAcknowledged.TrueValue = "true";
            this.clmAcknowledged.Width = 119;
            // 
            // clmRemove
            // 
            this.clmRemove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmRemove.HeaderText = "";
            this.clmRemove.MinimumWidth = 8;
            this.clmRemove.Name = "clmRemove";
            this.clmRemove.Text = "Remove";
            this.clmRemove.UseColumnTextForLinkValue = true;
            this.clmRemove.Width = 27;
            // 
            // cxNotAcknowledgedOnly
            // 
            this.cxNotAcknowledgedOnly.AutoSize = true;
            this.cxNotAcknowledgedOnly.Location = new System.Drawing.Point(23, 24);
            this.cxNotAcknowledgedOnly.Name = "cxNotAcknowledgedOnly";
            this.cxNotAcknowledgedOnly.Size = new System.Drawing.Size(203, 24);
            this.cxNotAcknowledgedOnly.TabIndex = 1;
            this.cxNotAcknowledgedOnly.Text = "Not Acknowledged Only";
            this.cxNotAcknowledgedOnly.UseVisualStyleBackColor = true;
            this.cxNotAcknowledgedOnly.CheckedChanged += new System.EventHandler(this.cxNotAcknowledgedOnly_CheckedChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(601, 18);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 35);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbRoomTypes
            // 
            this.cmbRoomTypes.DisplayMember = "RoomName";
            this.cmbRoomTypes.FormattingEnabled = true;
            this.cmbRoomTypes.Location = new System.Drawing.Point(245, 20);
            this.cmbRoomTypes.Name = "cmbRoomTypes";
            this.cmbRoomTypes.Size = new System.Drawing.Size(251, 28);
            this.cmbRoomTypes.TabIndex = 4;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(502, 20);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(93, 31);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(1003, 18);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(100, 35);
            this.btnRemoveAll.TabIndex = 7;
            this.btnRemoveAll.Text = "Remove";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // cxNotAcknowledged
            // 
            this.cxNotAcknowledged.AutoSize = true;
            this.cxNotAcknowledged.Checked = true;
            this.cxNotAcknowledged.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cxNotAcknowledged.Location = new System.Drawing.Point(725, 24);
            this.cxNotAcknowledged.Name = "cxNotAcknowledged";
            this.cxNotAcknowledged.Size = new System.Drawing.Size(262, 24);
            this.cxNotAcknowledged.TabIndex = 10;
            this.cxNotAcknowledged.Text = "Remove not acknowledged Only";
            this.cxNotAcknowledged.UseVisualStyleBackColor = true;
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Location = new System.Drawing.Point(23, 71);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(161, 33);
            this.btnExportCsv.TabIndex = 11;
            this.btnExportCsv.Text = "Export CSV";
            this.btnExportCsv.UseVisualStyleBackColor = true;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            // 
            // FrmHotelCloseDateViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 536);
            this.Controls.Add(this.btnExportCsv);
            this.Controls.Add(this.cxNotAcknowledged);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.cmbRoomTypes);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cxNotAcknowledgedOnly);
            this.Controls.Add(this.dgRecords);
            this.Name = "FrmHotelCloseDateViewer";
            this.Text = "FrmAllotmentRecordViewer";
            this.Load += new System.EventHandler(this.FrmAllotmentRecordViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgRecords;
        private System.Windows.Forms.CheckBox cxNotAcknowledgedOnly;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cmbRoomTypes;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRecordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAllotment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmAcknowledged;
        private System.Windows.Forms.DataGridViewLinkColumn clmRemove;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.CheckBox cxNotAcknowledged;
        private System.Windows.Forms.Button btnExportCsv;
    }
}