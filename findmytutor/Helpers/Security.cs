using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace findmytutor.Helpers
{
    public static class Security
    {
        public static string GenerateHashPassword(string nakedPassword)
        {
            string hashedPassword = string.Empty;
            if(!string.IsNullOrEmpty(nakedPassword))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                StringBuilder EncPassword = new StringBuilder();
                md5.ComputeHash(Encoding.UTF8.GetBytes(nakedPassword));
                byte[] resultHash = md5.Hash;
                for (int i = 0; i<resultHash.Length; i++)
                {
                    EncPassword.Append(resultHash[i].ToString("x2"));
                }
                hashedPassword=EncPassword.ToString();
            }

            return hashedPassword;
        }
    }
}