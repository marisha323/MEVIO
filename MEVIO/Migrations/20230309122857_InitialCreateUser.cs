using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEVIO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathImgAVA",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathImgAVA",
                table: "Users");
        }
    }
}
