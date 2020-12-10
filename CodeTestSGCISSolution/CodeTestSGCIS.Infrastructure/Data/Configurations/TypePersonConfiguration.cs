using CodeTestSGCIS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTestSGCIS.Infrastructure.Data.Configurations
{
    public class TypePersonConfiguration : IEntityTypeConfiguration<TypePerson>
    {
        public void Configure(EntityTypeBuilder<TypePerson> builder)
        {
            builder.ToTable("TypePerson");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("IdTypePerson")
                .ValueGeneratedNever();

            builder.Property(e => e.TypePersonDescription)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
        }
    }
}
