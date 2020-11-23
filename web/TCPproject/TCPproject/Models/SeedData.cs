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
                context.SaveChanges();
            }
        }
    }
}
