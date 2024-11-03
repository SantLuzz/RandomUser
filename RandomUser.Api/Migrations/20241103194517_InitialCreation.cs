using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RandomUser.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "VARCHAR(160)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(160)", nullable: false),
                    Gender = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    Nationality = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Address = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Phone = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Mobile = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
