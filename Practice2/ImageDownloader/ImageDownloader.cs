using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Images
{
    class ImageDownloader
    {
        private byte[] imageBytes;
        public async Task DownloadImageAsync(string url)
        {
            Console.WriteLine("Starting image download....");

            HttpClient httpClient = new HttpClient();
            this.imageBytes = await httpClient.GetByteArrayAsync(url);

            //var result = httpClient.GetByteArrayAsync(url);
            //this.imageBytes = result.Result;

            Console.WriteLine("Successfully downloaded image.");
        }

        public async Task DownloadImageAsync(string url, CancellationToken token)
        {
            Thread.Sleep(5000);
            if(token.IsCancellationRequested)
                Console.WriteLine("cancellation requested");
            else
                Console.WriteLine("no cancellation");
            
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url, token);
            this.imageBytes = await response.Content.ReadAsByteArrayAsync(); 
            
            if(imageBytes != null)
            {
                Console.WriteLine("Downloaded image");
            }
            //var result = httpClient.GetByteArrayAsync(url);
            //this.imageBytes = result.Result;

        }

        public void SaveImage(string filePath)
        {
            Console.WriteLine("Saving image....");

            using(Stream fr = new FileStream(filePath, FileMode.Create))
            {
                fr.Write(this.imageBytes, 0, this.imageBytes.Length);
            }

            Console.WriteLine("Successfully saved image.");
        }
    }
}
