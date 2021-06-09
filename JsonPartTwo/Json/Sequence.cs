using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
   public class Sequence : IPattern
    {
        readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            var match = new Match(text, true);

            foreach (var pattern in patterns)
            {
                match = (Match)pattern.Match(match.RemainingText());

                if (!match.Success())
                    return new Match(text, false);
            }

            return match;
        }
    }
}
