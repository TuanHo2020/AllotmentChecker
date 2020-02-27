namespace PriceChecker
{
    partial class frmAllotmentRoomTypeEditor
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
            this.lblHotelName = new System.Windows.Forms.Label();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDefaultAllotment = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cxIgnoreThis = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblHotelName
            // 
            this.lblHotelName.AutoSize = true;
            this.lblHotelName.Location = new System.Drawing.Point(12, 9);
            this.lblHotelName.Name = "lblHotelName";
            this.lblHotelName.Size = new System.Drawing.Size(101, 20);
            this.lblHotelName.TabIndex = 0;
            this.lblHotelName.Text = "[Hotel Name]";
            // 
            // txtRoomName
            // 
            this.txtRoomName.Location = new System.Drawing.Point(118, 40);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(463, 26);
            this.txtRoomName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Room name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Default:";
            // 
            // txtDefaultAllotment
            // 
            this.txtDefaultAllotment.Location = new System.Drawing.Point(118, 80);
            this.txtDefaultAllotment.Name = "txtDefaultAllotment";
            this.txtDefaultAllotment.Size = new System.Drawing.Size(100, 26);
            this.txtDefaultAllotment.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(219, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(118, 160);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(95, 34);
            this.btnAction.TabIndex = 6;
            this.btnAction.Text = "[Action]";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(314, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 34);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cxIgnoreThis
            // 
            this.cxIgnoreThis.AutoSize = true;
            this.cxIgnoreThis.Location = new System.Drawing.Point(118, 121);
            this.cxIgnoreThis.Name = "cxIgnoreThis";
            this.cxIgnoreThis.Size = new System.Drawing.Size(246, 24);
            this.cxIgnoreThis.TabIndex = 8;
            this.cxIgnoreThis.Text = "Ignore this room type in report";
            this.cxIgnoreThis.UseVisualStyleBackColor = true;
            // 
            // frmAllotmentRoomTypeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 215);
            this.Controls.Add(this.cxIgnoreThis);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDefaultAllotment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.lblHotelName);
            this.Name = "frmAllotmentRoomTypeEditor";
            this.Text = "frmAllotmentRoomTypeEditor";
            this.Load += new System.EventHandler(this.frmAllotmentRoomTypeEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHotelName;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDefaultAllotment;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox cxIgnoreThis;
    }
}