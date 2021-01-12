using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace MyFuncs
{
    public class SaltyClass
    {
        public static string saltingpass(string name = null, string mail = null, string pass = null)
        {
            string password;
            if (pass == null) 
            { 
                password = name; 
            }
            else {
                password = pass; 
            };

            byte[] salt = Encoding.ASCII.GetBytes(mail);
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pass,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            password = $"{hashed}";
            return password;
        }
    }
}
