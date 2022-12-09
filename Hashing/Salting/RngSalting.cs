using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Security.Salting
{
    public class RngSalting : ISaltProvider
    {
        public string GetSalt(int length)
        {
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            var buffer = new byte[length];
            randomNumberGenerator.GetBytes(buffer);

            var salt = Convert.ToBase64String(buffer);
            return salt;
        }
    }
}
