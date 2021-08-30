using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Windows.Forms;
using ClientDiplom.Data;

namespace ClientDiplom.ViewForms
{
    public partial class GlobalSearchForm : Form
    {
        private HttpClient client;

        private string x;
        private List<string> categories;

        private List<GlobalSearchData> searchResult;

        public GlobalSearchForm(HttpClient client, string x, List<string> categories)
        {
            InitializeComponent();

            this.client = client;

            this.x = x;
            this.categories = categories;
        }

        private async void GlobalSearchForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            DGV.Rows.Clear();

            SearchData searchData = new SearchData
            {
                X = x,
                Categories = categories
            };

            LoadingForm loadingForm = new LoadingForm();

            loadingForm.CloseLoadingForm += async delegate
            {
                var response = await client.GetAsync($"cancel/{"global-search"}");

                if (response.IsSuccessStatusCode)
                {
                    loadingForm.Close();
                    this.Close();
                    MessageBox.Show("Поиск успешно отменен!");
                }
            };

            loadingForm.pB.Style = ProgressBarStyle.Marquee;
            loadingForm.pB.MarqueeAnimationSpeed = 15;
            loadingForm.label.Text = "";
            loadingForm.label.BackColor = Color.Transparent;

            loadingForm.Show();

            try
            {
                var response = await client.PostAsJsonAsync("global-search", searchData);

                if (response.IsSuccessStatusCode)
                {
                    searchResult = await response.Content.ReadFromJsonAsync<List<GlobalSearchData>>();

                    if (searchResult.Any())
                    {
                        for (int i = 0; i < searchResult.Count; i++)
                        {
                            if (this.Created)
                            {
                                DGV.Rows.Add(searchResult[i].DocumentName, searchResult[i].CountSymbolsDoc, searchResult[i].ListFoundMatches.Count);
                            }
                        }

                        loadingForm.Close();

                        this.WindowState = FormWindowState.Normal;
                        this.ShowInTaskbar = true;
                    }
                    else
                    {
                        loadingForm.Close();
                        this.Close();

                        MessageBox.Show("Совпадений не найдено!");
                    }
                }
                else
                {
                    loadingForm.Close();
                    this.Close();

                    MessageBox.Show("Ошибка при выполнении глобального поиске!");
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void DGV_DoubleClick(object sender, EventArgs e)
        {
            if (DGV.CurrentRow.Cells[0].Value != null)
            {
                var curDoc = searchResult.FirstOrDefault(sr => sr.DocumentName == DGV.CurrentRow.Cells[0].Value.ToString());

                SearchForm searchForm = new SearchForm(client, curDoc.DocumentName, new CancellationTokenSource(), curDoc);
                searchForm.Show();
            }
        }
    }
}
