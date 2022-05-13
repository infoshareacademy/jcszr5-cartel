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
    internal class CreativePersonEntityConfiguration : IEntityTypeConfiguration<CreativePersonModel>
    {
        public void Configure(EntityTypeBuilder<CreativePersonModel> builder)
        {
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(p => p.DateOfBirth).HasColumnType("date").IsRequired(false);
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(20).IsRequired();
            builder.Property(p => p.SurName).HasColumnName("Surname").HasMaxLength(20).IsRequired();

            builder.HasData(ActorSampleData.sampleActors/*, ActorSampleData.sampleDirector*/);
        }
    }
}
