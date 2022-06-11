using MoviesPortal.Data;

namespace MoviesPortal.Methods
{
    public class CheckInputValue
    {
        public static bool CheckInputLogin(string input)
        {
            bool output;
            bool isSpecial = false;
            int charsCounter = 0;
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            string answer = "";

            // Check that input value contains special characters AND how many CHARS is in it
            foreach (var item in specialChar)
            {
                if (input.Contains(item))
                {
                    isSpecial = true;
                }
            }

            // Check how many letters
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    charsCounter++;
                }
            }
            if (isSpecial == true)
            {
                answer = "[!] Input value contains a special character.";
                output = false;
            }
            else
            {
                if (input.Any(c => Char.IsWhiteSpace(c)) == true && input.Length == 1)
                {
                    answer = "[!] Input value contains a space, please input correct value.";
                    output = false;
                }
                else if (string.IsNullOrEmpty(input) == true)
                {
                    answer = "[!] Input value is only enter, please input correct value.";
                    output = false;
                }
                else if (int.TryParse(input, out int number) == true)
                {
                    answer = $"[!] Input value '{number}' is only numeric.";
                    output = false;
                }
                else if (input.Length < 7 || input.Length > 15)
                {
                    answer = $"[!] Input value '{input}' is not in the range (7 - 15 chars).";
                    output = false;
                }
                else if (charsCounter < 5)
                {
                    answer = $"[!] Input value '{input}' contains not enough letters (min 5).";
                    output = false;
                }
                else
                {
                    output = true;
                }               

            }

            
            LoggedUser.WhoIsLogged();
            Console.WriteLine(answer);
            

            return output;
        }

        public static bool CheckInputPassword(string input)
        {
            bool output;
            bool isSpecial = false;
            int lettersCounter = 0;
            int digitsCounter = 0;
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            string answer = "";

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
                answer = "[!] Input value should contains minimum one special character.";
                output = false;
            }
            else
            {
                if (input.Any(c => Char.IsWhiteSpace(c)) == true && input.Length == 1)
                {
                    answer = "[!] Input value contains a space, please input correct value.";
                    output = false;
                }
                else if (input.Any(c => Char.IsUpper(c)) != true)
                {
                    answer = $"[!] Input value {input} not contains UPPER letter.";
                    output = false;
                }
                else if (input.Any(c => Char.IsLower(c)) != true)
                {
                    answer = $"[!] Input value {input} not contains lower letter.";
                    output = false;
                }
                else if (string.IsNullOrEmpty(input) == true)
                {
                    answer = "[!] Input value is only enter, please input correct value.";
                    output = false;
                }
                else if (int.TryParse(input, out int number) == true)
                {
                    answer = $"[!] Input value '{number}' is only numeric.";
                    output = false;
                }
                else if (digitsCounter < 2)
                {
                    answer = $"[!] Input value '{input}' contains not enough digits (min 2).";
                    output = false;
                }
                else if (input.Length < 8 || input.Length > 20)
                {
                    answer = $"[!] Input value '{input}' is not in the range (8 - 20 chars).";
                    output = false;
                }
                else if (lettersCounter < 4)
                {
                    answer = $"[!] Input value '{input}' contains not enough letters (min 4).";
                    output = false;
                }
                else
                {
                    output = true;
                }
            }

            LoggedUser.WhoIsLogged();
            Console.WriteLine(answer);

            return output;
        }

    }
}
