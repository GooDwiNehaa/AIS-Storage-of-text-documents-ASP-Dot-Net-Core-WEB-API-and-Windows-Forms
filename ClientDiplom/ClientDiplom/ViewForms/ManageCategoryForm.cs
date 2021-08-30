using System;
using System.Net.Http;
using System.Windows.Forms;
using ClientDiplom.ClientLogic;
using ClientDiplom.Data;

namespace ClientDiplom.ViewForms
{
    public partial class ManageCategoryForm : Form
    {
        private HttpClient client;

        private BoxFiller boxFiller;
        private FormClosingEditer closingEditer;

        private string categoryName;

        private bool changeCategory = false;

        public ManageCategoryForm(HttpClient client, string formName, string btnName,  string categoryName="")
        {
            InitializeComponent();

            this.client = client;

            boxFiller = new BoxFiller(client);
            closingEditer = new FormClosingEditer();

            this.categoryName = categoryName;

            this.Text = formName;
            this.AddApply.Text = btnName;
        }

        private async void AddApply_Click(object sender, EventArgs e)
        {
            if (this.Text == "Добавление категории" && this.AddApply.Text == "Добавить")
            {
                var response = await client.PostAsJsonAsync("add-category", NameCategoryTB.Text);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Категория '{NameCategoryTB.Text}' успешно добавлена!");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении категории!");
                }
            }
            if (this.Text == "Редактирование категории" && this.AddApply.Text == "Применить изменения")
            {
                CategoryEditData categoryEditData = new CategoryEditData
                {
                    CategoryOldName = categoryName,
                    CategoryNewName = NameCategoryTB.Text
                };

                var response = await client.PutAsJsonAsync("edit-category", categoryEditData);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Категория успешно изменена!");

                    changeCategory = false;
                }
                else
                {
                    MessageBox.Show("Ошибка при редактировании категории!");
                }
            }
        }

        private void ManageCategoryForm_Load(object sender, EventArgs e)
        {
            if (categoryName != "")
            {
                NameCategoryTB.Text = categoryName;
            }

            changeCategory = false;
        }

        private void NameCategoryTB_TextChanged(object sender, EventArgs e)
        {
            changeCategory = true;
        }

        private void ManageCategoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text == "Редактирование категории" && this.AddApply.Text == "Применить изменения")
            {
                if (changeCategory == true)
                {
                    closingEditer.WarningMessage(e);
                }
            }
        }
    }
}
