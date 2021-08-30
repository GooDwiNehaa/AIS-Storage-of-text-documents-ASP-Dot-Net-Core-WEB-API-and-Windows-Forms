using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net.Http;
using ClientDiplom.ClientLogic;
using System.Threading;

namespace ClientDiplom.ViewForms
{
    public partial class CommonUserForm : Form
    {
        private HttpClient client;
        private BoxFiller boxFiller;
        public CommonUserForm(HttpClient client)
        {
            InitializeComponent();

            this.client = client;
            boxFiller = new BoxFiller(client);
        }

        private async void CommonUserForm_Load(object sender, EventArgs e)
        {
            await boxFiller.GetCategories(CategoriesClb, "get-all-categories");

            CategoriesClb.SetItemChecked(0, true);

            await boxFiller.ShowDocuments(DocumentsLB, CategoriesClb);
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (CategoriesClb.CheckedItems != null)
            {
                List<string> categories = new List<string>();

                foreach (var item in CategoriesClb.CheckedItems)
                {
                    categories.Add(item.ToString());
                }

                GlobalSearchForm globalSearchForm = new GlobalSearchForm(client, SearchForm.DelCarret(SearchFieldTB.Text), categories);
                globalSearchForm.Show();
            }
            else
            {
                MessageBox.Show("Выберите хоят бы одно категорию для поиска!");
            }
        }

        private void DocumentsLB_DoubleClick_1(object sender, EventArgs e)
        {
            if (DocumentsLB.SelectedItem != null)
            {
                SearchForm searchForm = new SearchForm(client, DocumentsLB.SelectedItem.ToString(), new CancellationTokenSource());
                searchForm.Show();
            }
        }

        private async void CategoriesClb_Click(object sender, EventArgs e)
        {
            int idx;

            if (CategoriesClb.SelectedIndex != -1)
            {
                idx = CategoriesClb.SelectedIndex;

                if (CategoriesClb.CheckedIndices.Contains(CategoriesClb.SelectedIndex))
                {
                    CategoriesClb.SetItemChecked(CategoriesClb.SelectedIndex, false);
                }
                else
                {
                    CategoriesClb.SetItemChecked(CategoriesClb.SelectedIndex, true);
                }

                CategoriesClb.SelectedIndex = -1;

                await boxFiller.ShowDocuments(DocumentsLB, CategoriesClb);

                CategoriesClb.SelectedIndex = idx;
            }
        }

        private void CommonUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Dispose();
        }
    }
}
