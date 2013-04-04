using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DataAccess;

namespace Logical
{
    public class Validation_lg
    {
        private String passwordLength(Data data)
        {
            string password = data.getString("password");

            if (password.Length > 8)
            {
                return "";
            }
            else
            {
                return "Enter minimum of 8 characters";
            }
        }

        private String passwordUpperCase(Data data)
        {
            int upper = 0;
            string password = data.getString("password");
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsUpper(password[i]))
                {
                    upper++;
                }
            }
            if (upper > 1 || upper < 1)
            {
                return "Enter 1 Uppercase only";
            }
            else
            {
                return "";
            }
        }

        private String passwordSymbol(Data data)
        {
            int symbol = 0;
            string password = data.getString("password");
            for (int i = 0; i < password.Length; i++)
            {
                if (!Char.IsNumber(password[i]) && !Char.IsLetter(password[i]))
                {
                    symbol++;
                }
            }
            if (symbol > 1 || symbol < 1)
            {
                return "Enter 1 Symbol only";
            }
            else
            {
                return "";
            }
        }

        private String passwordNumber(Data data)
        {
            int number = 0;
            string password = data.getString("password");
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsNumber(password[i]))
                {
                    number++;
                }
            }
            if (number > 1 || number < 1)
            {
                return "Enter any 1 number from 0-9";
            }
            else
            {
                return "";
            }
        }

        public Tuple<String, String, String, String, bool> registerError(Data data)
        {
            string length = passwordLength(data);
            string upper = passwordUpperCase(data);
            string number = passwordNumber(data);
            string symbol = passwordSymbol(data);
            bool check = false;
            if (length.Length > 0 || upper.Length > 0 || number.Length > 0 || symbol.Length > 0)
            {
                check = true;
            }

            return new Tuple<string, string, string, string, bool>(length, upper, number, symbol, check);
        }
    }
}
