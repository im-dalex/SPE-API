using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPE.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPE.DataModel.EntityConfiguration
{
    public class PermissionTypeEntityConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.ToTable("PermissionType");

            builder.Property(p => p.Id)
                .HasColumnName("PermissionTypeId");

            builder.Property(p => p.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .IsRequired();

            builder.HasData(new PermissionType[] {
                new PermissionType { Id = 1, Description = "Enfermedad" },
                new PermissionType { Id = 2, Description = "Diligencias" },
                new PermissionType { Id = 3, Description = "Otros" }
            });
        }
    }
}
