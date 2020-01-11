using System;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using HtmlAgilityPack;

namespace Test
{
    class Program
    {
        private const string SheduleUrl = "https://pkgh.edu.ru/obuchenie/shedule-of-classes.html";
        static async Task Main(string[] args)
        {
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(await SheduleUrl.GetStringAsync());

            var value = html.DocumentNode
                .SelectNodes("/html[1]/body[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/section[2]/div[2]")
                .First();

            var divs = html
                .GetElementbyId("system")
                .ChildNodes
                .Where(x => x.Name == "div");

            var temp = html
                .GetElementbyId("system");
            //.ChildNodes
            //.Where(x => x.HasClass("row"));


            //var nodes = html.DocumentNode.DescendantsAndSelf("div")
            //    .Select(y => y.Descendants()
            //        .Where(x => x.Attributes["class"].Value == "shedule"))
            //    .ToList();
        }
    }
}
