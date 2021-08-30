
namespace ClientDiplom.ViewForms
{
    partial class SearchForm
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
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchField = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.StopButtonSF = new System.Windows.Forms.Button();
            this.ProgressBarSF = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RTB
            // 
            this.RTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB.Location = new System.Drawing.Point(0, 79);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(1119, 523);
            this.RTB.TabIndex = 1;
            this.RTB.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Найти:";
            // 
            // SearchField
            // 
            this.SearchField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchField.BackColor = System.Drawing.SystemColors.Info;
            this.SearchField.Location = new System.Drawing.Point(68, 6);
            this.SearchField.Multiline = true;
            this.SearchField.Name = "SearchField";
            this.SearchField.Size = new System.Drawing.Size(935, 27);
            this.SearchField.TabIndex = 3;
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Location = new System.Drawing.Point(1013, 4);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(94, 29);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.Text = "Поиск";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // StopButtonSF
            // 
            this.StopButtonSF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StopButtonSF.Location = new System.Drawing.Point(1013, 44);
            this.StopButtonSF.Name = "StopButtonSF";
            this.StopButtonSF.Size = new System.Drawing.Size(94, 29);
            this.StopButtonSF.TabIndex = 5;
            this.StopButtonSF.Text = "Прервать";
            this.StopButtonSF.UseVisualStyleBackColor = true;
            this.StopButtonSF.Click += new System.EventHandler(this.StopButtonSF_Click);
            // 
            // ProgressBarSF
            // 
            this.ProgressBarSF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBarSF.ForeColor = System.Drawing.Color.GreenYellow;
            this.ProgressBarSF.Location = new System.Drawing.Point(68, 44);
            this.ProgressBarSF.Name = "ProgressBarSF";
            this.ProgressBarSF.Size = new System.Drawing.Size(935, 29);
            this.ProgressBarSF.Step = 1;
            this.ProgressBarSF.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBarSF.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(512, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 7;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 610);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProgressBarSF);
            this.Controls.Add(this.StopButtonSF);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RTB);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchForm_FormClosing);
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchField;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button StopButtonSF;
        private System.Windows.Forms.ProgressBar ProgressBarSF;
        private System.Windows.Forms.Label label2;
    }
}