using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSystem.Models;

namespace WebSystem.Infra
{
    public class AppDbContext : IdentityDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){ }
        public AppDbContext() { }

        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Status> status { get; set; }
        public DbSet<Priority> priority { get; set; }
    }
}
