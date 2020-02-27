namespace PriceChecker
{
    partial class frmRoomTypeReMatch
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
            this.txtNotMatchedRoomType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAvailableRoomTypes = new System.Windows.Forms.ComboBox();
            this.btnMatch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNotMatchedRoomType
            // 
            this.txtNotMatchedRoomType.Location = new System.Drawing.Point(21, 12);
            this.txtNotMatchedRoomType.Multiline = true;
            this.txtNotMatchedRoomType.Name = "txtNotMatchedRoomType";
            this.txtNotMatchedRoomType.Size = new System.Drawing.Size(616, 90);
            this.txtNotMatchedRoomType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available Room Types";
            // 
            // cmbAvailableRoomTypes
            // 
            this.cmbAvailableRoomTypes.FormattingEnabled = true;
            this.cmbAvailableRoomTypes.Location = new System.Drawing.Point(30, 157);
            this.cmbAvailableRoomTypes.Name = "cmbAvailableRoomTypes";
            this.cmbAvailableRoomTypes.Size = new System.Drawing.Size(323, 28);
            this.cmbAvailableRoomTypes.TabIndex = 2;
            // 
            // btnMatch
            // 
            this.btnMatch.Location = new System.Drawing.Point(373, 157);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(94, 34);
            this.btnMatch.TabIndex = 3;
            this.btnMatch.Text = "Match";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(473, 157);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 34);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmRoomTypeReMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 212);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnMatch);
            this.Controls.Add(this.cmbAvailableRoomTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNotMatchedRoomType);
            this.Name = "frmRoomTypeReMatch";
            this.Text = "frmRoomTypeReMatch";
            this.Load += new System.EventHandler(this.frmRoomTypeReMatch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNotMatchedRoomType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAvailableRoomTypes;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.Button btnCancel;
    }
}