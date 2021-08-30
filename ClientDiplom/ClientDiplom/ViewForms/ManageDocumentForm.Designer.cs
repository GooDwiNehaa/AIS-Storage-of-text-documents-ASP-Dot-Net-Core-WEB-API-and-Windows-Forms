
namespace ClientDiplom.ViewForms
{
    partial class ManageDocumentForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.CategoriesGB = new System.Windows.Forms.GroupBox();
            this.CategoriesCLB = new System.Windows.Forms.CheckedListBox();
            this.DocumentNameTB = new System.Windows.Forms.TextBox();
            this.DocumentPathTB = new System.Windows.Forms.TextBox();
            this.AddApply = new System.Windows.Forms.Button();
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.ExtensionLabel = new System.Windows.Forms.Label();
            this.CategoriesGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название документа:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Путь документа:";
            // 
            // CategoriesGB
            // 
            this.CategoriesGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CategoriesGB.Controls.Add(this.CategoriesCLB);
            this.CategoriesGB.Location = new System.Drawing.Point(4, 114);
            this.CategoriesGB.Name = "CategoriesGB";
            this.CategoriesGB.Size = new System.Drawing.Size(632, 450);
            this.CategoriesGB.TabIndex = 1;
            this.CategoriesGB.TabStop = false;
            this.CategoriesGB.Text = "Категории документа:";
            // 
            // CategoriesCLB
            // 
            this.CategoriesCLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CategoriesCLB.FormattingEnabled = true;
            this.CategoriesCLB.Location = new System.Drawing.Point(3, 23);
            this.CategoriesCLB.Name = "CategoriesCLB";
            this.CategoriesCLB.Size = new System.Drawing.Size(626, 422);
            this.CategoriesCLB.TabIndex = 0;
            this.CategoriesCLB.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CategoriesCLB_ItemCheck);
            // 
            // DocumentNameTB
            // 
            this.DocumentNameTB.Location = new System.Drawing.Point(175, 22);
            this.DocumentNameTB.Name = "DocumentNameTB";
            this.DocumentNameTB.Size = new System.Drawing.Size(543, 27);
            this.DocumentNameTB.TabIndex = 2;
            this.DocumentNameTB.TextChanged += new System.EventHandler(this.DocumentNameTB_TextChanged);
            // 
            // DocumentPathTB
            // 
            this.DocumentPathTB.Location = new System.Drawing.Point(175, 72);
            this.DocumentPathTB.Name = "DocumentPathTB";
            this.DocumentPathTB.Size = new System.Drawing.Size(613, 27);
            this.DocumentPathTB.TabIndex = 2;
            // 
            // AddApply
            // 
            this.AddApply.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddApply.Location = new System.Drawing.Point(657, 137);
            this.AddApply.Name = "AddApply";
            this.AddApply.Size = new System.Drawing.Size(131, 422);
            this.AddApply.TabIndex = 3;
            this.AddApply.Text = "button1";
            this.AddApply.UseVisualStyleBackColor = true;
            this.AddApply.Click += new System.EventHandler(this.AddApply_Click);
            // 
            // RTB
            // 
            this.RTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB.Location = new System.Drawing.Point(810, 12);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(921, 547);
            this.RTB.TabIndex = 4;
            this.RTB.Text = "";
            this.RTB.TextChanged += new System.EventHandler(this.RTB_TextChanged);
            // 
            // ExtensionLabel
            // 
            this.ExtensionLabel.AutoSize = true;
            this.ExtensionLabel.Location = new System.Drawing.Point(735, 25);
            this.ExtensionLabel.Name = "ExtensionLabel";
            this.ExtensionLabel.Size = new System.Drawing.Size(50, 20);
            this.ExtensionLabel.TabIndex = 5;
            this.ExtensionLabel.Text = "label3";
            // 
            // ManageDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1743, 568);
            this.Controls.Add(this.ExtensionLabel);
            this.Controls.Add(this.RTB);
            this.Controls.Add(this.AddApply);
            this.Controls.Add(this.DocumentPathTB);
            this.Controls.Add(this.DocumentNameTB);
            this.Controls.Add(this.CategoriesGB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ManageDocumentForm";
            this.Text = "ManageDocumentForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageDocumentForm_FormClosing);
            this.Load += new System.EventHandler(this.ManageDocumentForm_Load);
            this.CategoriesGB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox CategoriesGB;
        private System.Windows.Forms.CheckedListBox CategoriesCLB;
        private System.Windows.Forms.TextBox DocumentNameTB;
        private System.Windows.Forms.TextBox DocumentPathTB;
        private System.Windows.Forms.Button AddApply;
        private System.Windows.Forms.RichTextBox RTB;
        private System.Windows.Forms.Label ExtensionLabel;
    }
}