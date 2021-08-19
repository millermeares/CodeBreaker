using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBreaker
{
    class Offset : Cracker
    {
        public int CharOffset { get; set; }
        public Offset(int offset)
        {
            CharOffset = offset;
        }

        public string Crack(string input)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach(char character in input)
            {
                sb.Append(GetChar(CharOffset, character));
            }
            return sb.ToString();
        }

        public static char GetChar(int offset, char input_char)
        {
            if(input_char==' ')
            {
                return ' ';
            }
            int first_ind = Cracker.Characters.IndexOf(Char.ToLower(input_char));
            while (offset > 0)
            {
                offset--;
                if(first_ind == 25)
                {
                    first_ind = -1;
                }
                first_ind++;
            }
            return Cracker.Characters[first_ind];
        }
    }
}
