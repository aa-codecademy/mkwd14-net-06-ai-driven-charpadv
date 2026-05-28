using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryBeingFit.Services.Helpers
{
    public static class ValidationHelper
    {
        public static bool ValidateName(string name)
        {
            if(name.Length < 2) return false;
            return true;
        }
        public static bool ValidateUsername(string username)
        {
            if (username.Length < 6) return false;
            return true;
        }
        public static bool ValidatePassoword(string passoword)
        {
            if(passoword.Length < 6) return false;
            bool isNum = false;
            foreach(char ch in passoword)
            {
                isNum = int.TryParse(ch.ToString(), out int num);
                if(isNum) break;
            }
            if(!isNum) return false;

            return true;
        }
        public static int ValidateNumber(string number, int range)
        {
            bool isNum = int.TryParse(number, out int num);
            if (!isNum)
            {
                return -1;
            }
            if(num < 1 || num > range)
            {
                return -1;
            }
            return num;
        }
    }
}
