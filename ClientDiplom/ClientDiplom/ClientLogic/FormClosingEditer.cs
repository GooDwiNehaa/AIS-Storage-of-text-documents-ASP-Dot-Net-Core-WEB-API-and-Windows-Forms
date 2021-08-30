using System.Windows.Forms;

namespace ClientDiplom.ClientLogic
{
    public class FormClosingEditer
    {
        public void WarningMessage(FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены что хотите закрыть форму, не сохранив изменения?", "Предупреждение!", MessageBoxButtons.YesNoCancel);

            switch (result)
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    e.Cancel = false;
                    break;
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }
    }
}
