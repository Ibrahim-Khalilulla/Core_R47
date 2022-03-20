using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core_R47.Migrations
{
    public partial class ss3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dept2",
                columns: table => new
                {
                    deptid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    deptname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dept2", x => x.deptid);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstMidName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "items2",
                columns: table => new
                {
                    itemcode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    itemname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deptid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    cost = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    rate = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items2", x => x.itemcode);
                    table.ForeignKey(
                        name: "FK_items2_dept2_deptid",
                        column: x => x.deptid,
                        principalTable: "dept2",
                        principalColumn: "deptid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_items2_deptid",
                table: "items2",
                column: "deptid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items2");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "dept2");
        }
    }
}
