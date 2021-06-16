﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class Text : IPattern
    {
        readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if(string.IsNullOrEmpty(text) || !text.StartsWith(prefix))
            {
                return new Match(text, false);
            }
            return new Match(text[1..], true);
        }

    }
}
