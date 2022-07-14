using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sacramentplanner.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bishopric",
                columns: table => new
                {
                    BishopricId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BishopName = table.Column<string>(type: "TEXT", nullable: false),
                    FirstCounselorName = table.Column<string>(type: "TEXT", nullable: false),
                    SecondCounselorName = table.Column<string>(type: "TEXT", nullable: false),
                    IsValid = table.Column<bool>(type: "INTEGER", nullable: true),
                    ServiceDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bishopric", x => x.BishopricId);
                });

            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    HymnId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HymnName = table.Column<string>(type: "TEXT", nullable: false),
                    HymnNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.HymnId);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "SacramentPlan",
                columns: table => new
                {
                    SacramentPlanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SacramentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Presiding = table.Column<string>(type: "TEXT", nullable: false),
                    Conducting = table.Column<string>(type: "TEXT", nullable: false),
                    OpeningHymnName = table.Column<string>(type: "TEXT", nullable: false),
                    OpeningHymnNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Invocation = table.Column<string>(type: "TEXT", nullable: false),
                    SacramentHymnName = table.Column<string>(type: "TEXT", nullable: false),
                    SacramentHymnNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFastSunday = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClosingHymnName = table.Column<string>(type: "TEXT", nullable: false),
                    ClosingHymnNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Benediction = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SacramentPlan", x => x.SacramentPlanId);
                });

            migrationBuilder.CreateTable(
                name: "Talk",
                columns: table => new
                {
                    TalkId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SacramentPlanId = table.Column<int>(type: "INTEGER", nullable: true),
                    Speaker = table.Column<string>(type: "TEXT", nullable: false),
                    Topic = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talk", x => x.TalkId);
                    table.ForeignKey(
                        name: "FK_Talk_SacramentPlan_SacramentPlanId",
                        column: x => x.SacramentPlanId,
                        principalTable: "SacramentPlan",
                        principalColumn: "SacramentPlanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Talk_SacramentPlanId",
                table: "Talk",
                column: "SacramentPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bishopric");

            migrationBuilder.DropTable(
                name: "Hymn");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Talk");

            migrationBuilder.DropTable(
                name: "SacramentPlan");
        }
    }
}
