namespace PriceChecker
{
    partial class FrmActionEditor
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
            this.txtActionName = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgLabels = new System.Windows.Forms.DataGridView();
            this.clmLabelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLabelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMoveUp = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clmMoveDown = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clmEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clmExecute = new System.Windows.Forms.DataGridViewLinkColumn();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.btnRunAction = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgLabels)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Action Name:";
            // 
            // txtActionName
            // 
            this.txtActionName.Location = new System.Drawing.Point(122, 9);
            this.txtActionName.Name = "txtActionName";
            this.txtActionName.Size = new System.Drawing.Size(174, 26);
            this.txtActionName.TabIndex = 1;
            // 
            // btnEdit
            // 
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEdit.Location = new System.Drawing.Point(306, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(88, 36);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDelete.Location = new System.Drawing.Point(509, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 36);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgLabels
            // 
            this.dgLabels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLabels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmLabelId,
            this.clmLabelName,
            this.clmMoveUp,
            this.clmMoveDown,
            this.clmEdit,
            this.clmExecute});
            this.dgLabels.Location = new System.Drawing.Point(4, 72);
            this.dgLabels.Name = "dgLabels";
            this.dgLabels.RowTemplate.Height = 28;
            this.dgLabels.Size = new System.Drawing.Size(559, 406);
            this.dgLabels.TabIndex = 5;
            // 
            // clmLabelId
            // 
            this.clmLabelId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmLabelId.DataPropertyName = "LabelId";
            this.clmLabelId.HeaderText = "Id";
            this.clmLabelId.Name = "clmLabelId";
            this.clmLabelId.Width = 59;
            // 
            // clmLabelName
            // 
            this.clmLabelName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmLabelName.DataPropertyName = "LabelName";
            this.clmLabelName.HeaderText = "LabelName";
            this.clmLabelName.Name = "clmLabelName";
            // 
            // clmMoveUp
            // 
            this.clmMoveUp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmMoveUp.HeaderText = "";
            this.clmMoveUp.Name = "clmMoveUp";
            this.clmMoveUp.Text = "Up";
            this.clmMoveUp.UseColumnTextForLinkValue = true;
            this.clmMoveUp.Width = 27;
            // 
            // clmMoveDown
            // 
            this.clmMoveDown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmMoveDown.HeaderText = "";
            this.clmMoveDown.Name = "clmMoveDown";
            this.clmMoveDown.Text = "Down";
            this.clmMoveDown.UseColumnTextForLinkValue = true;
            this.clmMoveDown.Width = 27;
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
            // clmExecute
            // 
            this.clmExecute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmExecute.HeaderText = "";
            this.clmExecute.Name = "clmExecute";
            this.clmExecute.Text = "Execute";
            this.clmExecute.UseColumnTextForLinkValue = true;
            this.clmExecute.Width = 27;
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(569, 72);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(501, 406);
            this.txtProgress.TabIndex = 6;
            // 
            // btnRunAction
            // 
            this.btnRunAction.Location = new System.Drawing.Point(400, 10);
            this.btnRunAction.Name = "btnRunAction";
            this.btnRunAction.Size = new System.Drawing.Size(101, 36);
            this.btnRunAction.TabIndex = 7;
            this.btnRunAction.Text = "Run Action";
            this.btnRunAction.UseVisualStyleBackColor = true;
            this.btnRunAction.Click += new System.EventHandler(this.btnRunAction_Click);
            // 
            // FrmActionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 490);
            this.Controls.Add(this.btnRunAction);
            this.Controls.Add(this.txtProgress);
            this.Controls.Add(this.dgLabels);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtActionName);
            this.Controls.Add(this.label1);
            this.Name = "FrmActionEditor";
            this.Text = "FrmActionEditor";
            this.Load += new System.EventHandler(this.FrmActionEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLabels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtActionName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgLabels;
        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLabelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLabelName;
        private System.Windows.Forms.DataGridViewLinkColumn clmMoveUp;
        private System.Windows.Forms.DataGridViewLinkColumn clmMoveDown;
        private System.Windows.Forms.DataGridViewLinkColumn clmEdit;
        private System.Windows.Forms.DataGridViewLinkColumn clmExecute;
        private System.Windows.Forms.Button btnRunAction;
    }
}