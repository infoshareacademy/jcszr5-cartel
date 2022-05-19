using DataAccess.Models.EntityAssigments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    internal class TvSeries_CreativeP_RoleEntityConfiguration : IEntityTypeConfiguration<TvSeries_CreativeP_Role>
    {
        public void Configure(EntityTypeBuilder<TvSeries_CreativeP_Role> builder)
        {
            builder.HasKey(k => new { k.TvSeriesId, k.CreativePersonId, k.RoleId });
            builder.HasOne(i => i.TvSeries).WithMany(i => i.TvSeries_CreativeP_Role).HasForeignKey(i => i.TvSeriesId).IsRequired();
            builder.HasOne(i => i.CreativePerson).WithMany(i => i.TvSeries_CreativeP_Role).HasForeignKey(i => i.CreativePersonId).IsRequired();
            builder.HasOne(i => i.Role).WithMany(i => i.TvSeries_CreativeP_Role).HasForeignKey(i => i.RoleId).IsRequired();
        }
    }
}
