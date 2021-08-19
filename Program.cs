using System;

namespace CodeBreaker
{
    class Program
    {
        static void Main(string[] args)
        {
            while (DoProgram())
            {
                Console.WriteLine();
            }
        }

        public static bool DoProgram()
        {
            Console.WriteLine("what code type");
            string codeType = Console.ReadLine();
            Cracker cracker = null;
            switch(codeType)
            {
                case "offset":
                    cracker = DoOffset();
                    break;
                case "atbash":
                    cracker = DoAtbash();
                    break;
                case "offset_atbash":
                    cracker = DoOffsetAtbash();
                    break;
                case "keypad":
                    cracker = DoKeypad();
                    break;
                default:
                    Console.WriteLine("enter valid type");
                    return false;
            }
            if(cracker == null)
            {
                return false;
            }
            Console.WriteLine("enter input to be cracked");
            var input = Console.ReadLine();

            Console.WriteLine(cracker.Crack(input));
            return true;
        }

        private static Cracker DoOffset()
        {
            Console.WriteLine("enter the offset");
            bool success = int.TryParse(Console.ReadLine(), out int offset);
            if(!success)
            {
                Console.WriteLine("enter a valid number");
                return null;
            }
            Cracker cracker = new Offset(offset);
            return cracker;
        }

        private static Cracker DoKeypad()
        {
            Console.WriteLine("Enter the row number of the letters.");
            int row_num = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter the column number of the letters.");
            int column_num = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the letters");
            string letters = Console.ReadLine();
            return new Keypad(row_num, column_num, letters);
        }

        private static Cracker DoAtbash()
        {
            Cracker cracker = new Atbash();
            return cracker;
        }
        
        private static Cracker DoOffsetAtbash()
        {
            Console.WriteLine("enter the offset");
            bool success = int.TryParse(Console.ReadLine(), out int offset);
            if (!success)
            {
                Console.WriteLine("enter a valid number");
                return null;
            }
            Cracker cracker = new OffsetAtbash(offset);
            return cracker;
        }
    }
}
