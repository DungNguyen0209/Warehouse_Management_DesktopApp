using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.SqliteDB.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "containerLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    shelfId = table.Column<string>(type: "TEXT", nullable: false),
                    rowId = table.Column<int>(type: "INTEGER", nullable: false),
                    cellId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_containerLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "processingGoodExportOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    orderId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processingGoodExportOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdProduct = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "formulaListGoodIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<string>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    PlannedMass = table.Column<string>(type: "TEXT", nullable: false),
                    PlannedQuantity = table.Column<string>(type: "TEXT", nullable: false),
                    Actual = table.Column<string>(type: "TEXT", nullable: true),
                    ProcessingGoodExportOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formulaListGoodIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_formulaListGoodIssues_processingGoodExportOrders_ProcessingGoodExportOrderId",
                        column: x => x.ProcessingGoodExportOrderId,
                        principalTable: "processingGoodExportOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "issueBaskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BasketId = table.Column<string>(type: "TEXT", nullable: false),
                    ProductionDate = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<string>(type: "TEXT", nullable: false),
                    Mass = table.Column<string>(type: "TEXT", nullable: false),
                    Actual = table.Column<string>(type: "TEXT", nullable: true),
                    IsChecked = table.Column<bool>(type: "INTEGER", nullable: true),
                    FormulaListGoodIssueId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issueBaskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_issueBaskets_formulaListGoodIssues_FormulaListGoodIssueId",
                        column: x => x.FormulaListGoodIssueId,
                        principalTable: "formulaListGoodIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_formulaListGoodIssues_ProcessingGoodExportOrderId",
                table: "formulaListGoodIssues",
                column: "ProcessingGoodExportOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_issueBaskets_FormulaListGoodIssueId",
                table: "issueBaskets",
                column: "FormulaListGoodIssueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "containerLocations");

            migrationBuilder.DropTable(
                name: "issueBaskets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "formulaListGoodIssues");

            migrationBuilder.DropTable(
                name: "processingGoodExportOrders");
        }
    }
}
