using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class fırst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Surname = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Username = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Surname = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Username = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Writer = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Picture = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MembersID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Book_Members_MembersID",
                        column: x => x.MembersID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "ID", "Name", "Password", "Surname", "Username" },
                values: new object[] { 1, "Öner", "202cb962ac59075b964b07152d234b70", "Dağcı", "oner" });

            migrationBuilder.CreateIndex(
                name: "IX_Book_MembersID",
                table: "Book",
                column: "MembersID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
