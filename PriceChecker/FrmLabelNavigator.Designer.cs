namespace PriceChecker
{
    partial class FrmLabelNavigator
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
            this.dgLabels = new System.Windows.Forms.DataGridView();
            this.clmLabelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLabelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmXPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clmRun = new System.Windows.Forms.DataGridViewLinkColumn();
            this.txtResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgLabels)).BeginInit();
            this.SuspendLayout();
            // 
            // dgLabels
            // 
            this.dgLabels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLabels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmLabelId,
            this.clmLabelName,
            this.clmXPath,
            this.clmEdit,
            this.clmRun});
            this.dgLabels.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgLabels.Location = new System.Drawing.Point(0, 0);
            this.dgLabels.Name = "dgLabels";
            this.dgLabels.RowTemplate.Height = 28;
            this.dgLabels.Size = new System.Drawing.Size(562, 465);
            this.dgLabels.TabIndex = 0;
            // 
            // clmLabelId
            // 
            this.clmLabelId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmLabelId.DataPropertyName = "LabelId";
            this.clmLabelId.HeaderText = "LabelId";
            this.clmLabelId.Name = "clmLabelId";
            this.clmLabelId.ReadOnly = true;
            this.clmLabelId.Width = 98;
            // 
            // clmLabelName
            // 
            this.clmLabelName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmLabelName.DataPropertyName = "LabelName";
            this.clmLabelName.HeaderText = "Label Name";
            this.clmLabelName.Name = "clmLabelName";
            this.clmLabelName.ReadOnly = true;
            // 
            // clmXPath
            // 
            this.clmXPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmXPath.DataPropertyName = "XPath";
            this.clmXPath.HeaderText = "XPath";
            this.clmXPath.Name = "clmXPath";
            this.clmXPath.Width = 89;
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
            // clmRun
            // 
            this.clmRun.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmRun.HeaderText = "";
            this.clmRun.Name = "clmRun";
            this.clmRun.Text = "Run";
            this.clmRun.UseColumnTextForLinkValue = true;
            this.clmRun.Width = 27;
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtResult.Location = new System.Drawing.Point(593, 0);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(452, 465);
            this.txtResult.TabIndex = 1;
            // 
            // FrmLabelNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 465);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.dgLabels);
            this.Name = "FrmLabelNavigator";
            this.Text = "FrmLabelNavigator";
            this.Load += new System.EventHandler(this.FrmLabelNavigator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLabels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgLabels;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLabelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLabelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmXPath;
        private System.Windows.Forms.DataGridViewLinkColumn clmEdit;
        private System.Windows.Forms.DataGridViewLinkColumn clmRun;
        private System.Windows.Forms.TextBox txtResult;
    }
}