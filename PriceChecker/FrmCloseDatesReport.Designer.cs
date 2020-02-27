namespace PriceChecker
{
    partial class FrmCloseDateReport
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
            this.btnUpdateAndRefresh = new System.Windows.Forms.Button();
            this.btnRemoveNotAcknowledged = new System.Windows.Forms.Button();
            this.btnExportXML = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.cxMarkAsAcknowledged = new System.Windows.Forms.CheckBox();
            this.clmRecordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAcknowledged = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.clmHotel,
            this.clmAcknowledged});
            this.dgRecords.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgRecords.Location = new System.Drawing.Point(0, 75);
            this.dgRecords.Name = "dgRecords";
            this.dgRecords.RowHeadersWidth = 62;
            this.dgRecords.RowTemplate.Height = 28;
            this.dgRecords.Size = new System.Drawing.Size(1241, 557);
            this.dgRecords.TabIndex = 0;
            // 
            // btnUpdateAndRefresh
            // 
            this.btnUpdateAndRefresh.Location = new System.Drawing.Point(641, 13);
            this.btnUpdateAndRefresh.Name = "btnUpdateAndRefresh";
            this.btnUpdateAndRefresh.Size = new System.Drawing.Size(175, 40);
            this.btnUpdateAndRefresh.TabIndex = 1;
            this.btnUpdateAndRefresh.Text = "Update";
            this.btnUpdateAndRefresh.UseVisualStyleBackColor = true;
            this.btnUpdateAndRefresh.Click += new System.EventHandler(this.btnUpdateAndRefresh_Click);
            // 
            // btnRemoveNotAcknowledged
            // 
            this.btnRemoveNotAcknowledged.Location = new System.Drawing.Point(822, 13);
            this.btnRemoveNotAcknowledged.Name = "btnRemoveNotAcknowledged";
            this.btnRemoveNotAcknowledged.Size = new System.Drawing.Size(241, 39);
            this.btnRemoveNotAcknowledged.TabIndex = 4;
            this.btnRemoveNotAcknowledged.Text = "Remove Not Acknowledged";
            this.btnRemoveNotAcknowledged.UseVisualStyleBackColor = true;
            this.btnRemoveNotAcknowledged.Click += new System.EventHandler(this.btnRemoveNotAcknowledged_Click);
            // 
            // btnExportXML
            // 
            this.btnExportXML.Location = new System.Drawing.Point(343, 13);
            this.btnExportXML.Name = "btnExportXML";
            this.btnExportXML.Size = new System.Drawing.Size(150, 40);
            this.btnExportXML.TabIndex = 5;
            this.btnExportXML.Text = "Export CSV";
            this.btnExportXML.UseVisualStyleBackColor = true;
            this.btnExportXML.Click += new System.EventHandler(this.btnExportXML_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(1067, 13);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(162, 40);
            this.btnRemoveAll.TabIndex = 6;
            this.btnRemoveAll.Text = "Remove All Records";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // cxMarkAsAcknowledged
            // 
            this.cxMarkAsAcknowledged.AutoSize = true;
            this.cxMarkAsAcknowledged.Location = new System.Drawing.Point(32, 21);
            this.cxMarkAsAcknowledged.Name = "cxMarkAsAcknowledged";
            this.cxMarkAsAcknowledged.Size = new System.Drawing.Size(282, 24);
            this.cxMarkAsAcknowledged.TabIndex = 7;
            this.cxMarkAsAcknowledged.Text = "Mark as acknowledged after export";
            this.cxMarkAsAcknowledged.UseVisualStyleBackColor = true;
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
            this.clmDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmDate.DataPropertyName = "AllotmentDate";
            this.clmDate.HeaderText = "Date";
            this.clmDate.MinimumWidth = 8;
            this.clmDate.Name = "clmDate";
            this.clmDate.ReadOnly = true;
            this.clmDate.Width = 80;
            // 
            // clmRoomType
            // 
            this.clmRoomType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmRoomType.DataPropertyName = "RoomName";
            this.clmRoomType.HeaderText = "RoomType";
            this.clmRoomType.MinimumWidth = 8;
            this.clmRoomType.Name = "clmRoomType";
            this.clmRoomType.ReadOnly = true;
            // 
            // clmHotel
            // 
            this.clmHotel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmHotel.DataPropertyName = "HotelName";
            this.clmHotel.HeaderText = "Hotel";
            this.clmHotel.MinimumWidth = 8;
            this.clmHotel.Name = "clmHotel";
            this.clmHotel.ReadOnly = true;
            // 
            // clmAcknowledged
            // 
            this.clmAcknowledged.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmAcknowledged.DataPropertyName = "Acknowledged";
            this.clmAcknowledged.FalseValue = "false";
            this.clmAcknowledged.HeaderText = "Acknowledged";
            this.clmAcknowledged.MinimumWidth = 8;
            this.clmAcknowledged.Name = "clmAcknowledged";
            this.clmAcknowledged.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmAcknowledged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmAcknowledged.TrueValue = "true";
            this.clmAcknowledged.Width = 149;
            // 
            // FrmCloseDateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 632);
            this.Controls.Add(this.cxMarkAsAcknowledged);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnExportXML);
            this.Controls.Add(this.btnRemoveNotAcknowledged);
            this.Controls.Add(this.btnUpdateAndRefresh);
            this.Controls.Add(this.dgRecords);
            this.Name = "FrmCloseDateReport";
            this.Text = "FrmCloseDateReport";
            this.Load += new System.EventHandler(this.FrmCloseDateReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgRecords;
        private System.Windows.Forms.Button btnUpdateAndRefresh;
        private System.Windows.Forms.Button btnRemoveNotAcknowledged;
        private System.Windows.Forms.Button btnExportXML;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.CheckBox cxMarkAsAcknowledged;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRecordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHotel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmAcknowledged;
    }
}