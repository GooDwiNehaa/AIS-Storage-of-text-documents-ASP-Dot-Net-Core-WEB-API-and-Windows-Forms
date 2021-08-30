using System;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Windows.Forms;
using ClientDiplom.ClientLogic;
using ClientDiplom.Data;

namespace ClientDiplom.ViewForms
{
    public partial class RowsAndGraphsForm : Form
    {
        private HttpClient client;
        private string documentName;

        private Display display;
        public RowsAndGraphsForm(HttpClient client, string documentName, int countSymDoc)
        {
            InitializeComponent();

            this.client = client;
            this.documentName = documentName;

            this.CountSymbolsDocTB.Text = countSymDoc.ToString();

            display = new Display();
        }

        private void toolStripAddBtn_Click(object sender, EventArgs e)
        {
            ManageStringForm manageStringForm = new ManageStringForm("Добавление", "Добавить");
            manageStringForm.ShowDialog();

            string str = manageStringForm.str;

            if (str != "")
            {
                bool exist = false;

                for (int i = 0; i < DGV.Rows.Count - 1; i++)
                {
                    if (DGV.Rows[i].Cells[0].Value.ToString().Equals(str))
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    DGV.Rows.Add(str, str.Length);
                    MessageBox.Show("Строка успешно добавлена!");
                }
                else
                {
                    MessageBox.Show("Данная строка уже есть в таблице!");
                }

                exist = false;
            }
        }

        private void toolStripDelBtn_Click(object sender, EventArgs e)
        {
            if (DGV.CurrentRow.Cells[0].Value != null)
            {
                DGV.Rows.Remove(DGV.CurrentRow);

                MessageBox.Show("Строка успешно удалена!");
            }
        }

        private void toolStripEditBtn_Click(object sender, EventArgs e)
        {
            ManageStringForm manageStringForm = new ManageStringForm("Редактирование", "Применить изменения", DGV.CurrentRow.Cells[0].Value.ToString());
            manageStringForm.ShowDialog();

            string str = manageStringForm.str;

            if (str != "")
            {
                DGV.CurrentRow.Cells[0].Value = str;
                DGV.CurrentRow.Cells[1].Value = str.Length;

                MessageBox.Show("Изменение успешно применены!");
            }
        }

        private async void toolStripBuildChartBtn_Click(object sender, EventArgs e)
        {
            if (DGV.CurrentRow.Cells[0].Value != null)
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                ResearchSourceData researchSourceData = new ResearchSourceData
                {
                    DocumentName = documentName,
                    Row = DGV.CurrentRow.Cells[0].Value.ToString()
                };

                LoadingForm loadingForm = new LoadingForm();

                loadingForm.CloseLoadingForm += async delegate
                {
                    var response = await client.GetAsync($"cancel/{"research"}");

                    if (response.IsSuccessStatusCode)
                    {
                        formsPlot1.Plot.Clear();
                        loadingForm.Close();
                    }
                };

                loadingForm.pB.Style = ProgressBarStyle.Marquee;
                loadingForm.pB.MarqueeAnimationSpeed = 15;
                loadingForm.label.Text = "";
                loadingForm.label.BackColor = Color.Transparent;

                loadingForm.Show();

                try
                {
                    var response = await client.PostAsJsonAsync("research", researchSourceData);

                    if (response.IsSuccessStatusCode)
                    {
                        var algsChart = await response.Content.ReadFromJsonAsync<AlgorithmsChartData>();

                        if (algsChart.AlgZ != null && algsChart.BF != null && algsChart.BHM != null && algsChart.KMP != null && algsChart.RK != null)
                        {
                            CountMatchesDocTB.Text = algsChart.BF.CountMatches.ToString();

                            formsPlot1.Plot.Clear();

                            formsPlot1.Plot.Title(documentName);

                            display.ShowChart(formsPlot1, algsChart);

                            loadingForm.Close();
                        }
                        else
                        {
                            MessageBox.Show("Построение графика успешно отменено!");
                        }
                    }
                    else
                    {
                        loadingForm.Close();
                        MessageBox.Show("Ошибка при построении графика!");
                    }
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                    MessageBox.Show("Ошибка при отмене построения графика, невозможно отменить построение графика!");
                }
            }
        }

        private void toolStripDownloadChartBtn_Click(object sender, EventArgs e)
        {
            SFD.Filter = "PNG files(*.png)|*.png";

            if (SFD.ShowDialog() == DialogResult.OK)
            {
                formsPlot1.Plot.SaveFig(SFD.FileName);
                MessageBox.Show("График успешно сохранен!");
                SFD.FileName = "";
            }
            else
            {
                return;
            }
        }
    }
}
