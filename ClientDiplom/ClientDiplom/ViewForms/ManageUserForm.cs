using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using ClientDiplom.ClientLogic;
using ClientDiplom.Data;

namespace ClientDiplom.ViewForms
{
    public partial class ManageUserForm : Form
    {
        private HttpClient client;
        private DataGridView DGV;
        private BoxFiller boxFiller;
        private FormClosingEditer formClosingEditer;

        private bool changeUser = false;

        public ManageUserForm(HttpClient client, string formName, string btnName, DataGridView DGV)
        {
            InitializeComponent();

            this.client = client;

            boxFiller = new BoxFiller(client);

            formClosingEditer = new FormClosingEditer();

            this.Text = formName;
            this.AddApply.Text = btnName;

            this.DGV = DGV;
        }

        private async void AddApply_Click(object sender, EventArgs e)
        {
            if (this.Text == "Добавление пользователя" && this.AddApply.Text == "Добавить")
            {
                UserData userData = new UserData
                {
                    Login = LoginTB.Text,
                    Password = PasswordTB.Text,
                    UserType = TypeUserCmbBox.SelectedItem.ToString()
                };

                var response = await client.PostAsJsonAsync("add-user", userData);

                if (response.IsSuccessStatusCode)
                {
                    var code = await response.Content.ReadFromJsonAsync<int>();

                    if (code == 0)
                    {
                        MessageBox.Show("Новый пользователь успешно добавлен!");

                        this.Hide();

                        await boxFiller.GetAllUsers(DGV);
                    }
                    else
                    {
                        MessageBox.Show("Невозможно доавить пользователя, пользователь с таким логином уже существует!");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении пользователя!");
                }
            }
            if (this.Text == "Редактирование пользователя" && this.AddApply.Text == "Применить изменения")
            {
                UserData userData = new UserData
                {
                    OldLogin = DGV.CurrentRow.Cells[1].Value.ToString(),
                    Login = LoginTB.Text,
                    Password = PasswordTB.Text,
                    UserType = TypeUserCmbBox.SelectedItem.ToString()
                };

                var response = await client.PutAsJsonAsync("edit-user", userData);

                if (response.IsSuccessStatusCode)
                {
                    var code = await response.Content.ReadFromJsonAsync<int>();

                    if (code == 0)
                    {
                        changeUser = false;

                        MessageBox.Show("Изменения успешно применены!");

                        this.Hide();

                        await boxFiller.GetAllUsers(DGV);
                    }
                    else
                    {
                        MessageBox.Show("Невозможно применить изменения, пользователь с таким логином уже существует!");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка при редактировании пользователя!");
                }
            }
        }

        private async void ManageUserForm_Load(object sender, EventArgs e)
        {
            var response = await client.GetAsync("get-user-types");

            if (response.IsSuccessStatusCode)
            {
                TypeUserCmbBox.Items.Clear();

                var userTypes = await response.Content.ReadFromJsonAsync<List<string>>();

                if (userTypes.Any())
                {
                    for (int i = 0; i < userTypes.Count; i++)
                    {
                        TypeUserCmbBox.Items.Add(userTypes[i]);
                    }

                    TypeUserCmbBox.SelectedIndex = 1;
                }
                else
                {
                    MessageBox.Show("Типы пользователей отсутствуют в базе данных!");
                }
            }
            else
            {
                MessageBox.Show("Ошибка при получении типов пользователей!");
            }

            if (this.Text == "Редактирование пользователя" && this.AddApply.Text == "Применить изменения")
            {
                var curRow = DGV.CurrentRow;

                LoginTB.Text = curRow.Cells[1].Value.ToString();

                foreach (var item in TypeUserCmbBox.Items)
                {
                    if (item.ToString() == curRow.Cells[0].Value.ToString())
                    {
                        int idx = TypeUserCmbBox.Items.IndexOf(item);
                        TypeUserCmbBox.SelectedIndex = idx;
                        break;
                    }
                }
            }

            changeUser = false;
        }

        private void LoginTB_TextChanged(object sender, EventArgs e)
        {
            changeUser = true;
        }

        private void PasswordTB_TextChanged(object sender, EventArgs e)
        {
            changeUser = true;
        }

        private void TypeUserCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeUser = true;
        }

        private void ManageUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text == "Редактирование пользователя" && this.AddApply.Text == "Применить изменения")
            {
                if (changeUser == true)
                {
                    formClosingEditer.WarningMessage(e);
                }
            }
        }
    }
}
