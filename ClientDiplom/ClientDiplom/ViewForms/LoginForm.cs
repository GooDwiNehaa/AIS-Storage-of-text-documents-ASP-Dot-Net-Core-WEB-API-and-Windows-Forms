using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using ClientDiplom.ClientLogic;
using ClientDiplom.Data;
using ClientDiplom.ViewForms;

namespace ClientDiplom
{
    public partial class LoginForm : Form
    {
        private HttpClient client;
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                client = new HttpClient();

                client.BaseAddress = new Uri(URLServerApp.SERVER_APP_PATH);

                var data = new UserData { Login = LoginTB.Text, Password = PasswordTB.Text };

                var response = await client.PostAsJsonAsync("login", data);

                if (response.IsSuccessStatusCode)
                {
                    int userTypeId = await response.Content.ReadFromJsonAsync<int>();

                    if (userTypeId == 1)
                    {
                        AdminForm adminForm = new AdminForm(client);
                        adminForm.Show();
                        this.Hide();
                    }
                    else if (userTypeId == 2)
                    {
                        CommonUserForm commonUserForm = new CommonUserForm(client);
                        commonUserForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                        PasswordTB.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                    PasswordTB.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
