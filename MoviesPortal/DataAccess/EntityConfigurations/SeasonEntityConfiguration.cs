using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.EntityConfigurations
{
    internal class SeasonEntityConfiguration : IEntityTypeConfiguration<SeasonModel>
    {
        public void Configure(EntityTypeBuilder<SeasonModel> builder)
        {            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.HasMany(x => x.Episodes).WithOne(x => x.Season);
        }
    }
}
