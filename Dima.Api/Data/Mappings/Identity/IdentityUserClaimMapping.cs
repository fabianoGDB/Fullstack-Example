using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings
{
    public class IdentityUserClaimMapping : IEntityTypeConfiguration<IdentityUserClaim<long>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<long>> builder)
        {

            builder.ToTable("IdentityRoleClaim");
            builder.HasKey(rc => rc.Id);
            builder.Property(u => u.ClaimType).HasMaxLength(255);
            builder.Property(u => u.ClaimValue).HasMaxLength(255);
        }
    }
}