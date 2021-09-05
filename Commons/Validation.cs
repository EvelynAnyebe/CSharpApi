using System;
using System.Text.RegularExpressions;


namespace CSharpApi.Commons
{
    public static class Validation
    {

        /// <summary>
        /// Cleans a name
        /// </summary>
        /// <param name="name">A string value which represents the name to clean</param>
        /// <returns>string</returns>
        public static string CleanName(string name)
        {
                var firstChar = (int)name[0];
                if (firstChar >= 65 && firstChar <= 91)
                {
                    return name;
                }
                else if (firstChar >= 97 && firstChar <= 122)
                {
                    return name.ToUpper()[0] + name.Substring(1);
                }

                return null;
           
        }


        /// <summary>
        /// This check if a name is correct. A name must be two characters above and does not start with a number
        /// </summary>
        /// <param name="name">The string value of name to check</param>
        /// <returns>bool</returns>
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            if (Char.IsNumber(name[0]) || name.Length < 2) return false;

            return true;
        }

        /// <summary>
        /// Checks that a password is 6 characters long
        /// </summary>
        /// <param name="password">The string value of the password</param>
        /// <returns>bool</returns>
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;

            if (password.Length < 6) return false;
            

            return true;
        }

        /// <summary>
        /// Checks that a valid Email is provided
        /// </summary>
        /// <param name="email">The string value of the email</param>
        /// <returns>bool</returns>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

        }


        /// <summary>
        /// Checks that a phone number is correct
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>bool</returns>
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber)) return false;

            if (phoneNumber.Length < 11 || phoneNumber.Length>11) return false;


            foreach(Char value in phoneNumber)
            {
                if (!Char.IsNumber(value)) return false;
            }


            return true;
        }

        /// <summary>
        /// Check to make sure the enter menu option is an integer
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int IsValidInput(string data)
        {
            bool isValid = int.TryParse(data, out int value);
            if (!isValid)
                return -1;
            else if (value < 0 || value > 5)
                return -1;
            else
                return value;
        }
    }
}
