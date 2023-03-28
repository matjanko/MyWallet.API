using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyWallet.Debts.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "debts");

            migrationBuilder.CreateTable(
                name: "lenders",
                schema: "debts",
                columns: table => new
                {
                    lender_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lenders", x => x.lender_id);
                });

            migrationBuilder.CreateTable(
                name: "loans",
                schema: "debts",
                columns: table => new
                {
                    loan_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lender_id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    principal = table.Column<decimal>(type: "numeric", nullable: false),
                    interest_rate = table.Column<decimal>(type: "numeric", nullable: false),
                    loan_term_months = table.Column<int>(type: "integer", nullable: false),
                    loan_status = table.Column<string>(type: "text", nullable: false, defaultValue: "Draft")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.loan_id);
                    table.ForeignKey(
                        name: "FK_loans_lenders_lender_id",
                        column: x => x.lender_id,
                        principalSchema: "debts",
                        principalTable: "lenders",
                        principalColumn: "lender_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_loans_lender_id",
                schema: "debts",
                table: "loans",
                column: "lender_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loans",
                schema: "debts");

            migrationBuilder.DropTable(
                name: "lenders",
                schema: "debts");
        }
    }
}
