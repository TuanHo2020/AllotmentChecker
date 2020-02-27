namespace PriceChecker
{
    partial class frmLabelList
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
            this.dgLabelList = new System.Windows.Forms.DataGridView();
            this.clmLabelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAction = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgLabelList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgLabelList
            // 
            this.dgLabelList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLabelList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmLabelName,
            this.clmAction});
            this.dgLabelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgLabelList.Location = new System.Drawing.Point(0, 0);
            this.dgLabelList.Name = "dgLabelList";
            this.dgLabelList.RowHeadersWidth = 62;
            this.dgLabelList.RowTemplate.Height = 28;
            this.dgLabelList.Size = new System.Drawing.Size(800, 450);
            this.dgLabelList.TabIndex = 0;
            // 
            // clmLabelName
            // 
            this.clmLabelName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmLabelName.DataPropertyName = "LabelName";
            this.clmLabelName.HeaderText = "LabelName";
            this.clmLabelName.MinimumWidth = 8;
            this.clmLabelName.Name = "clmLabelName";
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
            // frmLabelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgLabelList);
            this.Name = "frmLabelList";
            this.Text = "frmLabelList";
            this.Load += new System.EventHandler(this.frmLabelList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLabelList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgLabelList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLabelName;
        private System.Windows.Forms.DataGridViewLinkColumn clmAction;
    }
}