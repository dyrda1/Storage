using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddedAdminAndManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3dc055a7-1ab9-4282-8c60-c7577ac97b55"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("69be34fe-b5d4-467e-9c4c-69d52b239026"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("69be34fe-b5d4-467e-9c4c-69d52b239026"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3dc055a7-1ab9-4282-8c60-c7577ac97b55"));
        }
    }
}
