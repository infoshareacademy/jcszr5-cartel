using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class SubcriptionConfiguration : IEntityTypeConfiguration<SubscriptionModel>

    {
        public void Configure(EntityTypeBuilder<SubscriptionModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(20);
            builder.Property(x => x.Email).HasMaxLength(100);
        }
    }
}
