using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ServerDiplom.BusinessLogic
{
    class SearchAlgorithms
    {
        private readonly object block = new object();

        private Dictionary<char, int> valueShiftTime;

        private long countBF = 0;
        private long countRK = 0;
        private long countKMPPF = 0;
        private long countKMPZF = 0;
        private long countBMH = 0;

        #region Time algorithms 
        public void BrutForceTime(string x, string s, ResultAlgorithm bruteForce) //Функция последовательного поиска
        {
            lock (block)
            {
                bruteForce.AlgorithmName = "Алгоритм последовательного поиска";

                TimeSpan tt;
                Stopwatch sw = new Stopwatch();
                string t;

                List<int> nom = new List<int>();

                sw.Start();

                for (int i = 0; i < s.Length - x.Length + 1; i++)
                {
                    bool flag = true;
                    int j = 0;
                    while ((flag == true) && (j < x.Length))
                    {
                        if (x[j] != s[i + j])
                            flag = false;
                        j++;
                    }
                    if (flag == true)
                        nom.Add(i);
                }

                sw.Stop();
                tt = sw.Elapsed;
                sw.Reset();
                t = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", tt.Hours, tt.Minutes, tt.Seconds, tt.Milliseconds);

                bruteForce.ListOfFoundMatches = nom;
                bruteForce.Timer = t;
                bruteForce.Tick = tt.Ticks;
            }
        }

        private int HashTime(string s)//Хеш-функция для алгоритма Рабина-Карпа
        {
            int rez = 0;

            for (int i = 0; i < s.Length; i++)
            {
                rez += s[i];//Сложение кодов букв
            }

            return rez;
        }

        public void RabinaKarpaTime(string x, string s, ResultAlgorithm rK)//Функция поиска алгоритмом Рабина
        {
            lock (block)
            {
                rK.AlgorithmName = "Алгоритм Рабина-Карпа";

                TimeSpan tt;
                Stopwatch sw = new Stopwatch();
                string t;

                int j;
                List<int> nom = new List<int>();

                sw.Start();

                int xhash = HashTime(x); //Вычисление хеш-функции первого слова длины образца в строке S
                int shash = HashTime(s.Substring(0, x.Length));
                for (int i = 0; i < s.Length - x.Length + 1; i++)
                { //Если значения хеш-функций совпадают
                    if (xhash == shash)
                    {
                        j = 0;
                        while (j < x.Length)
                        {
                            if (x[j] != s[i + j])
                            {
                                if (i < s.Length - x.Length)
                                {
                                    shash = shash - s[i] + s[i + x.Length];
                                    break;
                                }
                                break;
                            }

                            j++;
                        }
                        if (j == x.Length)
                        {
                            nom.Add(i);

                            if (i < s.Length - x.Length)
                            {
                                shash = shash - s[i] + s[i + x.Length];
                            }
                        }
                    }
                    else if (i < s.Length - x.Length)
                    {
                        shash = shash - s[i] + s[i + x.Length];
                    }
                }

                sw.Stop();
                tt = sw.Elapsed;
                sw.Reset();
                t = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", tt.Hours, tt.Minutes, tt.Seconds, tt.Milliseconds);

                rK.ListOfFoundMatches = nom;
                rK.Timer = t;
                rK.Tick = tt.Ticks;
            }
        }

        private int[] PFunctionTime(string s)
        {
            int[] result = new int[s.Length];
            int j = 0;

            for (int i = 1; i < s.Length; i++)
            {
                while (j >= 0 && s[j] != s[i])
                {
                    j--;
                }
                j++;
                result[i] = j;
            }

            return result;
        }

        public void KMPWithPFuncTime(string x, string s, ResultAlgorithm kMPWithPFunc)
        {
            lock (block)
            {
                kMPWithPFunc.AlgorithmName = "Алгоритм Кнута-Морриса-Пратта(префикс-функция)";

                TimeSpan tt;
                Stopwatch sw = new Stopwatch();
                string t;

                List<int> nom = new List<int>();

                sw.Start();

                int[] pi = PFunctionTime(x);
                int j = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    while (j > 0 && x[j] != s[i] && j < pi.Length)
                    {
                        j = pi[j - 1];
                    }
                    if (x[j] == s[i])
                        j++;
                    if (j == x.Length)
                    {
                        nom.Add(i - j + 1);
                        j = 0;
                    }
                }

                sw.Stop();
                tt = sw.Elapsed;
                sw.Reset();
                t = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", tt.Hours, tt.Minutes, tt.Seconds, tt.Milliseconds);

                kMPWithPFunc.ListOfFoundMatches = nom;
                kMPWithPFunc.Timer = t;
                kMPWithPFunc.Tick = tt.Ticks;
            }
        }

        private int[] ZFunctionTime(string x)
        {
            int n = x.Length;

            int[] z = new int[n];

            for (int i = 1, l = 0, r = 0; i < n; ++i)
            {
                if (i <= r)
                {
                    z[i] = Math.Min(r - i + 1, z[i - l]);
                }
                while (i + z[i] < n && x[z[i]] == x[i + z[i]])
                {
                    ++z[i];
                }
                if (i + z[i] - 1 > r)
                {
                    l = i;
                    r = i + z[i] - 1;
                }
            }

            return z;
        }

        public void ZAlgorithmTime(string x, string s, ResultAlgorithm algZ)
        {
            lock (block)
            {
                algZ.AlgorithmName = "Алгоритм использующий z-функцию";

                TimeSpan tt;
                Stopwatch sw = new Stopwatch();
                string t;

                List<int> nom = new List<int>();

                sw.Start();

                int n = x.Length;

                string res = x + "$" + s;   // we find the z array for [pat + '$' + text]

                int m = res.Length;

                int[] z = ZFunctionTime(res);

                for (int i = 0; i < m; i++)
                {
                    if (z[i] == n)
                    {
                        nom.Add(i - n - 1);
                    }
                }

                sw.Stop();
                tt = sw.Elapsed;
                sw.Reset();
                t = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", tt.Hours, tt.Minutes, tt.Seconds, tt.Milliseconds);

                algZ.ListOfFoundMatches = nom;
                algZ.Timer = t;
                algZ.Tick = tt.Ticks;
            }
        }

        private void ShiftBMHTime(string x)
        {
            valueShiftTime = new Dictionary<char, int>();

            for (int i = x.Length - 2; i >= 0; i--)
            {
                if (!valueShiftTime.ContainsKey(x[i]))
                {
                    valueShiftTime.Add(x[i], x.Length - 1 - i);
                }
            }
        }

        public void BMHTime(string x, string s, ResultAlgorithm bMH)
        {
            lock (block)
            {
                bMH.AlgorithmName = "Алгоритм Бойера-Мура-Хорспула";

                TimeSpan tt;
                Stopwatch sw = new Stopwatch();
                string t;

                sw.Start();

                ShiftBMHTime(x);

                List<int> nom = new List<int>();

                for (int i = 0; i < s.Length - x.Length + 1; i++)
                {
                    int j = x.Length - 1;
                    bool match = false;

                    while (j >= 0)
                    {
                        if (s[i + j] != x[j])
                        {
                            if (match == true)
                            {
                                if (valueShiftTime.ContainsKey(x[x.Length - 1]))
                                {
                                    i += valueShiftTime[x[x.Length - 1]] - 1;
                                }
                                else if (x.Length - 2 >= 0)
                                {
                                    i += x.Length - 2;
                                }

                                match = false;
                            }
                            else
                            {
                                if (valueShiftTime.ContainsKey(s[i + j]))
                                {
                                    i += valueShiftTime[s[i + j]] - 1;
                                }
                                else if (x.Length - 2 >= 0)
                                {
                                    i += x.Length - 2;
                                }
                            }

                            break;
                        }
                        else
                        {
                            match = true;
                            j--;
                        }
                    }

                    if (match == true)
                    {
                        nom.Add(i);
                    }
                }

                sw.Stop();
                tt = sw.Elapsed;
                sw.Reset();
                t = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", tt.Hours, tt.Minutes, tt.Seconds, tt.Milliseconds);

                bMH.ListOfFoundMatches = nom;
                bMH.Timer = t;
                bMH.Tick = tt.Ticks;
            }
        }
        #endregion
    }
}
