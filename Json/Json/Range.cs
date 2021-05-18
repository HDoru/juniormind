using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    class Range : IPattern
    {
        private char start;
        private char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public bool Match(string text)
        {
            foreach (char s in text)
            {
                if (s < start || s > end )
                {
                   
                    return false;
                }
            }
            return true;
        }

        
    }
}
