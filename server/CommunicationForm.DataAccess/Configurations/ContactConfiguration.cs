using CommunicationForm.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationForm.DataAccess.Configurations
{
    internal class ContactConfiguration : IEntityTypeConfiguration<ContactEntity>
    {
        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Name)
                .IsRequired();
            builder.Property(b => b.Email)
                .IsRequired();
            builder.Property(b => b.Phone)
                .HasMaxLength(11)
                .IsRequired();
        }
    }
}
