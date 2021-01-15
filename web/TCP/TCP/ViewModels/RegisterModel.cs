using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TCP.ViewModels
{
    public class RegisterModel
    {
        string email;
        string password;
        string name;
        public string Saltingpass(string name = null, string mail = null, string pass = null)
        {
            string passw;
            if (pass == null)
            {
                passw = name;
            }
            else
            {
                passw = pass;
            };

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

        [Required(ErrorMessage = "Не указан никнэйм")]
        public string Nickname
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

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

                password = Saltingpass(email, value);

            }
        }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword
        {
            get
            {
                return password;
            }
            set
            {

                password = Saltingpass(email, value);

            }
        }
    }
}
