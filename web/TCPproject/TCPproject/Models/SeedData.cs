using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TCPproject.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TCPprojectContext(serviceProvider.GetRequiredService<DbContextOptions<TCPprojectContext>>()))
            {
                if (context.User.Any())
                {
                    return;
                }

                context.User.AddRange(
                    new User
                    {
                        Nickname = "Debchik228",
                        Highscore = 9999
                    },

                    new User
                    {
                        Nickname = "Dodik", 
                        Highscore = 228
                    },

                    new User
                    {
                        Nickname = "Debick",
                        Highscore = 1488
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
