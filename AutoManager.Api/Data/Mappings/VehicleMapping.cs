using AutoManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoManager.Api.Data.Mappings;

public class VehicleMapping : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicles");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Plate)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(7);

        builder.Property(v => v.Type)
            .HasColumnType("SMALLINT")
            .IsRequired(true);

        builder.Property(v => v.Brand)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(v => v.Model)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(v => v.Year)
            .IsRequired(false)
            .HasColumnType("INT");

        builder.Property(v => v.Mileage)
            .IsRequired(false)
            .HasColumnType("INT");

        builder.Property(v => v.Image)
            .IsRequired(false)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);

        builder.Property(v => v.LastMaintenanceDate)
            .IsRequired(false)
            .HasColumnType("DATE");

        builder.Property(v => v.State)
            .IsRequired(true)
            .HasColumnType("INT");

        builder.Property(v => v.CreatedAt)
            .IsRequired(true);
    }
}
