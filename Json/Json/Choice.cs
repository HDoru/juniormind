using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{

    class Choice : IPattern
    {
        private IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
           
        }


        public bool Match(string text)
        {
           
        }
    }



}
