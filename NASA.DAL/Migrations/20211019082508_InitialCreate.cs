using Microsoft.EntityFrameworkCore.Migrations;

namespace NASA.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    varchar50 = table.Column<string>(name: "varchar(50", type: "nvarchar(max)", nullable: false),
                    varchar200 = table.Column<string>(name: "varchar(200", type: "nvarchar(max)", nullable: false),
                    varchar100 = table.Column<string>(name: "varchar(100", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
