using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountsService.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSalts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSalts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    TypeName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.TypeName);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserTypeFK = table.Column<string>(name: "UserType_FK", type: "nvarchar(450)", nullable: false),
                    UserSaltIDFK = table.Column<int>(name: "UserSaltID_FK", type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Contactno = table.Column<string>(name: "Contact_no", type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Confirmedpassword = table.Column<string>(name: "Confirmed_password", type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(name: "Birth_date", type: "datetime2", nullable: false),
                    Createddate = table.Column<DateTime>(name: "Created_date", type: "datetime2", nullable: false),
                    Updateddate = table.Column<DateTime>(name: "Updated_date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserSalts_UserSaltID_FK",
                        column: x => x.UserSaltIDFK,
                        principalTable: "UserSalts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserType_FK",
                        column: x => x.UserTypeFK,
                        principalTable: "UserTypes",
                        principalColumn: "TypeName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserSaltID_FK",
                table: "Users",
                column: "UserSaltID_FK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserType_FK",
                table: "Users",
                column: "UserType_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserSalts");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
