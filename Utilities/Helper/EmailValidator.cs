using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Utilities.Helper
{
    public class EmailValidator
    {
        private readonly static Regex _regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static string ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return  Messages.EmptyEmail;
            }
            if(! _regex.IsMatch(email)) return Messages.InvalidEmail;
            return null;
        }
    }
}
