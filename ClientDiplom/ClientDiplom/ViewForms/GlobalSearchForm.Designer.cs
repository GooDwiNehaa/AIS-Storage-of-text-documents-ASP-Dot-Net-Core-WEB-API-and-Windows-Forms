
namespace ClientDiplom.ViewForms
{
    partial class GlobalSearchForm
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.DocumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountFoundMatches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocumentName,
            this.SizeDoc,
            this.CountFoundMatches});
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(0, 0);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.RowHeadersWidth = 51;
            this.DGV.RowTemplate.Height = 29;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(983, 323);
            this.DGV.TabIndex = 0;
            this.DGV.DoubleClick += new System.EventHandler(this.DGV_DoubleClick);
            // 
            // DocumentName
            // 
            this.DocumentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DocumentName.HeaderText = "Название документа";
            this.DocumentName.MinimumWidth = 6;
            this.DocumentName.Name = "DocumentName";
            this.DocumentName.ReadOnly = true;
            // 
            // SizeDoc
            // 
            this.SizeDoc.HeaderText = "Размер документа(в символах)";
            this.SizeDoc.MinimumWidth = 6;
            this.SizeDoc.Name = "SizeDoc";
            this.SizeDoc.ReadOnly = true;
            this.SizeDoc.Width = 240;
            // 
            // CountFoundMatches
            // 
            this.CountFoundMatches.HeaderText = "Количество совпадений";
            this.CountFoundMatches.MinimumWidth = 6;
            this.CountFoundMatches.Name = "CountFoundMatches";
            this.CountFoundMatches.ReadOnly = true;
            this.CountFoundMatches.Width = 240;
            // 
            // GlobalSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 323);
            this.Controls.Add(this.DGV);
            this.Name = "GlobalSearchForm";
            this.Text = "Результаты глобального поиска";
            this.Load += new System.EventHandler(this.GlobalSearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountFoundMatches;
    }
}