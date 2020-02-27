namespace PriceChecker
{
    partial class frmHotelEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtHotelName = new System.Windows.Forms.TextBox();
            this.btnAction = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHmsId = new System.Windows.Forms.TextBox();
            this.cxCheckAllotment = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtContractValidTo = new System.Windows.Forms.DateTimePicker();
            this.dtContractValidFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dgRoomTypes = new System.Windows.Forms.DataGridView();
            this.clmRoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAction = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCities = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMinCutOffDates = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgRoomTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hotel Name:";
            // 
            // txtHotelName
            // 
            this.txtHotelName.Location = new System.Drawing.Point(160, 15);
            this.txtHotelName.Name = "txtHotelName";
            this.txtHotelName.Size = new System.Drawing.Size(384, 26);
            this.txtHotelName.TabIndex = 1;
            // 
            // btnAction
            // 
            this.btnAction.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAction.Location = new System.Drawing.Point(160, 465);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(89, 36);
            this.btnAction.TabIndex = 9;
            this.btnAction.Text = "[action]";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(255, 465);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 36);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(350, 465);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 36);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "HMS Id:";
            // 
            // txtHmsId
            // 
            this.txtHmsId.Location = new System.Drawing.Point(160, 48);
            this.txtHmsId.Name = "txtHmsId";
            this.txtHmsId.Size = new System.Drawing.Size(384, 26);
            this.txtHmsId.TabIndex = 40;
            // 
            // cxCheckAllotment
            // 
            this.cxCheckAllotment.AutoSize = true;
            this.cxCheckAllotment.Location = new System.Drawing.Point(160, 131);
            this.cxCheckAllotment.Name = "cxCheckAllotment";
            this.cxCheckAllotment.Size = new System.Drawing.Size(151, 24);
            this.cxCheckAllotment.TabIndex = 41;
            this.cxCheckAllotment.Text = "Check Allotment";
            this.cxCheckAllotment.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "Contract Valid to:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "Contract valid from:";
            // 
            // dtContractValidTo
            // 
            this.dtContractValidTo.Location = new System.Drawing.Point(160, 200);
            this.dtContractValidTo.Name = "dtContractValidTo";
            this.dtContractValidTo.Size = new System.Drawing.Size(200, 26);
            this.dtContractValidTo.TabIndex = 44;
            // 
            // dtContractValidFrom
            // 
            this.dtContractValidFrom.Location = new System.Drawing.Point(160, 161);
            this.dtContractValidFrom.Name = "dtContractValidFrom";
            this.dtContractValidFrom.Size = new System.Drawing.Size(200, 26);
            this.dtContractValidFrom.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 46;
            this.label5.Text = "Room Types";
            // 
            // dgRoomTypes
            // 
            this.dgRoomTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRoomTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmRoomName,
            this.clmAction});
            this.dgRoomTypes.Location = new System.Drawing.Point(160, 292);
            this.dgRoomTypes.Name = "dgRoomTypes";
            this.dgRoomTypes.RowHeadersWidth = 62;
            this.dgRoomTypes.RowTemplate.Height = 28;
            this.dgRoomTypes.Size = new System.Drawing.Size(804, 150);
            this.dgRoomTypes.TabIndex = 47;
            // 
            // clmRoomName
            // 
            this.clmRoomName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmRoomName.DataPropertyName = "RoomName";
            this.clmRoomName.HeaderText = "Room Name";
            this.clmRoomName.MinimumWidth = 8;
            this.clmRoomName.Name = "clmRoomName";
            // 
            // clmAction
            // 
            this.clmAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmAction.HeaderText = "";
            this.clmAction.MinimumWidth = 8;
            this.clmAction.Name = "clmAction";
            this.clmAction.Text = "Edit";
            this.clmAction.UseColumnTextForLinkValue = true;
            this.clmAction.Width = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "City:";
            // 
            // cmbCities
            // 
            this.cmbCities.FormattingEnabled = true;
            this.cmbCities.Location = new System.Drawing.Point(160, 88);
            this.cmbCities.Name = "cmbCities";
            this.cmbCities.Size = new System.Drawing.Size(272, 28);
            this.cmbCities.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 50;
            this.label7.Text = "Min Cutoff:";
            // 
            // txtMinCutOffDates
            // 
            this.txtMinCutOffDates.Location = new System.Drawing.Point(160, 239);
            this.txtMinCutOffDates.Name = "txtMinCutOffDates";
            this.txtMinCutOffDates.Size = new System.Drawing.Size(89, 26);
            this.txtMinCutOffDates.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(360, 20);
            this.label8.TabIndex = 52;
            this.label8.Text = "(Allotment within cut off dates will not be checked)";
            // 
            // frmHotelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 507);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMinCutOffDates);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbCities);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgRoomTypes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtContractValidFrom);
            this.Controls.Add(this.dtContractValidTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cxCheckAllotment);
            this.Controls.Add(this.txtHmsId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.txtHotelName);
            this.Controls.Add(this.label1);
            this.Name = "frmHotelEditor";
            this.Text = "frmHotelEditor";
            this.Load += new System.EventHandler(this.frmHotelEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRoomTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHotelName;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHmsId;
        private System.Windows.Forms.CheckBox cxCheckAllotment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtContractValidTo;
        private System.Windows.Forms.DateTimePicker dtContractValidFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgRoomTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRoomName;
        private System.Windows.Forms.DataGridViewLinkColumn clmAction;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCities;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMinCutOffDates;
        private System.Windows.Forms.Label label8;
    }
}