using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace loginCheck
{
    public class Mail
    {
        private static Regex createValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }
        public static bool isValidEmail(string emailAddress)
        {
            Regex validEmailRegex = createValidEmailRegex();
            bool isValid = validEmailRegex.IsMatch(emailAddress);
            return isValid;
        }
    }
}
