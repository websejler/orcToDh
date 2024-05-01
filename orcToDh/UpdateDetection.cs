using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using IniParser;
using IniParser.Model;
using System.Reflection.Metadata;

namespace orcToDh
{
    public class UpdateDetection
    {
        public const string PATH_TO_SERVER = "https://github.com/websejler/orcToDh/releases";

        public static async Task<string> GetHtmlFromWebsite(string url)
        {
            // Load HTML content from the URL
            string htmlContent;
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument document = web.Load(url);
                htmlContent = document.DocumentNode.InnerHtml;
            } catch (Exception e)
            {
                //Console.WriteLine("Error: " + e.Message);
                htmlContent = "";
            }

            // Extract HTML content

            // Print or process the HTML content as needed
            //Console.WriteLine(htmlContent);
            return htmlContent;
        }



        // Call the CountOccurrences method in the CheckForUpdate method
        public static bool CheckForUpdate()
        {
            string html = GetHtmlFromWebsite(PATH_TO_SERVER).Result;

            string pattern = @"KEY\d{14}ENDkEY";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(html);

            List<string> matchList = new HashSet<string>(matches.Cast<Match>().Select(m => m.Value).ToList()).ToList();

            //Console.WriteLine("Number of matches: " + matchList.Count);
            //Console.WriteLine("Current working directory: " + Environment.CurrentDirectory);

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("setting.ini");

            string bdValue = data["Settings"]["BD"];
            DateTime BD = GetDateTime(bdValue);
            //Console.WriteLine("BD: " + BD);

            foreach (string match in matchList)
            {
                string date = match.Substring(3, 14);
                DateTime dt = GetDateTime(date);
                //Console.WriteLine("Date: " + dt);
                if (dt > BD)
                {
                    Console.WriteLine("Update available");
                    return true;
                }
            }

            return false;
        }

        public static DateTime GetDateTime(string s)
        {
            DateTime dt = DateTime.ParseExact(s, "yyyyMMddHHmmss", null);
            return dt;
        }
    }
}
