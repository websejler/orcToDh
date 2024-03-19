using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;

namespace orcToDh
{
    public class UpdateDetection
    {
        public const string PATH_TO_SERVER = "https://www.dr.dk/";

        public static async Task<string> GetHtmlFromWebsite(string urlee)
        {
            string url = "https://github.com/websejler/orcToDh/releases"; // URL of the GitHub website or any specific page

            // Load HTML content from the URL
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = web.Load(url);

            // Extract HTML content
            string htmlContent = document.DocumentNode.InnerHtml;

            // Print or process the HTML content as needed
            Console.WriteLine(htmlContent);
            return "hi";
        }

        public static bool CheckForUpdate()
        {
            string html = GetHtmlFromWebsite(PATH_TO_SERVER).Result;
            
            return string.IsNullOrEmpty(html);
        }
    }
}
