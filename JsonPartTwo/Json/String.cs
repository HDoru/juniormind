using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
   public class String : IPattern
    {

        readonly IPattern pattern;

        public String()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

            var quote = new Character('"');

            var escape = new Choice(
                new Any("\\\"/bfnrt"),
                new Sequence(new Character('u'), hex, hex, hex, hex));

            var character = new Choice(
                new Range(' ', '\u0021'),
                new Range('\u0023', '\u005B'),
                new Range('\u005D', '\uFFFF'),
                new Sequence(
                new Character('\\'),
                escape));
                                       ;
            var characters = new Optional(new OneOrMore(character));

            this.pattern = new Sequence(quote, characters, quote);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}