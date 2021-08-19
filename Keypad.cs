using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBreaker
{
    public class Keypad : Cracker
    {
        private Dictionary<int, Dictionary<int, char[]>> _grid = new Dictionary<int, Dictionary<int, char[]>>();
        public Keypad(int row_in_grid, int column_in_grid, string letters)
        {
            int current_index = Cracker.Characters.IndexOf(letters[0]);
            int count = 0;
            while(count <= 25)
            {
                count++;
                if(!_grid.ContainsKey(row_in_grid))
                {
                    _grid.Add(row_in_grid, new Dictionary<int, char[]>());
                }
                if(!_grid[row_in_grid].ContainsKey(column_in_grid))
                {
                    _grid[row_in_grid].Add(column_in_grid, current_index == 24 ? new char[2] : new char[3]);
                }
                _grid[row_in_grid][column_in_grid][current_index % 3] = Cracker.Characters[current_index];

                if(_grid[row_in_grid][column_in_grid].Length - 1 == current_index % 3)
                {
                    column_in_grid++;
                }
                if(column_in_grid > 2)
                {
                    row_in_grid++;
                }
                if(column_in_grid > 2)
                {
                    column_in_grid = 0;
                }

                if(row_in_grid > 2)
                {
                    row_in_grid = 0;
                }

                current_index += 1;
                if(current_index > 25)
                {
                    current_index = 0;
                }
                
            }
            
        }
        public string Crack(string input)
        {
            string[] words = input.ToLower().Split("  ");
            StringBuilder output = new StringBuilder();
            foreach(string word in words)
            {
                string[] letters = word.ToLower().Split(' ');
                foreach (string trio in letters)
                {
                    int row = GetRow(trio[0]);
                    int column = GetColumn(trio[1]);
                    int within_grid = int.Parse(trio[2].ToString());
                    output.Append(_grid[row][column][within_grid - 1]);
                }
                output.Append(" ");
            }
            return output.ToString();
        }


        private int GetRow(char letter)
        {
            switch(letter)
            {
                case 'u':
                    return 0;
                case 's':
                    return 1;
                case 'd':
                    return 2;
            }
            return -1;
        }
        private int GetColumn(char letter)
        {
            switch(letter)
            {
                case 'c':
                    return 1;
                case 'l':
                    return 2;
                case 'r':
                    return 0;
            }
            return -1;
        }
    }
}
