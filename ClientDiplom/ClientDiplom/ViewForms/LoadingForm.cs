using System;
using System.Windows.Forms;

namespace ClientDiplom.ViewForms
{
    public partial class LoadingForm : Form
    {
        public ProgressBar pB;
        public Label label;
        public Button button;

        public delegate void Closer();
        public event Closer CloseLoadingForm;

        public LoadingForm()
        {
            InitializeComponent();

            pB = this.progressBar1;
            label = this.label1;
            button = this.CanselLoading;
        }

        private void CanselLoading_Click(object sender, EventArgs e)
        {
            if (CloseLoadingForm != null)
            {
                CloseLoadingForm.Invoke();
            }
        }
    }
}
