using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class FileProcessing
    {
        private string fileName;
        private string[] allLines;
        public FileProcessing()
        {
        }

        public void ReadFile(string fileName)
        {
            this.allLines = File.ReadAllLines(fileName);
        }

        public void ProcessFile()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            CalculateSum(this.allLines);
            sw.Stop();
            Console.WriteLine("foreach loop : {0}ms", sw.ElapsedMilliseconds);

            sw.Reset();
            sw.Start();

            //sw.Restart();
            Parallel.ForEach(this.allLines, (line) =>
            {
                int sum = line.Split(',').Select(x => ParseToInt(x)).Sum();
                Console.WriteLine(sum);
            });
            sw.Stop();
            Console.WriteLine("Parallel foreach loop : {0}ms", sw.ElapsedMilliseconds);
        }

        private void CalculateSum(string[] allLines)
        {
            foreach (string line in allLines)
            {
                var sum = line.Split(',').Select(x => ParseToInt(x)).Sum();
                //int lineEntry = 0;
                //var sum1 = line.Split(',').Where(e => int.TryParse(e, out int lineEntry)).Select(e => Convert.ToInt32(e)).Sum();
                //var sum2 = line.Split(',').Sum(l => Convert.ToInt32(l));
                Console.WriteLine(sum);
                //Console.WriteLine(sum1);
                //Console.WriteLine(sum2);
            }
        }

        public void PrintNumbersFreq()
        {            
            Dictionary<int, int> numbersFreq = new Dictionary<int, int>();
            ConcurrentDictionary<int, int> numbersFreqConcurrent = new ConcurrentDictionary<int, int>();

            Parallel.ForEach(allLines, (line) =>
            {
                var nums = line.Split(',').Select(x => ParseToInt(x));
                foreach (int num in nums)
                {
                    if (numbersFreqConcurrent.ContainsKey(num))
                    {
                        numbersFreqConcurrent[num]++;
                    }
                    else
                    {
                        numbersFreqConcurrent.TryAdd(num, 1);
                    }
                }
                Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]");
                
                //foreach (var keyValuePair in numbersFreqConcurrent)
                //{
                //    Console.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value}");
                //}
            });

            
            foreach (string line in this.allLines)
            {
                var nums = line.Split(',').Select(x => ParseToInt(x));
                foreach (int num in nums)
                {
                    if (numbersFreq.ContainsKey(num))
                    {
                        numbersFreq[num]++;
                    }
                    else
                    {
                        numbersFreq.Add(num, 1);
                    }
                }
            }

            Console.WriteLine("d {0}", numbersFreq.Count());
            Console.WriteLine("c d {0}", numbersFreqConcurrent.Count());
            foreach (var keyValuePair in numbersFreqConcurrent)
            {
                Console.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value}");
            }

        }
        private int ParseToInt(string a)
        {
            bool parsed = int.TryParse(a, out int lineEntry);
            return lineEntry;
        }
    }
}
