using Microsoft.EntityFrameworkCore;
using MVC_Personel.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Personel_Mvc.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-6MJ53BNG\\SQLEXPRESS; database=MVC_Personel; integrated security=true");
        }
        public DbSet<Birim> Birims { get; set; }
        public DbSet<PersonelBilgi> PersonelBilgis { get; set; }
        public DbSet<Admin> Admins {  get; set; }

    }

    
    
}
