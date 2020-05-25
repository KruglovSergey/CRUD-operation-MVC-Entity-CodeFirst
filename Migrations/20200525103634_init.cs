using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeledocTask.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    INN = table.Column<long>(nullable: false),
                    CrDate = table.Column<DateTime>(nullable: false),
                    ChDate = table.Column<DateTime>(nullable: false),
                    EntType = table.Column<int>(nullable: false),
                    ParentEntityID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_ParentEntityID",
                        column: x => x.ParentEntityID,
                        principalTable: "Entity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entity_ParentEntityID",
                table: "Entity",
                column: "ParentEntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
