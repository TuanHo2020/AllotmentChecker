namespace PriceChecker
{
    partial class frmAllotmentHotels
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
            this.dgAllotmentHotels = new System.Windows.Forms.DataGridView();
            this.clmHotelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHotelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCloseDates = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clmEdit = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllotmentHotels)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAllotmentHotels
            // 
            this.dgAllotmentHotels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAllotmentHotels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmHotelId,
            this.clmHotelName,
            this.clmCloseDates,
            this.clmEdit});
            this.dgAllotmentHotels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAllotmentHotels.Location = new System.Drawing.Point(0, 0);
            this.dgAllotmentHotels.Name = "dgAllotmentHotels";
            this.dgAllotmentHotels.RowHeadersWidth = 62;
            this.dgAllotmentHotels.RowTemplate.Height = 28;
            this.dgAllotmentHotels.Size = new System.Drawing.Size(754, 464);
            this.dgAllotmentHotels.TabIndex = 0;
            // 
            // clmHotelId
            // 
            this.clmHotelId.DataPropertyName = "HotelId";
            this.clmHotelId.HeaderText = "Hotel Id";
            this.clmHotelId.MinimumWidth = 8;
            this.clmHotelId.Name = "clmHotelId";
            this.clmHotelId.ReadOnly = true;
            this.clmHotelId.Width = 150;
            // 
            // clmHotelName
            // 
            this.clmHotelName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmHotelName.DataPropertyName = "HotelName";
            this.clmHotelName.HeaderText = "Hotel Name";
            this.clmHotelName.MinimumWidth = 8;
            this.clmHotelName.Name = "clmHotelName";
            this.clmHotelName.ReadOnly = true;
            // 
            // clmCloseDates
            // 
            this.clmCloseDates.HeaderText = "";
            this.clmCloseDates.MinimumWidth = 8;
            this.clmCloseDates.Name = "clmCloseDates";
            this.clmCloseDates.Text = "Close Dates";
            this.clmCloseDates.UseColumnTextForLinkValue = true;
            this.clmCloseDates.Width = 150;
            // 
            // clmEdit
            // 
            this.clmEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmEdit.HeaderText = "";
            this.clmEdit.MinimumWidth = 8;
            this.clmEdit.Name = "clmEdit";
            this.clmEdit.Text = "Edit";
            this.clmEdit.UseColumnTextForLinkValue = true;
            this.clmEdit.Width = 27;
            // 
            // frmAllotmentHotels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 464);
            this.Controls.Add(this.dgAllotmentHotels);
            this.Name = "frmAllotmentHotels";
            this.Text = "frmAllotmentHotels";
            this.Load += new System.EventHandler(this.frmAllotmentHotels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAllotmentHotels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAllotmentHotels;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHotelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHotelName;
        private System.Windows.Forms.DataGridViewLinkColumn clmCloseDates;
        private System.Windows.Forms.DataGridViewLinkColumn clmEdit;
    }
}