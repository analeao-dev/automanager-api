using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plate = table.Column<string>(type: "NVARCHAR(7)", maxLength: 7, nullable: false),
                    Type = table.Column<short>(type: "SMALLINT", nullable: false),
                    Brand = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Year = table.Column<int>(type: "INT", nullable: true),
                    Mileage = table.Column<int>(type: "INT", nullable: true),
                    Image = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    LastMaintenanceDate = table.Column<DateOnly>(type: "DATE", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
