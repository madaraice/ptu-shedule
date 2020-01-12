using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Text;

namespace SheduleParser.Groups
{
    public static class Groups
    {
        public static Dictionary<string, AbstractParser> GroupsMap = new Dictionary<string, AbstractParser>
        {
            { "ИП-16-3",  new ParserIP16_3() },
            { "ИП-16-4",  new ParserIP16_4() },
            { "ИП-17-3",  new ParserIP17_3() },
            { "ИП-17-4",  new ParserIP17_4() },
            { "ИП-18-3",  new ParserIP18_3() },
            { "ИП-18-4",  new ParserIP18_4() },
        };
    }
}
