using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons_list.EncDec
{
    public static class Encry_Decry
    {
        public static string sk = "@1234sk";
        public static string Encrypass(string password)
        {
            password = password + sk;
            var passwordinBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordinBytes);
        }

        public static string Decrypass (string password)
        {
            var Depassword = Convert.FromBase64String(password);
            var Acpassword = Encoding.UTF8.GetString(Depassword);
            Acpassword = Acpassword.Substring(0, Acpassword.Length - sk.Length);
            return Acpassword; 
        }
    }
}
