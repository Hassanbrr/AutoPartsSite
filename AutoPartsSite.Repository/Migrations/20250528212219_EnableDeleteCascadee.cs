using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsSite.Repository.Migrations
{
    /// <inheritdoc />
    public partial class EnableDeleteCascadee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogCategories_BlogCategories_ParentCategoryId",
                table: "BlogCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogCategories_BlogCategories_ParentCategoryId",
                table: "BlogCategories",
                column: "ParentCategoryId",
                principalTable: "BlogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogCategories_BlogCategories_ParentCategoryId",
                table: "BlogCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogCategories_BlogCategories_ParentCategoryId",
                table: "BlogCategories",
                column: "ParentCategoryId",
                principalTable: "BlogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
