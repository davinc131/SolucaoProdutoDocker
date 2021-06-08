using Microsoft.EntityFrameworkCore.Migrations;

namespace APIProduto.Migrations
{
    public partial class AlterarDoubleParaDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Produto",
                type: "decimal(7,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double(18, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "Produto",
                type: "double(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)");
        }
    }
}
