using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
   public class String:IPattern
    {
        readonly IPattern pattern;

        public String()
        {
            var hex = new Choice(

                new Range('a', 'f'));
              

            var quote = new Character('"');

          
            ;
            var characters = new Optional(
                new Sequence(new Many(hex)));

            this.pattern = new Sequence(quote, characters, quote);


        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
