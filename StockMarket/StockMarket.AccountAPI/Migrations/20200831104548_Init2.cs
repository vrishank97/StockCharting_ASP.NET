using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockMarket.AccountAPI.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IPODetails",
                columns: table => new
                {
                    IPOId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(maxLength: 15, nullable: false),
                    StockExchange = table.Column<string>(maxLength: 15, nullable: false),
                    SharePrice = table.Column<double>(nullable: false),
                    Shares = table.Column<long>(nullable: false),
                    Datetime = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPODetails", x => x.IPOId);
                    table.ForeignKey(
                        name: "FK_IPODetails_Company_CompanyCode",
                        column: x => x.CompanyCode,
                        principalTable: "Company",
                        principalColumn: "CompanyCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IPODetails_CompanyCode",
                table: "IPODetails",
                column: "CompanyCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPODetails");
        }
    }
}
