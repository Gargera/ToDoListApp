using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DropUniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_Title",
                table: "ToDoItems");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_Title",
                table: "ToDoItems",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);
        }
    }
}
