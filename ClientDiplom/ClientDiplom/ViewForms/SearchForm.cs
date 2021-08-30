using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientDiplom.ClientLogic;
using ClientDiplom.Data;

namespace ClientDiplom.ViewForms
{
    public partial class SearchForm : Form
    {
        private HttpClient client;
        private BoxFiller boxFiller;
        private Display display;

        string documentName;

        private CancellationTokenSource canselTokenSource;
        private CancellationToken token;

        private GlobalSearchData curDoc;

        public SearchForm(HttpClient client, string documentName, CancellationTokenSource canselTokenSource, GlobalSearchData curDoc = null)
        {
            InitializeComponent();

            this.client = client;

            boxFiller = new BoxFiller(client);

            display = new Display();

            this.documentName = documentName;

            this.Text = documentName;

            this.canselTokenSource = canselTokenSource;
            token = canselTokenSource.Token;

            this.curDoc = curDoc;
        }

        public static string DelCarret(string myString)
        {
            Regex re = new Regex("\r\n");
            return re.Replace(myString, "\n");
        }

        private async void SearchForm_Load(object sender, EventArgs e)
        {
            if (curDoc != null)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;

                ProgressBarSF.Visible = false;
                StopButtonSF.Visible = false;
                label2.Visible = false;

                SearchField.Text = curDoc.X;

                await boxFiller.GetDocumentContent(documentName, RTB);

                LoadingForm loadingForm = new LoadingForm(/*canselTokenSource*/);

                loadingForm.CloseLoadingForm += delegate
                {
                    canselTokenSource.Cancel();
                    loadingForm.Close();
                    MessageBox.Show("Поиск успешно отменен!");
                };

                loadingForm.pB.Style = ProgressBarStyle.Blocks;
                loadingForm.pB.MarqueeAnimationSpeed = 100;
                loadingForm.label.BackColor = Color.Gold;

                loadingForm.Show();

                int pos = RTB.SelectionStart;

                await LoadedProgress(loadingForm.pB, loadingForm.label, curDoc.ListFoundMatches, DelCarret(curDoc.X).Length);

                RTB.SelectionStart = pos;

                loadingForm.Close();

                if (canselTokenSource.Token.IsCancellationRequested)
                {
                    this.Close();
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;
                }
            }
            else
            {
                ProgressBarSF.Visible = false;
                StopButtonSF.Visible = false;
                label2.Visible = false;

                await boxFiller.GetDocumentContent(documentName, RTB);
            }
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchField.Text.Length == 0)
            {
                return;
            }
            if (SearchField.Text.Length > RTB.Text.Length)
            {
                MessageBox.Show("Введенная искомая строка больше исходного текста!");
            }
            else
            {
                SearchButton.Enabled = false;
                SearchField.Enabled = false;
                ProgressBarSF.Visible = true;
                StopButtonSF.Visible = true;
                label2.Visible = true;

                display.Deselect(RTB);

                SearchData searchData = new SearchData
                {
                    X = DelCarret(SearchField.Text).ToLower(),
                    S = RTB.Text.ToLower()
                };

                int sizeSearchStr = SearchField.Text.Length;
                int sizeText = RTB.Text.Length;

                var response = await client.PostAsJsonAsync("single-search", searchData);

                if (response.IsSuccessStatusCode)
                {
                    var resultAlgorihms = await response.Content.ReadFromJsonAsync<List<int>>();

                    int pos = RTB.SelectionStart;

                    await LoadedProgress(ProgressBarSF, label2, resultAlgorihms, DelCarret(SearchField.Text).Length);

                    if (this.Created)
                    {
                        MessageBox.Show($"Количество найденных совпадений:{resultAlgorihms.Count}");

                        RTB.SelectionStart = pos;

                        SearchButton.Enabled = true;
                        SearchField.Enabled = true;

                        ProgressBarSF.Visible = false;
                        StopButtonSF.Visible = false;
                        label2.Visible = false;

                        ProgressBarSF.Value = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка при запуске алгоритмов!");
                }
            }
        }

        private void StopButtonSF_Click(object sender, EventArgs e)
        {
            SearchButton.Enabled = true;
            SearchField.Enabled = true;

            canselTokenSource.Cancel();

            canselTokenSource.Dispose();

            canselTokenSource = new CancellationTokenSource();
            token = canselTokenSource.Token;
        }

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            canselTokenSource.Cancel();

            canselTokenSource.Dispose();

            canselTokenSource = new CancellationTokenSource();
        }

        private async Task LoadedProgress(ProgressBar progressBar, Label label, List<int> ListOfFoundMatches, int lengthX)
        {
            var progressRTB = new Progress<RTBProgressData>((value) =>
            {
                if (this.Created)
                {
                    RTB.Select(value.Start, value.Length);
                    RTB.SelectionBackColor = Color.Yellow;
                }
            });

            var progressPB = new Progress<int>((value) =>
            {
                if (this.Created)
                {
                    progressBar.Value = value;
                    label.Text = $"{value}%";
                }
            });

            Task coloration = Task.Run(() => display.HighlightTextFound
            (
                ListOfFoundMatches,
                lengthX,
                progressRTB,
                token
            ));

            Task progressBarWork = Task.Run(() => display.ProcessData
            (
                ListOfFoundMatches.Count,
                progressPB,
                token
            ));

            await Task.WhenAll(coloration, progressBarWork);

            coloration.Dispose();
            progressBarWork.Dispose();
        }
    }
}
