using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal
{
    internal class MethToCheckInputValue
    {
        public static bool CheckThatInputLoginMeetTheRequirements(string input)
        {
            bool output;
            bool isSpecial = false;
            int charsCounter = 0;
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";

            // Check that input value contains special characters AND how many CHARS is in it
            foreach (var item in specialChar)
            {
                if (input.Contains(item))
                {
                    isSpecial = true;
                }
            }

            // Check how many
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    charsCounter++;
                }
            }

            // if input value is string then output = true, else output = false
            if (isSpecial == true)
            {
                Console.WriteLine("[!] Input value contains a special character.");
                output = false;
            }
            else
            {
                if (input.Any(c => Char.IsWhiteSpace(c)) == true && input.Length == 1)
                {
                    Console.WriteLine("[!] Input value contains a space, please input correct value.");
                    output = false;
                }
                else if (IsNullOrEmpty(input) == true)
                {
                    Console.WriteLine("[!] Input value is only enter, please input correct value.");
                    output = false;
                }
                else if (int.TryParse(input, out int number) == true)
                {
                    Console.WriteLine($"[!] Input value '{number}' is only numeric.");
                    output = false;
                }
                else if (input.Length < 7 || input.Length > 15)
                {
                    Console.WriteLine($"[!] Input value '{input}' is not in the range (7 - 15 chars).");
                    output = false;
                }
                else if (charsCounter < 5)
                {
                    Console.WriteLine($"[!] Input value '{input}' contains not enough letters (min 5).");
                    output = false;
                }
                else
                {
                    output = true;
                }
            }

            return output;
        }

        public static bool IsNullOrEmpty(string value) => String.IsNullOrEmpty(value);

        public static bool CheckThatInputPasswordMeetTheRequirements(string input)
        {
            bool output;
            bool isSpecial = false;
            int lettersCounter = 0;
            int digitsCounter = 0;
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";

            // Check that input value contains special characters AND how many CHARS is in it
            foreach (var item in specialChar)
            {
                if (input.Contains(item))
                {
                    isSpecial = true;
                }
            }

            // Check how many
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    lettersCounter++;
                }
                else if (char.IsDigit(c))
                {
                    digitsCounter++;
                }
            }

            // if input value is string then output = true, else output = false
            if (isSpecial != true)
            {
                Console.WriteLine("[!] Input value should contains minimum one special character.");
                output = false;
            }
            else
            {
                if (input.Any(c => Char.IsWhiteSpace(c)) == true && input.Length == 1)
                {
                    Console.WriteLine("[!] Input value contains a space, please input correct value.");
                    output = false;
                }
                else if (input.Any(c => Char.IsUpper(c)) != true)
                {
                    Console.WriteLine($"[!] Input value {input} not contains UPPER letter.");
                    output = false;
                }
                else if (input.Any(c => Char.IsLower(c)) != true)
                {
                    Console.WriteLine($"[!] Input value {input} not contains lower letter.");
                    output = false;
                }
                else if (IsNullOrEmpty(input) == true)
                {
                    Console.WriteLine("[!] Input value is only enter, please input correct value.");
                    output = false;
                }
                else if (int.TryParse(input, out int number) == true)
                {
                    Console.WriteLine($"[!] Input value '{number}' is only numeric.");
                    output = false;
                }
                else if (digitsCounter < 2)
                {
                    Console.WriteLine($"[!] Input value '{input}' contains not enough digits (min 2).");
                    output = false;
                }
                else if (input.Length < 8 || input.Length > 20)
                {
                    Console.WriteLine($"[!] Input value '{input}' is not in the range (8 - 20 chars).");
                    output = false;
                }
                else if (lettersCounter < 4)
                {
                    Console.WriteLine($"[!] Input value '{input}' contains not enough letters (min 4).");
                    output = false;
                }
                else
                {
                    output = true;
                }
            }

            return output;
        }
    }
}
