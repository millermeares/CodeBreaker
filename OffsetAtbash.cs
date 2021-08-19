using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBreaker
{
    class OffsetAtbash : Cracker
    {
        private Offset _offsetCracker;
        public OffsetAtbash(int offset)
        {
            _offsetCracker = new Offset(offset);
        }

        public string Crack(string input)
        {
            string after_offset = _offsetCracker.Crack(input);
            Atbash atbash = new Atbash();
            return atbash.Crack(after_offset);
        }
    }
}
