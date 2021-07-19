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

          

           
            pattern = new Sequence(ws, value, ws);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
