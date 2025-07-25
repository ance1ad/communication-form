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
    internal class MessageConfiguration : IEntityTypeConfiguration<MessageEntity>
    {
        public void Configure(EntityTypeBuilder<MessageEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Text).IsRequired();
            builder.Property(b => b.Contact).IsRequired();
            builder.Property(b => b.Theme).IsRequired();
        }
    }
}
