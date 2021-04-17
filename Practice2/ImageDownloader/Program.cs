using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Images
{
    class Program
    {
        private static string imageUrl = "https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__340.jpg";
        private static string directoryPath = @"C:\Users\user\Desktop\Images";
        private const string DEFAULT_FILE_NAME = "image.jpg";
        private static string sourceFileName = "imageSource.txt";
        private static CancellationTokenSource cts;
        static async Task Main(string[] args)
        {
            cts = new CancellationTokenSource();
            ImageDownloader imageDownloader = new ImageDownloader();
            Task cancelTask = Task.Run(() => {
                while (!Console.KeyAvailable)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        cts.Cancel();
                }
            });
            Task downloadTask = imageDownloader.DownloadImageAsync(imageUrl, cts.Token);
            cts.CancelAfter(5800);
            try
            {
                await downloadTask;
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //await Task.WhenAll(cancelTask, downloadTask);

            //await StartDownload(imageUrl);

            //var imgSource = GetImageURLs(sourceFileName);
            //try
            //{
            //    await StartMultipleDownloads(imgSource);
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine("Something went wrong.");
            //}

            Console.WriteLine("Completed!");
           // Console.ReadLine();
        }

        static IEnumerable<string> GetImageURLs(string fileName)
        {
            //string[] urls = File.ReadAllLines(fileName);
            //return urls;

            List<string> source = new List<string>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    source.Add(sr.ReadLine());
                }
            }
            return source;
        }

        static async Task StartMultipleDownloads(IEnumerable<string> urls)
        {
            ImageDownloader imgDownloader = new ImageDownloader();

            List<Task> allTasks = new List<Task>();
            foreach (string url in urls)
            {
                Task task = StartDownload(url);
                allTasks.Add(task);
            }
            Task resultTask = Task.WhenAny(allTasks);
            try
            {
                await resultTask;
                Console.WriteLine("At least one image is saved");
            }
            catch (Exception ex)
            {
                foreach (Exception innerEx in resultTask.Exception.InnerExceptions)
                {
                    Console.WriteLine(innerEx.Message);
                }
            }
            //try
            //{
            //    foreach (var url in urls)
            //    {
            //        await StartDownload(url);
            //    }
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        static async Task StartDownload(string url)
        {
            ImageDownloader imgDownloader = new ImageDownloader();
            await imgDownloader.DownloadImageAsync(url);

            var di = Directory.CreateDirectory(directoryPath);
            string imageName = ExtractImageName(url);
            //string imageName = GenerateImageFileName(url);
            string filePath = Path.Combine(di.FullName, imageName);
            imgDownloader.SaveImage(filePath);
        }

        static string ExtractImageName(string url)
        {
            if (string.IsNullOrEmpty(url))
                return DEFAULT_FILE_NAME;

            int lastIndex = url.LastIndexOf('/');
            return url.Substring(lastIndex + 1);
        }

        static string GenerateImageFileName(string url)
        {
            var guid = new Guid();
            string dt = DateTime.Now.ToString("MMddyyyyHHmmssmmmm");
            return $"{guid}.jpg";
        }
    }
}
