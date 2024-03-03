using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiquorStoreFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class mig_imagename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MultiplePhotos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MultiplePhotos");
        }
    }
}
