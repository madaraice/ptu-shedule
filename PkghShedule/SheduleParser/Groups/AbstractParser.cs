using System;
using System.Collections.Generic;
using System.Text;

namespace SheduleParser.Groups
{
    public abstract class AbstractParser
    {
        public string StartWord { get; set; }
        public string EndWord { get; set; }
        
        public virtual string Parse(string shedule)
        {
            int startIndex = shedule.IndexOf(StartWord);
            int endIndex = shedule.IndexOf(EndWord);
            
            return shedule.Substring(startIndex, endIndex - startIndex);
        }
    }
}
