using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientDiplom.Data;

namespace ClientDiplom.ClientLogic
{
    class BoxFiller
    {
        private HttpClient client;
        public BoxFiller(HttpClient client)
        {
            this.client = client;
        }

        public async Task GetCategories(CheckedListBox categoryClb, string route)
        {
            categoryClb.Items.Clear();

            var response = await client.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadAsAsync<List<string>>();

                for (int i = 0; i < categories.Count; i++)
                {
                    categoryClb.Items.Add(categories[i]);
                }
            }
            else
            {
                MessageBox.Show("Категории документов в базе данных отсутствуют!");
            }
        }

        public async Task SetCheckedCategories(CheckedListBox categoryClb, string route)
        {
            var response = await client.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                var checkedCategories = await response.Content.ReadFromJsonAsync<List<string>>();

                if (checkedCategories.Any())
                {
                    var categories = categoryClb.Items;

                    for (int i = 0; i < checkedCategories.Count; i++)
                    {
                        int idx = categories.IndexOf(checkedCategories[i]);
                        categoryClb.SetItemChecked(idx, true);
                    }
                }
                else
                {
                    MessageBox.Show("Категории документов отсутствую в базе данных!");
                }
            }
        }

        public async Task ShowDocuments(ListBox documentLB, CheckedListBox categoriesClb)
        {
            documentLB.Items.Clear();

            if (categoriesClb.CheckedItems.Count > 0)
            {
                List<string> categories = new List<string>();

                foreach (var item in categoriesClb.CheckedItems)
                {
                    categories.Add(item.ToString());
                }

                var response = await client.PostAsJsonAsync("show-all-documents", categories);

                if (response.IsSuccessStatusCode)
                {
                    var documents = await response.Content.ReadAsAsync<List<string>>();

                    if (documents.Any())
                    {
                        for (int i = 0; i < documents.Count; i++)
                        {
                            documentLB.Items.Add(documents[i]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Документы в базе данных отсутствуют!");
                    }
                }
                else
                {
                    MessageBox.Show("Документы в базе данных отсутствуют!");
                }
            }
            else
            {
                MessageBox.Show("Невозможно отобразить документы, ни одна категория не выбрана!");
            }
        }

        public async Task GetDocumentContent(string documentName, RichTextBox RTB)
        {
            var response = await client.PostAsJsonAsync($"get-document-content", documentName);

            if (response.IsSuccessStatusCode)
            {
                RTB.Text = await response.Content.ReadAsStringAsync();
            }
            else
            {
                MessageBox.Show($"Ошибка при загрузке содержимого файла {documentName}");
            }
        }

        public async Task GetAllUsers(DataGridView DGV)
        {
            var response = await client.GetAsync("get-all-users");

            if (response.IsSuccessStatusCode)
            {
                DGV.Rows.Clear();

                var users = await response.Content.ReadFromJsonAsync<List<UserData>>();

                if (users.Any())
                {
                    for (int i = 0; i < users.Count; i++)
                    {
                        DGV.Rows.Add(users[i].UserType, users[i].Login);
                    }
                }
                else
                {
                    MessageBox.Show("Пользователи отсутствуют в базе данных!");
                }
            }
            else
            {
                MessageBox.Show("Ошибка при загрузке пользователей!");
            }
        }
    }
}
