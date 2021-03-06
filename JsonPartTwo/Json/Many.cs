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
            var match = pattern.Match(text);

            while (match.Success())
            {
                text = match.RemainingText();
                match = pattern.Match(text);
            }

            return new Match(text, true);
        }
    }
}
