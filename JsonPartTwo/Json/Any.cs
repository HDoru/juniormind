using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class Any : IPattern
    {
        readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
           if(!string.IsNullOrEmpty(text) || accepted.Contains(text[0]))
            {
                return new Match(text[1..], true);
            }

           return new Match(text, true);
        }
    }
}
