using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBreaker
{
    class Atbash : Cracker
    {
        Dictionary<char, char> Mapping = InitAtbash();
        public string Crack(string input)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char character in input) 
            {
                sb.Append(GetChar(character));
            }
            return sb.ToString();
        }

        private char GetChar(char input)
        {
            if(input == ' ')
            {
                return ' ';
            }
            return Mapping[Char.ToLower(input)];
        }

        private static Dictionary<char, char> InitAtbash()
        {
            Dictionary<char, char> mapping = new Dictionary<char, char>();
            for(int i = 0; i < Cracker.Characters.Count; i++)
            {
                mapping.Add(Cracker.Characters[i], Cracker.Characters[Cracker.Characters.Count - i - 1]);
            }
            return mapping;
        }
    }
}
