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
                byte[] salt = Encoding.ASCII.GetBytes(email);
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                password = value;
            }
        }
    }
}
