using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TCPproject.Models
{
    public class TCPprojectContext : DbContext
    {
        public TCPprojectContext(DbContextOptions<TCPprojectContext> options)
            : base(options)
        {

        }

        public DbSet<TCPproject.Models.User> User { get; set; }
    }
}