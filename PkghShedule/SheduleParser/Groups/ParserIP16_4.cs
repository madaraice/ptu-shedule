using System;
using System.Collections.Generic;
using System.Text;

namespace SheduleParser.Groups
{
    internal class ParserIP16_4 : AbstractParser
    {
        public ParserIP16_4()
        {
            StartWord = "ИП-16-4";
            EndWord = "ИП-17-3";
        }
    }
}
