
namespace ClientDiplom.ViewForms
{
    partial class ManageUserForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.LoginTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.TypeUserCmbBox = new System.Windows.Forms.ComboBox();
            this.AddApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Тип пользователя:";
            // 
            // LoginTB
            // 
            this.LoginTB.Location = new System.Drawing.Point(171, 23);
            this.LoginTB.Name = "LoginTB";
            this.LoginTB.Size = new System.Drawing.Size(211, 27);
            this.LoginTB.TabIndex = 1;
            this.LoginTB.TextChanged += new System.EventHandler(this.LoginTB_TextChanged);
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(171, 81);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.PasswordChar = '*';
            this.PasswordTB.Size = new System.Drawing.Size(211, 27);
            this.PasswordTB.TabIndex = 3;
            this.PasswordTB.TextChanged += new System.EventHandler(this.PasswordTB_TextChanged);
            // 
            // TypeUserCmbBox
            // 
            this.TypeUserCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeUserCmbBox.FormattingEnabled = true;
            this.TypeUserCmbBox.Location = new System.Drawing.Point(171, 143);
            this.TypeUserCmbBox.Name = "TypeUserCmbBox";
            this.TypeUserCmbBox.Size = new System.Drawing.Size(211, 28);
            this.TypeUserCmbBox.TabIndex = 5;
            this.TypeUserCmbBox.SelectedIndexChanged += new System.EventHandler(this.TypeUserCmbBox_SelectedIndexChanged);
            // 
            // AddApply
            // 
            this.AddApply.Location = new System.Drawing.Point(21, 202);
            this.AddApply.Name = "AddApply";
            this.AddApply.Size = new System.Drawing.Size(361, 36);
            this.AddApply.TabIndex = 6;
            this.AddApply.Text = "button1";
            this.AddApply.UseVisualStyleBackColor = true;
            this.AddApply.Click += new System.EventHandler(this.AddApply_Click);
            // 
            // ManageUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 250);
            this.Controls.Add(this.AddApply);
            this.Controls.Add(this.TypeUserCmbBox);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.LoginTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "ManageUserForm";
            this.Text = "ManageUserForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageUserForm_FormClosing);
            this.Load += new System.EventHandler(this.ManageUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LoginTB;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.ComboBox TypeUserCmbBox;
        private System.Windows.Forms.Button AddApply;
    }
}