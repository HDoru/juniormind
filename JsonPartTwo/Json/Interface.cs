using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    interface IMatch
    {
        bool Success();
        string RemainingText();
    }

    interface IPattern
    {
        IMatch Match(string text);
    }
}
