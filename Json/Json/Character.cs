using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    class Character : IPattern
    {
        char character;

        public Character(char character)
        {
            this.character = character;
        }
        public bool Match(string text)
        {
            for(int i=0;i<= text.Length; i++)
            {
                if(string.IsNullOrEmpty(text)|| text[i]!= character)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
