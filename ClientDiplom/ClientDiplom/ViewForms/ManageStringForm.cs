using System;
using System.Windows.Forms;
using ClientDiplom.ClientLogic;

namespace ClientDiplom.ViewForms
{
    public partial class ManageStringForm : Form
    {
        public string str = "";

        private bool change;

        FormClosingEditer closingEditer;

        public ManageStringForm(string formName, string btnName, string linkStr = "")
        {
            InitializeComponent();

            this.Text = formName;
            this.toolStrip1.Items[0].Text = btnName;

            this.RTB.Text = linkStr;

            change = false;

            closingEditer = new FormClosingEditer();
        }

        private void toolStripAddStrBtn_Click(object sender, EventArgs e)
        {
            if (this.Text == "Добавление" && this.toolStrip1.Items[0].Text == "Добавить")
            {
                str = RTB.Text;
                this.Close();
            }

            if (this.Text == "Редактирование" && this.toolStrip1.Items[0].Text == "Применить изменения")
            {
                str = RTB.Text;
                change = false;
            }
        }

        private void RTB_TextChanged(object sender, EventArgs e)
        {
            change = true;
        }

        private void ManageStringForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text == "Редактирование" && this.toolStrip1.Items[0].Text == "Применить изменения")
            {
                if (change == true)
                {
                    closingEditer.WarningMessage(e);
                }
            }
        }
    }
}
