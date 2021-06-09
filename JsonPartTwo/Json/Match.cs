using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class Match : IMatch
    {
        readonly string text;
        readonly bool success;

        public Match(string text, bool success)
        {
            this.text = text;
            this.success = success;
        }

        public bool Success()
        {
            return success;
        }

        public string RemainingText()
        {
            return text;
        }
    }
}
