using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DiplomApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessagesDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StringToSort = table.Column<string>(type: "text", nullable: false),
                    SortedByStudent = table.Column<string>(type: "text", nullable: false),
                    SortedProgram = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesDB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersDB",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FIO = table.Column<string>(type: "text", nullable: false),
                    Group = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDB", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "RatingsDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BubleMark = table.Column<bool>(type: "boolean", nullable: false),
                    SelectionMark = table.Column<bool>(type: "boolean", nullable: false),
                    InsertionMark = table.Column<bool>(type: "boolean", nullable: false),
                    ShakerMark = table.Column<bool>(type: "boolean", nullable: false),
                    ShellMark = table.Column<bool>(type: "boolean", nullable: false),
                    QuickMark = table.Column<bool>(type: "boolean", nullable: false),
                    TotalAttempts = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingsDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatingsDB_UsersDB_IdUser",
                        column: x => x.IdUser,
                        principalTable: "UsersDB",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RatingsDB_IdUser",
                table: "RatingsDB",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessagesDB");

            migrationBuilder.DropTable(
                name: "RatingsDB");

            migrationBuilder.DropTable(
                name: "UsersDB");
        }
    }
}
