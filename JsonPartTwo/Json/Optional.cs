using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    class Optional : IPattern
    {
        readonly IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }


        public IMatch Match(string text)
        {
            var match = pattern.Match(text);

            return new Match(match.RemainingText(), true);
        }
    }
}
