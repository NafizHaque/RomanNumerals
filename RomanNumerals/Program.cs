using System;

namespace RomanNumerals
{
    public class Program
    {
        public static void Main(string[] args)
        {

            if (args.Length < 1)
            {
                Console.WriteLine("No imput found! This program uses ONLY the first argument.");
                return;
            }

            string input = args[0];

            Dictionary<string, int> numerals = new Dictionary<string, int>()
            {
                { "M", 1000 },
                { "CM", 900 },
                { "D", 500 },
                { "CD", 400 },
                { "C", 100 },
                { "XC", 90 },
                { "L", 50 },
                { "XL", 40 },
                { "X", 10 },
                { "IX", 9 },
                { "V", 5 },
                { "IV", 4 },
                { "I", 1 }
            };

            int.TryParse(input, out int number);

            RomanNumeralCalculator calculator = new RomanNumeralCalculator(numerals);

            if(number > 0 && number < 4000){
                Console.WriteLine(calculator.IntToRoman(number));
            }
            else if(number == 0)
            {
                Console.WriteLine(calculator.RomanToInt(input));
            }
        }
    }

    public class RomanNumeralCalculator
    {
        private Dictionary<string, int> _numerals;

        public RomanNumeralCalculator(Dictionary<string,int> numerals)
        {
            _numerals = numerals;
        }
        public string IntToRoman(int number)
        {
            {
                // for this solution we are given a number.
                // we have created a dictionary with each numeral to its respective integer.
                // solution will be subtracting numerals from the input then appending the numeral to a string.
                // when the input is 0 then the appended string should have all the numerals required.

                string finalRomanString = string.Empty;

                // we go through each keypair in the numeral dictionary from highest to lowest.
                foreach (KeyValuePair<string, int> numeral in _numerals.OrderByDescending(n => n.Value))
                {
                    // while the number is higher than the value, continue subtracting.
                    while (number >= numeral.Value)
                    {
                        finalRomanString += numeral.Key;
                        number -= numeral.Value;
                    }
                }

                return finalRomanString;
            }
        }

        public int RomanToInt(string romanString)
        {

            // similar approach to this reverse solution.
            // we already have a working dictionary with the keyvalue pairs.
            // solution will be adding to a final number for each key corresponding to the dictionary.
            // we will be removing the letter from the string once it has been processed.
            // when the input is empty, we should have the correct integer.

            int finalRomanInteger = 0;

            // we go through each keypair in the numeral dictionary from highest to lowest.
            foreach (KeyValuePair<string, int> numeral in _numerals.OrderByDescending(n => n.Value))
            {
                // while the string contain the same key, continue adding to the final integer.
                while (romanString.StartsWith(numeral.Key))
                {
                    finalRomanInteger += numeral.Value;
                    romanString = romanString.Substring(numeral.Key.Length);
                }
            }

            return finalRomanInteger;

        }
    }
}
