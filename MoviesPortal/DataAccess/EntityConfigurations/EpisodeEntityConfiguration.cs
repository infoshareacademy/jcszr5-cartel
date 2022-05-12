using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    internal class EpisodeEntityConfiguration : IEntityTypeConfiguration<EpisodeModel>
    {
        public void Configure(EntityTypeBuilder<EpisodeModel> builder)
        {            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(50);
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(1000);
        }
    }
}
