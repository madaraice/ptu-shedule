using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Newtonsoft.Json;

namespace SheduleParser.Groups
{
    public abstract class AbstractParser
    {
        public string StartWord { get; set; }
        public string EndWord { get; set; }

        protected readonly List<string> daysOfTheWeek = new List<string>
        {
            "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"
        };

        public virtual string Parse(string shedule)
        {
            int startIndex = shedule.IndexOf(StartWord);
            int endIndex = shedule.IndexOf(EndWord);
            shedule = shedule.Substring(startIndex, endIndex - startIndex);

            dynamic result = new ExpandoObject();
            result.groupName = StartWord;

            int startLocalIndex;
            int endLocalIndex;
            var daysOfTheWeekWithShedule = new Dictionary<string, string>();
            string substringShedule;

            for (int i = 0; i < daysOfTheWeek.Count; i++)
            {
                if (daysOfTheWeek[i] == "Суббота")
                {
                    startLocalIndex = shedule.IndexOf(daysOfTheWeek[i]);
                    endLocalIndex = shedule.IndexOf("Последнее");
                    substringShedule = shedule.Substring(startLocalIndex + daysOfTheWeek[i].Length,
                        endLocalIndex - startLocalIndex - daysOfTheWeek[i].Length);

                    daysOfTheWeekWithShedule[$"{daysOfTheWeek[i]}"] = TextBeautifier.Beauty(substringShedule);
                    break;
                }

                startLocalIndex = shedule.IndexOf(daysOfTheWeek[i]);
                endLocalIndex = shedule.IndexOf(daysOfTheWeek[i + 1]);

                substringShedule = shedule.Substring(startLocalIndex + daysOfTheWeek[i].Length,
                    endLocalIndex - startLocalIndex - daysOfTheWeek[i].Length);

                daysOfTheWeekWithShedule[$"{daysOfTheWeek[i]}"] = TextBeautifier.Beauty(substringShedule);
            }

            result.shedule = daysOfTheWeekWithShedule;

            return JsonConvert.SerializeObject(result);
        }
    }
}
