using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core_R47.Models;

namespace Core_R47.Data
{
    public class DBContextContext : DbContext
    {
        public DBContextContext (DbContextOptions<DBContextContext> g)
            : base(g)
        {
        }

        public DbSet<Core_R47.Models.teachers> teachers { get; set; }


        public DbSet<dept2> dept2 { get; set; }
        public DbSet<items2> items2 { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<items2>()
        //        .HasOne(q => q.deptid);
        
        //}
    }
}
