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
    internal class CommentEntityConfiguration : IEntityTypeConfiguration<CommentModel>
    {
        public void Configure(EntityTypeBuilder<CommentModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(u => u.ApplicationUser).WithMany(c => c.Comments).HasForeignKey(fk => fk.UserId).IsRequired();
            builder.Property(p => p.MovieId).IsRequired();
            builder.Property(p => p.PublishedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.CommentContent).HasMaxLength(1000).IsRequired();
        }
    }
}
