﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public interface IMatch
    {
        bool Success();
        string RemainingText();
    }

    public interface IPattern
    {
        IMatch Match(string text);
       
    }
}
