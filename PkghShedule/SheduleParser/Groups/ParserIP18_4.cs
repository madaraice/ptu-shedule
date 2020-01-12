using System;
using System.Collections.Generic;
using System.Text;

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

            return shedule.Substring(startIndex);
        }
    }
}
