using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ClientDiplom.Data;
using ScottPlot;

namespace ClientDiplom.ClientLogic
{
    public class Display
    {
        private readonly object block1 = new object();
        private readonly object block2 = new object();
        public void HighlightTextFound(List<int> list, int listCount, IProgress<RTBProgressData> progress, CancellationToken token)
        {
            RTBProgressData data;

            lock (block1)
            {
                data = new RTBProgressData();
            }

            for (int i = 0; i < list.Count; i++)
            {
                lock (block1)
                {
                    Thread.Sleep(1);

                    try
                    {
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Операция отменена!");
                    }

                    data.Start = list[i];
                    data.Length = listCount;

                    progress.Report(data);
                }
            }
        }

        public void ProcessData(int k, IProgress<int> progress, CancellationToken token)
        {
            int index;
            int totalProcess;

            int valueBar;

            lock (block2)
            {
                index = 1;
                totalProcess = k;
            }


            for (int i = 0; i < totalProcess; i++)
            {
                lock (block2)
                {
                    Thread.Sleep(1);

                    try
                    {
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Операция отменена!");
                    }

                    valueBar = index++ * 100 / totalProcess;

                    progress.Report(valueBar);
                }

            }
        }

        public void Deselect(RichTextBox rtb)
        {
            rtb.SelectAll();
            rtb.SelectionBackColor = Color.White;
        }

        public void ShowChart(FormsPlot formsPlot1, AlgorithmsChartData algsChart)
        {
            double[] x = new double[] { 0, 1, 2, 3, 4 };

            double[] y = new double[]
            {
                        algsChart.BF.Time,
                        algsChart.RK.Time,
                        algsChart.KMP.Time,
                        algsChart.AlgZ.Time,
                        algsChart.BHM.Time
            };

            string[] labels = new string[]
            {
                        algsChart.BF.AlgorithmName,
                        algsChart.RK.AlgorithmName,
                        algsChart.KMP.AlgorithmName,
                        algsChart.AlgZ.AlgorithmName,
                        algsChart.BHM.AlgorithmName,
            };

            formsPlot1.Plot.XLabel("Алгоритмы поиска");
            formsPlot1.Plot.YLabel("Время в милисикундах");

            formsPlot1.Plot.AddBar(y, x, Color.Blue).ShowValuesAboveBars = true;
            formsPlot1.Plot.XTicks(x, labels);
        }
    }
}
