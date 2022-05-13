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
    internal class RoleEntityConfiguration : IEntityTypeConfiguration<RoleModel>
    {
        public void Configure(EntityTypeBuilder<RoleModel> builder)
        {
            
            builder.HasData(
                new RoleModel
                {
                    RoleId = 1,
                    RoleName = "Actor"
                },
                new RoleModel
                {
                    RoleId = 2,
                    RoleName = "Director"
                });
        }
    }
}
