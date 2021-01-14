using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace TCP.ViewModels
{

    
    public class LoginModel
    {
        public string Saltingpass(string mail = null, string pass = null)
        {
            string passw = pass;

            byte[] salt = Encoding.ASCII.GetBytes(mail);
            //Random rng = new Random(mail.GetHashCode());
            //rng.NextBytes(salt);
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: passw,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            passw = $"{hashed}";
            return passw;
        }
        private string email;
        private string password;

        [Required(ErrorMessage = "Не указан Email")]
        public string Email 
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password 
        { 
            get
            {
                return password;
            }
            set
            {

                password =  Saltingpass(email,value);  
                
            }
        }
    }
}
