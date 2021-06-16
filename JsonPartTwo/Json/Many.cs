using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
   public class Many : IPattern
    {
        readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = new Match(text, true);


        }
    }
}
