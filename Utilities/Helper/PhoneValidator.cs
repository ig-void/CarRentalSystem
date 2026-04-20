using Shared.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Utilities.Helper
{
    public class PhoneValidator
    {
        public static string ValidatePhone(string phone)
        {
            if(string.IsNullOrEmpty(phone)) return Messages.EmptyPass;
            if(phone.Length < 10) return Messages.InvalidPass;
            return null;
        }
    }
}
