using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibMan.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExpectedReturnDatetoReturnDatechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpectedReturnDate",
                table: "BookRentals",
                newName: "ReturnDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "BookRentals",
                newName: "ExpectedReturnDate");
        }
    }
}
