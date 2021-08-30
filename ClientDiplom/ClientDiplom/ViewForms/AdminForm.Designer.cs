
namespace ClientDiplom.ViewForms
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.UsersPage = new System.Windows.Forms.TabPage();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.UserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripAddUserBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripEditUserBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDelUserBtn = new System.Windows.Forms.ToolStripButton();
            this.DocumentsCategoriesPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DocumentsLB = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripAddDocBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDelDocBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripEditDocBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDownloadDocBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripResearchBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CategoriesClb = new System.Windows.Forms.CheckedListBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripAddCategBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDelCategBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripEditBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.SearchField = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.UsersPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.DocumentsCategoriesPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OFD
            // 
            this.OFD.FileName = "openFileDialog1";
            // 
            // UsersPage
            // 
            this.UsersPage.Controls.Add(this.DGV);
            this.UsersPage.Controls.Add(this.toolStrip3);
            this.UsersPage.Location = new System.Drawing.Point(4, 29);
            this.UsersPage.Name = "UsersPage";
            this.UsersPage.Size = new System.Drawing.Size(1388, 552);
            this.UsersPage.TabIndex = 2;
            this.UsersPage.Text = "Пользователи";
            this.UsersPage.UseVisualStyleBackColor = true;
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserType,
            this.UserLogin});
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(0, 27);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.RowHeadersWidth = 51;
            this.DGV.RowTemplate.Height = 29;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(1388, 525);
            this.DGV.TabIndex = 1;
            // 
            // UserType
            // 
            this.UserType.HeaderText = "Тип пользователя";
            this.UserType.MinimumWidth = 6;
            this.UserType.Name = "UserType";
            this.UserType.ReadOnly = true;
            this.UserType.Width = 250;
            // 
            // UserLogin
            // 
            this.UserLogin.HeaderText = "Логин";
            this.UserLogin.MinimumWidth = 6;
            this.UserLogin.Name = "UserLogin";
            this.UserLogin.ReadOnly = true;
            this.UserLogin.Width = 250;
            // 
            // toolStrip3
            // 
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddUserBtn,
            this.toolStripSeparator5,
            this.toolStripEditUserBtn,
            this.toolStripSeparator6,
            this.toolStripDelUserBtn});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1388, 27);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripAddUserBtn
            // 
            this.toolStripAddUserBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripAddUserBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAddUserBtn.Image")));
            this.toolStripAddUserBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAddUserBtn.Name = "toolStripAddUserBtn";
            this.toolStripAddUserBtn.Size = new System.Drawing.Size(180, 24);
            this.toolStripAddUserBtn.Text = "Добавить пользователя";
            this.toolStripAddUserBtn.Click += new System.EventHandler(this.toolStripAddUserBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripEditUserBtn
            // 
            this.toolStripEditUserBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripEditUserBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEditUserBtn.Image")));
            this.toolStripEditUserBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEditUserBtn.Name = "toolStripEditUserBtn";
            this.toolStripEditUserBtn.Size = new System.Drawing.Size(215, 24);
            this.toolStripEditUserBtn.Text = "Редактировать пользователя";
            this.toolStripEditUserBtn.Click += new System.EventHandler(this.toolStripEditUserBtn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDelUserBtn
            // 
            this.toolStripDelUserBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDelUserBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDelUserBtn.Image")));
            this.toolStripDelUserBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelUserBtn.Name = "toolStripDelUserBtn";
            this.toolStripDelUserBtn.Size = new System.Drawing.Size(169, 24);
            this.toolStripDelUserBtn.Text = "Удалить пользователя";
            this.toolStripDelUserBtn.Click += new System.EventHandler(this.toolStripDelUserBtn_Click);
            // 
            // DocumentsCategoriesPage
            // 
            this.DocumentsCategoriesPage.Controls.Add(this.groupBox1);
            this.DocumentsCategoriesPage.Controls.Add(this.SearchBtn);
            this.DocumentsCategoriesPage.Controls.Add(this.SearchField);
            this.DocumentsCategoriesPage.Location = new System.Drawing.Point(4, 29);
            this.DocumentsCategoriesPage.Name = "DocumentsCategoriesPage";
            this.DocumentsCategoriesPage.Padding = new System.Windows.Forms.Padding(3);
            this.DocumentsCategoriesPage.Size = new System.Drawing.Size(1388, 552);
            this.DocumentsCategoriesPage.TabIndex = 0;
            this.DocumentsCategoriesPage.Text = "Документы и категории";
            this.DocumentsCategoriesPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer2);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1372, 503);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 23);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(1366, 477);
            this.splitContainer2.SplitterDistance = 900;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DocumentsLB);
            this.groupBox3.Controls.Add(this.toolStrip1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(900, 477);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Документы";
            // 
            // DocumentsLB
            // 
            this.DocumentsLB.Cursor = System.Windows.Forms.Cursors.Default;
            this.DocumentsLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocumentsLB.FormattingEnabled = true;
            this.DocumentsLB.ItemHeight = 20;
            this.DocumentsLB.Location = new System.Drawing.Point(3, 50);
            this.DocumentsLB.Name = "DocumentsLB";
            this.DocumentsLB.Size = new System.Drawing.Size(894, 424);
            this.DocumentsLB.TabIndex = 0;
            this.DocumentsLB.DoubleClick += new System.EventHandler(this.DocumentsLB_DoubleClick_1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddDocBtn,
            this.toolStripSeparator1,
            this.toolStripDelDocBtn,
            this.toolStripSeparator2,
            this.toolStripEditDocBtn,
            this.toolStripSeparator7,
            this.toolStripDownloadDocBtn,
            this.toolStripSeparator8,
            this.toolStripResearchBtn,
            this.toolStripSeparator10});
            this.toolStrip1.Location = new System.Drawing.Point(3, 23);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(894, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripAddDocBtn
            // 
            this.toolStripAddDocBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripAddDocBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAddDocBtn.Image")));
            this.toolStripAddDocBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAddDocBtn.Name = "toolStripAddDocBtn";
            this.toolStripAddDocBtn.Size = new System.Drawing.Size(80, 24);
            this.toolStripAddDocBtn.Text = "Добавить";
            this.toolStripAddDocBtn.Click += new System.EventHandler(this.toolStripAddDocBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDelDocBtn
            // 
            this.toolStripDelDocBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDelDocBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDelDocBtn.Image")));
            this.toolStripDelDocBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelDocBtn.Name = "toolStripDelDocBtn";
            this.toolStripDelDocBtn.Size = new System.Drawing.Size(69, 24);
            this.toolStripDelDocBtn.Text = "Удалить";
            this.toolStripDelDocBtn.Click += new System.EventHandler(this.toolStripDelDocBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripEditDocBtn
            // 
            this.toolStripEditDocBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripEditDocBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEditDocBtn.Image")));
            this.toolStripEditDocBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEditDocBtn.Name = "toolStripEditDocBtn";
            this.toolStripEditDocBtn.Size = new System.Drawing.Size(115, 24);
            this.toolStripEditDocBtn.Text = "Редактировать";
            this.toolStripEditDocBtn.Click += new System.EventHandler(this.toolStripEditDocBtn_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDownloadDocBtn
            // 
            this.toolStripDownloadDocBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDownloadDocBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDownloadDocBtn.Image")));
            this.toolStripDownloadDocBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDownloadDocBtn.Name = "toolStripDownloadDocBtn";
            this.toolStripDownloadDocBtn.Size = new System.Drawing.Size(67, 24);
            this.toolStripDownloadDocBtn.Text = "Скачать";
            this.toolStripDownloadDocBtn.Click += new System.EventHandler(this.toolStripDownloadDocBtn_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripResearchBtn
            // 
            this.toolStripResearchBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripResearchBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripResearchBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripResearchBtn.Image")));
            this.toolStripResearchBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripResearchBtn.Name = "toolStripResearchBtn";
            this.toolStripResearchBtn.Size = new System.Drawing.Size(113, 24);
            this.toolStripResearchBtn.Text = "Исследование";
            this.toolStripResearchBtn.Click += new System.EventHandler(this.toolStripResearchBtn_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 27);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CategoriesClb);
            this.groupBox2.Controls.Add(this.toolStrip2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 477);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Категории";
            // 
            // CategoriesClb
            // 
            this.CategoriesClb.Cursor = System.Windows.Forms.Cursors.Default;
            this.CategoriesClb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoriesClb.FormattingEnabled = true;
            this.CategoriesClb.Location = new System.Drawing.Point(3, 50);
            this.CategoriesClb.Name = "CategoriesClb";
            this.CategoriesClb.Size = new System.Drawing.Size(456, 424);
            this.CategoriesClb.TabIndex = 1;
            this.CategoriesClb.Click += new System.EventHandler(this.CategoriesClb_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddCategBtn,
            this.toolStripSeparator3,
            this.toolStripDelCategBtn,
            this.toolStripSeparator4,
            this.toolStripEditBtn,
            this.toolStripSeparator9});
            this.toolStrip2.Location = new System.Drawing.Point(3, 23);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(456, 27);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripAddCategBtn
            // 
            this.toolStripAddCategBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripAddCategBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAddCategBtn.Image")));
            this.toolStripAddCategBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAddCategBtn.Name = "toolStripAddCategBtn";
            this.toolStripAddCategBtn.Size = new System.Drawing.Size(80, 24);
            this.toolStripAddCategBtn.Text = "Добавить";
            this.toolStripAddCategBtn.Click += new System.EventHandler(this.toolStripAddCategBtn_Click_1);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDelCategBtn
            // 
            this.toolStripDelCategBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDelCategBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDelCategBtn.Image")));
            this.toolStripDelCategBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelCategBtn.Name = "toolStripDelCategBtn";
            this.toolStripDelCategBtn.Size = new System.Drawing.Size(69, 24);
            this.toolStripDelCategBtn.Text = "Удалить";
            this.toolStripDelCategBtn.Click += new System.EventHandler(this.toolStripDelCategBtn_Click_1);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripEditBtn
            // 
            this.toolStripEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEditBtn.Image")));
            this.toolStripEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEditBtn.Name = "toolStripEditBtn";
            this.toolStripEditBtn.Size = new System.Drawing.Size(115, 24);
            this.toolStripEditBtn.Text = "Редактировать";
            this.toolStripEditBtn.Click += new System.EventHandler(this.toolStripEditBtn_Click_1);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 27);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBtn.Location = new System.Drawing.Point(1268, 515);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(112, 29);
            this.SearchBtn.TabIndex = 5;
            this.SearchBtn.Text = "Найти";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // SearchField
            // 
            this.SearchField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchField.Location = new System.Drawing.Point(8, 517);
            this.SearchField.Name = "SearchField";
            this.SearchField.Size = new System.Drawing.Size(1254, 27);
            this.SearchField.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.DocumentsCategoriesPage);
            this.tabControl1.Controls.Add(this.UsersPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1396, 585);
            this.tabControl1.TabIndex = 0;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 585);
            this.Controls.Add(this.tabControl1);
            this.Name = "AdminForm";
            this.Text = "Администратор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.UsersPage.ResumeLayout(false);
            this.UsersPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.DocumentsCategoriesPage.ResumeLayout(false);
            this.DocumentsCategoriesPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.TabPage UsersPage;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserLogin;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripAddUserBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripEditUserBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripDelUserBtn;
        private System.Windows.Forms.TabPage DocumentsCategoriesPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox DocumentsLB;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripAddDocBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripDelDocBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripEditDocBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripDownloadDocBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox CategoriesClb;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripAddCategBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripDelCategBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripEditBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.TextBox SearchField;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripButton toolStripResearchBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
    }
}