using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WholesBrew.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENCODER",
                columns: table => new
                {
                    ENCODERID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENCODER = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ENABLED = table.Column<bool>(type: "bit", nullable: true),
                    LASTNAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PHONE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EMAILADDRESS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UCODE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CREATEUSERSALLOW = table.Column<bool>(type: "bit", maxLength: 1, nullable: true),
                    ACTIVEDIRECTORYLOGIN = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENCODER", x => x.ENCODERID);
                });

            migrationBuilder.CreateTable(
                name: "WB_BREWER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATOR_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFICATOR_ID = table.Column<long>(type: "bigint", nullable: false),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ROW_VERSION = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WB_BREWER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WB_WHOLESALER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATOR_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFICATOR_ID = table.Column<long>(type: "bigint", nullable: false),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ROW_VERSION = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WB_WHOLESALER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WB_BEER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BREWER_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ALCOHOL_CONTENT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    CREATOR_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFICATOR_ID = table.Column<long>(type: "bigint", nullable: false),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ROW_VERSION = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WB_BEER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WB_BEER_WB_BREWER_BREWER_ID",
                        column: x => x.BREWER_ID,
                        principalTable: "WB_BREWER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WB_RESTRICTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WHOLESALER_ID = table.Column<int>(type: "int", nullable: false),
                    BEER_ID = table.Column<int>(type: "int", nullable: false),
                    MAX_QUANTITY = table.Column<int>(type: "int", nullable: false),
                    CREATOR_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFICATOR_ID = table.Column<long>(type: "bigint", nullable: false),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ROW_VERSION = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WB_RESTRICTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WB_RESTRICTION_WB_BEER_BEER_ID",
                        column: x => x.BEER_ID,
                        principalTable: "WB_BEER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WB_RESTRICTION_WB_WHOLESALER_WHOLESALER_ID",
                        column: x => x.WHOLESALER_ID,
                        principalTable: "WB_WHOLESALER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WB_SALE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WHOLESALER_ID = table.Column<int>(type: "int", nullable: false),
                    BEER_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    CREATOR_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFICATOR_ID = table.Column<long>(type: "bigint", nullable: false),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ROW_VERSION = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WB_SALE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WB_SALE_WB_BEER_BEER_ID",
                        column: x => x.BEER_ID,
                        principalTable: "WB_BEER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WB_SALE_WB_WHOLESALER_WHOLESALER_ID",
                        column: x => x.WHOLESALER_ID,
                        principalTable: "WB_WHOLESALER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WB_WHOLESALER_STOCK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WHOLESALER_ID = table.Column<int>(type: "int", nullable: false),
                    BEER_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CREATOR_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MODIFICATOR_ID = table.Column<long>(type: "bigint", nullable: false),
                    MODIFICATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ROW_VERSION = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WB_WHOLESALER_STOCK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WB_WHOLESALER_STOCK_WB_BEER_BEER_ID",
                        column: x => x.BEER_ID,
                        principalTable: "WB_BEER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WB_WHOLESALER_STOCK_WB_WHOLESALER_WHOLESALER_ID",
                        column: x => x.WHOLESALER_ID,
                        principalTable: "WB_WHOLESALER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WB_BEER_BREWER_ID",
                table: "WB_BEER",
                column: "BREWER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WB_RESTRICTION_BEER_ID",
                table: "WB_RESTRICTION",
                column: "BEER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WB_RESTRICTION_WHOLESALER_ID",
                table: "WB_RESTRICTION",
                column: "WHOLESALER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WB_SALE_BEER_ID",
                table: "WB_SALE",
                column: "BEER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WB_SALE_WHOLESALER_ID",
                table: "WB_SALE",
                column: "WHOLESALER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WB_WHOLESALER_STOCK_BEER_ID",
                table: "WB_WHOLESALER_STOCK",
                column: "BEER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WB_WHOLESALER_STOCK_WHOLESALER_ID",
                table: "WB_WHOLESALER_STOCK",
                column: "WHOLESALER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENCODER");

            migrationBuilder.DropTable(
                name: "WB_RESTRICTION");

            migrationBuilder.DropTable(
                name: "WB_SALE");

            migrationBuilder.DropTable(
                name: "WB_WHOLESALER_STOCK");

            migrationBuilder.DropTable(
                name: "WB_BEER");

            migrationBuilder.DropTable(
                name: "WB_WHOLESALER");

            migrationBuilder.DropTable(
                name: "WB_BREWER");
        }
    }
}
