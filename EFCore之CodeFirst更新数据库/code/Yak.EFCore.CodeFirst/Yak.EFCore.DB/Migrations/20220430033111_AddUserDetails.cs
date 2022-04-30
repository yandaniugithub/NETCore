using Microsoft.EntityFrameworkCore.Migrations;

namespace Yak.EFCore.DB.Migrations
{
    public partial class AddUserDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "C_Mobile",
                table: "Sys_User",
                newName: "Mobile");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sys_User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Sys_User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "123456");

            migrationBuilder.CreateTable(
                name: "Sys_UserInfoDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_UserInfoDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sys_UserInfoDetails_Sys_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Sys_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sys_UserInfoDetails_UserId",
                table: "Sys_UserInfoDetails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sys_UserInfoDetails");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Sys_User");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "Sys_User",
                newName: "C_Mobile");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sys_User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
