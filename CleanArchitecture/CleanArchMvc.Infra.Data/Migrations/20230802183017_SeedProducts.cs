using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Product(Name, Description, Price, Stock, Image, CategoryId)" +
                "VALUES('Caderno espiral', 'Caderno espiral de 100m folhas', 7.45, 50, 'caderno1.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Product(Name, Description, Price, Stock, Image, CategoryId)" +
               "VALUES('Estojo escolar', 'Estojo escolar cinza', 5.65, 40, 'estojo.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Product(Name, Description, Price, Stock, Image, CategoryId)" +
               "VALUES('Borracha escolar', 'borracha escolar colorida', 2.65, 100, 'borracha.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Product(Name, Description, Price, Stock, Image, CategoryId)" +
               "VALUES('Calculadora ecolar', 'Calculadora simples', 1.65, 200, 'calculadora.jpg', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Product");
        }
    }
}
