
namespace ClientDiplom.ViewForms
{
    partial class ManageCategoryForm
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
            this.NameCategoryTB = new System.Windows.Forms.TextBox();
            this.AddApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название категории:";
            // 
            // NameCategoryTB
            // 
            this.NameCategoryTB.Location = new System.Drawing.Point(173, 28);
            this.NameCategoryTB.Name = "NameCategoryTB";
            this.NameCategoryTB.Size = new System.Drawing.Size(316, 27);
            this.NameCategoryTB.TabIndex = 1;
            this.NameCategoryTB.TextChanged += new System.EventHandler(this.NameCategoryTB_TextChanged);
            // 
            // AddApply
            // 
            this.AddApply.Location = new System.Drawing.Point(505, 28);
            this.AddApply.Name = "AddApply";
            this.AddApply.Size = new System.Drawing.Size(142, 29);
            this.AddApply.TabIndex = 2;
            this.AddApply.Text = "button1";
            this.AddApply.UseVisualStyleBackColor = true;
            this.AddApply.Click += new System.EventHandler(this.AddApply_Click);
            // 
            // ManageCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 86);
            this.Controls.Add(this.AddApply);
            this.Controls.Add(this.NameCategoryTB);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "ManageCategoryForm";
            this.Text = "ManageCategoryForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageCategoryForm_FormClosing);
            this.Load += new System.EventHandler(this.ManageCategoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameCategoryTB;
        private System.Windows.Forms.Button AddApply;
    }
}