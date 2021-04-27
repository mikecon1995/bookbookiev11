using Microsoft.EntityFrameworkCore.Migrations;

namespace bookbookiev11.Data.Migrations
{
    public partial class cartadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFeatured",
                table: "BookModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isNewRelease",
                table: "BookModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "cartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookId = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_cartItems_BookModel_bookId",
                        column: x => x.bookId,
                        principalTable: "BookModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_bookId",
                table: "cartItems",
                column: "bookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartItems");

            migrationBuilder.DropColumn(
                name: "isFeatured",
                table: "BookModel");

            migrationBuilder.DropColumn(
                name: "isNewRelease",
                table: "BookModel");
        }
    }
}
