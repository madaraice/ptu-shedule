using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Newtonsoft.Json;

namespace SheduleParser.Groups
{
    internal class ParserIP18_4 : AbstractParser
    {
        public ParserIP18_4()
        {
            StartWord = "ИП-18-4";
        }

        public override string Parse(string shedule)
        {
            int startIndex = shedule.IndexOf(StartWord);

            shedule = shedule.Substring(startIndex);

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
