using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace instagram.Models
{
    public class InstContext : IdentityDbContext<User>
    {
        public DbSet<Post> Posts { get; set; }
        public InstContext(DbContextOptions<InstContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
