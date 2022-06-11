using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace relationshipAPI.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skillls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skillls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharecterSkills",
                columns: table => new
                {
                    CharectersId = table.Column<int>(type: "int", nullable: false),
                    SkillssId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharecterSkills", x => new { x.CharectersId, x.SkillssId });
                    table.ForeignKey(
                        name: "FK_CharecterSkills_Charecters_CharectersId",
                        column: x => x.CharectersId,
                        principalTable: "Charecters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharecterSkills_Skillls_SkillssId",
                        column: x => x.SkillssId,
                        principalTable: "Skillls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharecterSkills_SkillssId",
                table: "CharecterSkills",
                column: "SkillssId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharecterSkills");

            migrationBuilder.DropTable(
                name: "Skillls");
        }
    }
}
