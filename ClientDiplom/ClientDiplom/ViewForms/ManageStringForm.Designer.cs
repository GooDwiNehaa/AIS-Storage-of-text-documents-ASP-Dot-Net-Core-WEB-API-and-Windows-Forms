
namespace ClientDiplom.ViewForms
{
    partial class ManageStringForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageStringForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripAddStrBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAddStrBtn,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripAddStrBtn
            // 
            this.toolStripAddStrBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripAddStrBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAddStrBtn.Image")));
            this.toolStripAddStrBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAddStrBtn.Name = "toolStripAddStrBtn";
            this.toolStripAddStrBtn.Size = new System.Drawing.Size(80, 24);
            this.toolStripAddStrBtn.Text = "Добавить";
            this.toolStripAddStrBtn.Click += new System.EventHandler(this.toolStripAddStrBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // RTB
            // 
            this.RTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB.Location = new System.Drawing.Point(0, 27);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(800, 423);
            this.RTB.TabIndex = 1;
            this.RTB.Text = "";
            this.RTB.TextChanged += new System.EventHandler(this.RTB_TextChanged);
            // 
            // ManageStringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RTB);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ManageStringForm";
            this.Text = "ManageStringForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageStringForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripAddStrBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.RichTextBox RTB;
    }
}