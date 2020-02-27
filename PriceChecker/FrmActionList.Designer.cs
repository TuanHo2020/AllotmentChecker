namespace PriceChecker
{
    partial class FrmActionList
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
            this.dgActions = new System.Windows.Forms.DataGridView();
            this.clmActionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmActionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgActions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgActions
            // 
            this.dgActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmActionId,
            this.clmActionName,
            this.clmEdit});
            this.dgActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgActions.Location = new System.Drawing.Point(0, 0);
            this.dgActions.Name = "dgActions";
            this.dgActions.RowTemplate.Height = 28;
            this.dgActions.Size = new System.Drawing.Size(735, 399);
            this.dgActions.TabIndex = 0;
            // 
            // clmActionId
            // 
            this.clmActionId.DataPropertyName = "ActionId";
            this.clmActionId.HeaderText = "ActionId";
            this.clmActionId.Name = "clmActionId";
            // 
            // clmActionName
            // 
            this.clmActionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmActionName.DataPropertyName = "ActionName";
            this.clmActionName.HeaderText = "Action Name";
            this.clmActionName.Name = "clmActionName";
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
            // FrmActionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 399);
            this.Controls.Add(this.dgActions);
            this.Name = "FrmActionList";
            this.Text = "FrmActionList";
            this.Load += new System.EventHandler(this.FrmActionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgActions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgActions;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmActionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmActionName;
        private System.Windows.Forms.DataGridViewLinkColumn clmEdit;
    }
}