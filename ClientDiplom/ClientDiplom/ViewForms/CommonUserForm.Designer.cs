
namespace ClientDiplom.ViewForms
{
    partial class CommonUserForm
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
            this.SearchFieldTB = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DocumentsLB = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CategoriesClb = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchFieldTB
            // 
            this.SearchFieldTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchFieldTB.Location = new System.Drawing.Point(12, 546);
            this.SearchFieldTB.Name = "SearchFieldTB";
            this.SearchFieldTB.Size = new System.Drawing.Size(1272, 27);
            this.SearchFieldTB.TabIndex = 0;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBtn.Location = new System.Drawing.Point(1290, 545);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(94, 29);
            this.SearchBtn.TabIndex = 1;
            this.SearchBtn.Text = "Найти";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1372, 515);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 23);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(1366, 489);
            this.splitContainer1.SplitterDistance = 900;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DocumentsLB);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(900, 489);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Документы";
            // 
            // DocumentsLB
            // 
            this.DocumentsLB.Cursor = System.Windows.Forms.Cursors.Default;
            this.DocumentsLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocumentsLB.FormattingEnabled = true;
            this.DocumentsLB.ItemHeight = 20;
            this.DocumentsLB.Location = new System.Drawing.Point(3, 23);
            this.DocumentsLB.Name = "DocumentsLB";
            this.DocumentsLB.Size = new System.Drawing.Size(894, 463);
            this.DocumentsLB.TabIndex = 0;
            this.DocumentsLB.DoubleClick += new System.EventHandler(this.DocumentsLB_DoubleClick_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CategoriesClb);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(462, 489);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Категории";
            // 
            // CategoriesClb
            // 
            this.CategoriesClb.Cursor = System.Windows.Forms.Cursors.Default;
            this.CategoriesClb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoriesClb.FormattingEnabled = true;
            this.CategoriesClb.Location = new System.Drawing.Point(3, 23);
            this.CategoriesClb.Name = "CategoriesClb";
            this.CategoriesClb.Size = new System.Drawing.Size(456, 463);
            this.CategoriesClb.TabIndex = 0;
            this.CategoriesClb.Click += new System.EventHandler(this.CategoriesClb_Click);
            // 
            // CommonUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 585);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.SearchFieldTB);
            this.Name = "CommonUserForm";
            this.Text = "Пользователь";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommonUserForm_FormClosing);
            this.Load += new System.EventHandler(this.CommonUserForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchFieldTB;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox DocumentsLB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox CategoriesClb;
    }
}