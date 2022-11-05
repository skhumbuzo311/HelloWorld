using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAutoSpares.Services.Utils
{
    public static class Constants
    {
        public static string EmailValidationRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public static string PhoneNumberValidationRegex = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";
    }
}
