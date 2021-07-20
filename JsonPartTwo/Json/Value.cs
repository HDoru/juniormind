using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class Value : IPattern
    {

        readonly IPattern pattern;


        public Value()
        {
            var ws = new Many(
                new Any(" \n\r\t"));

            var value = new Choice(
                new Number(),
                new String(),
                new Text("true"),
                new Text("false"),
                new Text("null"));

            var element = new Sequence(
               ws,
               value,
               ws);


            var member = new Sequence(
              ws,
              new String(),
              ws,
              new Character(':'),
              element);

            var Object = new Sequence(
               new Character('{'),
               ws,
               new List(member,
               new Character(',')),
               ws,
               new Character('}'));



            value.Add(Object);
            pattern = new Sequence(ws, value, ws);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
