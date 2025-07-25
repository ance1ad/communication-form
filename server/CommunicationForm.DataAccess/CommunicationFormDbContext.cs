using CommunicationForm.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationForm.DataAccess
{
    // Контекст бд
    public class CommunicationFormDbContext : DbContext
    {
        public CommunicationFormDbContext(DbContextOptions<CommunicationFormDbContext> options)
            : base(options)
        {

        }

        public DbSet<ThemeEntity> Themes { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactEntity>().ToTable("Contacts");
            modelBuilder.Entity<MessageEntity>().ToTable("Messages");
            modelBuilder.Entity<ThemeEntity>().ToTable("Themes");
        }
    }
}
