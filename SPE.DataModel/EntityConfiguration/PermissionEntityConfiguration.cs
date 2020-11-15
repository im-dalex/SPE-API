using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPE.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPE.DataModel.EntityConfiguration
{
    public class PermissionEntityConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");

            builder.Property(p => p.Id)
                .HasColumnName("PermissionId");

            builder.Property(p => p.EmployeeName)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(80);

            builder.Property(p => p.EmployeeLastName)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(80);

            builder.Property(p => p.PermissionDate)
                .IsRequired()
                .HasColumnType("date")
                .HasDefaultValueSql("getdate()");

            builder.HasOne(p => p.PermissionType)
                .WithMany(p => p.Permission)
                .HasForeignKey(p => p.PermissionTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Fk_Permission_PermissionType")
                .IsRequired();
        }
    }
}
