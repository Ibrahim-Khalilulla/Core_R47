using Core_R47.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core_R47.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<students> students { get; set; }
        public DbSet<results> results { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
