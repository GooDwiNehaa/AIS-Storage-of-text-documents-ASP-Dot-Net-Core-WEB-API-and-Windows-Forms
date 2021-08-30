
namespace ClientDiplom.ViewForms
{
    partial class RowsAndGraphsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RowsAndGraphsForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.SkewingStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountSymbolsStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripAddBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDelBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripEditBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripBuildChartBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDownloadChartBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.CountSymbolsDocTB = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.CountMatchesDocTB = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1366, 694);
            this.splitContainer1.SplitterDistance = 587;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGV);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 694);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Искомые строки";
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SkewingStr,
            this.CountSymbolsStr});
            this.DGV.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(3, 50);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.RowHeadersWidth = 51;
            this.DGV.RowTemplate.Height = 29;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(581, 641);
            this.DGV.TabIndex = 1;
            // 
            // SkewingStr
            // 
            this.SkewingStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SkewingStr.HeaderText = "Строка";
            this.SkewingStr.MinimumWidth = 6;
            this.SkewingStr.Name = "SkewingStr";
            this.SkewingStr.ReadOnly = true;
            // 
            // CountSymbolsStr
            // 
            this.CountSymbolsStr.HeaderText = "Количество символов строки";
            this.CountSymbolsStr.MinimumWidth = 6;
            this.CountSymbolsStr.Name = "CountSymbolsStr";
            this.CountSymbolsStr.ReadOnly = true;
            this.CountSymbolsStr.Width = 125;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddBtn,
            this.toolStripSeparator1,
            this.toolStripDelBtn,
            this.toolStripSeparator2,
            this.toolStripEditBtn,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(3, 23);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(581, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripAddBtn
            // 
            this.toolStripAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAddBtn.Image")));
            this.toolStripAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAddBtn.Name = "toolStripAddBtn";
            this.toolStripAddBtn.Size = new System.Drawing.Size(129, 24);
            this.toolStripAddBtn.Text = "Добавить строку";
            this.toolStripAddBtn.Click += new System.EventHandler(this.toolStripAddBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDelBtn
            // 
            this.toolStripDelBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDelBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDelBtn.Image")));
            this.toolStripDelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelBtn.Name = "toolStripDelBtn";
            this.toolStripDelBtn.Size = new System.Drawing.Size(118, 24);
            this.toolStripDelBtn.Text = "Удалить строку";
            this.toolStripDelBtn.Click += new System.EventHandler(this.toolStripDelBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripEditBtn
            // 
            this.toolStripEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEditBtn.Image")));
            this.toolStripEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripEditBtn.Name = "toolStripEditBtn";
            this.toolStripEditBtn.Size = new System.Drawing.Size(164, 24);
            this.toolStripEditBtn.Text = "Редактировать строку";
            this.toolStripEditBtn.Click += new System.EventHandler(this.toolStripEditBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.formsPlot1);
            this.groupBox2.Controls.Add(this.toolStrip2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(775, 694);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Графики";
            // 
            // formsPlot1
            // 
            this.formsPlot1.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot1.Cursor = System.Windows.Forms.Cursors.Default;
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(3, 52);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(769, 639);
            this.formsPlot1.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBuildChartBtn,
            this.toolStripSeparator4,
            this.toolStripDownloadChartBtn,
            this.toolStripSeparator5,
            this.toolStripLabel1,
            this.CountSymbolsDocTB,
            this.toolStripSeparator6,
            this.toolStripLabel2,
            this.CountMatchesDocTB,
            this.toolStripSeparator7});
            this.toolStrip2.Location = new System.Drawing.Point(3, 23);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(769, 29);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripBuildChartBtn
            // 
            this.toolStripBuildChartBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBuildChartBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBuildChartBtn.Image")));
            this.toolStripBuildChartBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBuildChartBtn.Name = "toolStripBuildChartBtn";
            this.toolStripBuildChartBtn.Size = new System.Drawing.Size(140, 26);
            this.toolStripBuildChartBtn.Text = "Построить график";
            this.toolStripBuildChartBtn.Click += new System.EventHandler(this.toolStripBuildChartBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripDownloadChartBtn
            // 
            this.toolStripDownloadChartBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDownloadChartBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDownloadChartBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDownloadChartBtn.Image")));
            this.toolStripDownloadChartBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDownloadChartBtn.Name = "toolStripDownloadChartBtn";
            this.toolStripDownloadChartBtn.Size = new System.Drawing.Size(67, 26);
            this.toolStripDownloadChartBtn.Text = "Скачать";
            this.toolStripDownloadChartBtn.Click += new System.EventHandler(this.toolStripDownloadChartBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(255, 26);
            this.toolStripLabel1.Text = "Количество символов в документе:";
            // 
            // CountSymbolsDocTB
            // 
            this.CountSymbolsDocTB.Name = "CountSymbolsDocTB";
            this.CountSymbolsDocTB.ReadOnly = true;
            this.CountSymbolsDocTB.Size = new System.Drawing.Size(100, 29);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(263, 20);
            this.toolStripLabel2.Text = "Количество найденных совпадений:";
            // 
            // CountMatchesDocTB
            // 
            this.CountMatchesDocTB.Name = "CountMatchesDocTB";
            this.CountMatchesDocTB.ReadOnly = true;
            this.CountMatchesDocTB.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 6);
            // 
            // RowsAndGraphsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 694);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RowsAndGraphsForm";
            this.Text = "RowsAndGraphsForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SkewingStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountSymbolsStr;
        private System.Windows.Forms.ToolStripButton toolStripAddBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripDelBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripEditBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripBuildChartBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripDownloadChartBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox CountSymbolsDocTB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox CountMatchesDocTB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}