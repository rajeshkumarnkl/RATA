using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RATA.Shared.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenantMaintenanceSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenantID = table.Column<int>(type: "INTEGER", nullable: false),
                    Month = table.Column<string>(type: "TEXT", nullable: false),
                    WaterBill = table.Column<decimal>(type: "TEXT", nullable: false),
                    Maintenance = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMaintenanceSet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TenantSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenantName = table.Column<string>(type: "TEXT", nullable: false),
                    MobileNumber = table.Column<string>(type: "TEXT", nullable: false),
                    RentedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Advance = table.Column<decimal>(type: "TEXT", nullable: false),
                    PermanentAddress = table.Column<string>(type: "TEXT", nullable: false),
                    SiteNumber = table.Column<string>(type: "TEXT", nullable: false),
                    FlatNumber = table.Column<string>(type: "TEXT", nullable: false),
                    VacatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Rent = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSet", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantMaintenanceSet");

            migrationBuilder.DropTable(
                name: "TenantSet");
        }
    }
}
