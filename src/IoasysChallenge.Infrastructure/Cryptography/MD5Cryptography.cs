﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace IoasysChallenge.Infrastructure.Cryptography
{
    public static class MD5Cryptography
    {
        public static string Md5Hash(string senha)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(senha);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
