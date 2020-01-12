using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using HtmlAgilityPack;

namespace SheduleParser
{
    public class Parser
    {
        private const string SheduleUrl = "https://pkgh.edu.ru/obuchenie/shedule-of-classes.html";
        private const string StartWords = "Программирование в компьютерных системах";
        private const string EndWords = "Информационные системы и программирование";
        private const string XPathToShedule = "/html[1]/body[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/section[2]/div[2]";

        public static async Task<string> Parse(string group = "default")
        {
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(await SheduleUrl.GetStringAsync());

            string fullShedule = html.DocumentNode
                .SelectNodes(XPathToShedule)
                .First()
                .InnerText;

            // start - Программирование в компьютерных системах
            int startIndex = fullShedule.IndexOf(StartWords);
            // end - Информационные системы и программирование
            int endIndex = fullShedule.IndexOf(EndWords);

            var programmerShedule = fullShedule
                .Substring(startIndex, endIndex - startIndex)
                .Replace("&copy; t3cHn0pR!3$T.", "")
                .Replace("&nbsp;", "");

            if (group != "default")
            {
                programmerShedule = Groups.Groups.GroupsMap[group].Parse(programmerShedule);
            }

            return programmerShedule;
        }
    }
}
