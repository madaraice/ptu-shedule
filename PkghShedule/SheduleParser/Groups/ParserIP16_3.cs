using System;
using System.Collections.Generic;
using System.Text;

namespace SheduleParser.Groups
{
    internal class ParserIP16_3 : AbstractParser
    {
        public ParserIP16_3()
        {
            StartWord = "ИП-16-3";
            EndWord = "ИП-16-4";
        }
    }
}
