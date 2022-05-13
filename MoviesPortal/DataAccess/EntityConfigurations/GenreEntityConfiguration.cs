using DataAccess.Models;
using DataAccess.Repositories.SampleData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    internal class GenreEntityConfiguration : IEntityTypeConfiguration<GenreModel>
    {
        public void Configure(EntityTypeBuilder<GenreModel> builder)
        {
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Genre).HasMaxLength(20);

            builder.HasData(GenreSampleData.sampleGenres);
        }
    }
}
