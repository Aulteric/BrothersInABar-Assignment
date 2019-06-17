using System;
using System.Collections.Generic;
using System.Linq;

namespace Brothers_in_a_bar_Assignment
{
    class Program
    {
        public static List<int> InputValidator()
        {
            var temp = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var ParsedInput = new List<int>();
            for (int i = 0; i < temp.Length; i++)
            {
                int Value;
                if (int.TryParse(temp[i], out Value))
                {
                    ParsedInput.Add(Value);
                }
                else
                {
                    Console.WriteLine($"{temp[i]} is not a valid integer");
                    ParsedInput = InputValidator();
                }
            }
            return ParsedInput;
        }

        private static int MaxRoundOfDrinks(List<int> glasses)
        {
            int CounterOfRounds = 0;
            for (int i = 0; i < glasses.Count - 2; i++)
            {
                if (glasses[i] == glasses[i+1] && glasses[i] == glasses[i + 2])
                {
                    CounterOfRounds++;
                    glasses.RemoveRange(i, 3);
                    i = 0;
                }
            }
            return CounterOfRounds;
        }
        static void Main(string[] args)
        {
            var glasses = InputValidator();
            Console.WriteLine($"The maximum number of drinks that the brothers can drink is {MaxRoundOfDrinks(glasses)}");           
        }
    }
}
