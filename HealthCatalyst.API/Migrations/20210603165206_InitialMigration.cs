using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCatalyst.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "People",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interest",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Person_Id = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interest_People_Person_Id",
                        column: x => x.Person_Id,
                        principalSchema: "dbo",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "People",
                columns: new[] { "Id", "Address", "Age", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "127 Elm Street", 9, "Jack", "Cat" },
                    { 2, "124 Rocky Brook Road", 8, "Jamie", "Prugh" },
                    { 3, "8 Elm Court", 32, "Marie", "Collins" },
                    { 4, "5 Elm Court", 87, "Geoff", "Jack" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Interest",
                columns: new[] { "Id", "Person_Id", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Sleeping" },
                    { 2, 2, "Eating" },
                    { 3, 2, "Running" },
                    { 4, 2, "Playing" },
                    { 5, 3, "KPop" },
                    { 6, 3, "Reading" },
                    { 7, 4, "Reading" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interest_Person_Id",
                schema: "dbo",
                table: "Interest",
                column: "Person_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interest",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "People",
                schema: "dbo");
        }
    }
}
