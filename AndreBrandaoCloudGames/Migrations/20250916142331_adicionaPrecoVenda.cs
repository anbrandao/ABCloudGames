using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreBrandaoCloudGamesApi.Migrations
{
    /// <inheritdoc />
    public partial class adicionaPrecoVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecoVenda",
                table: "Jogo",
                type: "DECIMAL(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoVenda",
                table: "Jogo");
        }
    }
}
