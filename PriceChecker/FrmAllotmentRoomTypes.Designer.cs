namespace PriceChecker
{
    partial class FrmAllotmentRoomTypes
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
            this.dgAllotmentRoomTypes = new System.Windows.Forms.DataGridView();
            this.clmRoomId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDefaultAllotment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIgnored = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllotmentRoomTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAllotmentRoomTypes
            // 
            this.dgAllotmentRoomTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAllotmentRoomTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmRoomId,
            this.clmRoomName,
            this.clmDefaultAllotment,
            this.clmIgnored,
            this.clmEdit});
            this.dgAllotmentRoomTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAllotmentRoomTypes.Location = new System.Drawing.Point(0, 0);
            this.dgAllotmentRoomTypes.Name = "dgAllotmentRoomTypes";
            this.dgAllotmentRoomTypes.RowTemplate.Height = 28;
            this.dgAllotmentRoomTypes.Size = new System.Drawing.Size(860, 308);
            this.dgAllotmentRoomTypes.TabIndex = 0;
            // 
            // clmRoomId
            // 
            this.clmRoomId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmRoomId.DataPropertyName = "RecordId";
            this.clmRoomId.HeaderText = "RoomId";
            this.clmRoomId.Name = "clmRoomId";
            this.clmRoomId.ReadOnly = true;
            this.clmRoomId.Width = 102;
            // 
            // clmRoomName
            // 
            this.clmRoomName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmRoomName.DataPropertyName = "RoomName";
            this.clmRoomName.HeaderText = "RoomName";
            this.clmRoomName.Name = "clmRoomName";
            this.clmRoomName.ReadOnly = true;
            // 
            // clmDefaultAllotment
            // 
            this.clmDefaultAllotment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmDefaultAllotment.DataPropertyName = "DefaultAllotment";
            this.clmDefaultAllotment.HeaderText = "Default Allotment";
            this.clmDefaultAllotment.Name = "clmDefaultAllotment";
            this.clmDefaultAllotment.ReadOnly = true;
            this.clmDefaultAllotment.Width = 154;
            // 
            // clmIgnored
            // 
            this.clmIgnored.DataPropertyName = "IgnoreThisRoomType";
            this.clmIgnored.FalseValue = "false";
            this.clmIgnored.HeaderText = "";
            this.clmIgnored.Name = "clmIgnored";
            this.clmIgnored.ReadOnly = true;
            this.clmIgnored.TrueValue = "true";
            // 
            // clmEdit
            // 
            this.clmEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmEdit.HeaderText = "";
            this.clmEdit.Name = "clmEdit";
            this.clmEdit.Text = "Edit";
            this.clmEdit.UseColumnTextForLinkValue = true;
            this.clmEdit.Width = 27;
            // 
            // FrmAllotmentRoomTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 308);
            this.Controls.Add(this.dgAllotmentRoomTypes);
            this.Name = "FrmAllotmentRoomTypes";
            this.Text = "FrmAllotmentRoomType";
            this.Load += new System.EventHandler(this.FrmAllotmentRoomType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAllotmentRoomTypes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAllotmentRoomTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRoomId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRoomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDefaultAllotment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmIgnored;
        private System.Windows.Forms.DataGridViewLinkColumn clmEdit;
    }
}