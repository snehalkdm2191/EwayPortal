using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentMaster",
                columns: table => new
                {
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentHeader = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentMaster", x => x.ContentId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeGroup",
                columns: table => new
                {
                    EmployeeGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeGroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeGroup", x => x.EmployeeGroupId);
                });

            migrationBuilder.CreateTable(
                name: "ContentGroup",
                columns: table => new
                {
                    ContentGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentGroup", x => x.ContentGroupId);
                    table.ForeignKey(
                        name: "FK_ContentGroup_ContentMaster",
                        column: x => x.ContentId,
                        principalTable: "ContentMaster",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContentGroup_EmployeeGroup",
                        column: x => x.EmployeeGroupId,
                        principalTable: "EmployeeGroup",
                        principalColumn: "EmployeeGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeGroup",
                        column: x => x.EmployeeGroupId,
                        principalTable: "EmployeeGroup",
                        principalColumn: "EmployeeGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContent",
                columns: table => new
                {
                    EmployeeContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeIId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContentGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContent", x => x.EmployeeContentId);
                    table.ForeignKey(
                        name: "FK_EmployeeContent_ContentGroup",
                        column: x => x.ContentGroupId,
                        principalTable: "ContentGroup",
                        principalColumn: "ContentGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeContent_Employee",
                        column: x => x.EmployeeIId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ContentMaster",
                columns: new[] { "ContentId", "ContentHeader" },
                values: new object[,]
                {
                    { new Guid("dca67cf1-7a94-47bd-befc-5aced6af5a6f"), "welcome to organization" },
                    { new Guid("9cd0405e-e1ea-40a1-8224-4ed8483a19e1"), "Team meet up" },
                    { new Guid("560136f2-f40f-4f3e-a3b5-b443aaeb7035"), "Hardware software Access information" },
                    { new Guid("e20b1eac-f4af-4821-ac70-ed675421bd80"), "On-boarding training" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeGroup",
                columns: new[] { "EmployeeGroupId", "EmployeeGroupName" },
                values: new object[,]
                {
                    { new Guid("26b53c0e-f5c1-493a-b018-126f9ed18987"), "Sales" },
                    { new Guid("4cbc3cd7-c619-4090-99b0-e91a689f886b"), "Marketing" },
                    { new Guid("23ffa6db-9a01-4290-a3e3-26a521826983"), "IT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentGroup_ContentId",
                table: "ContentGroup",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentGroup_EmployeeGroupId",
                table: "ContentGroup",
                column: "EmployeeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeGroupId",
                table: "Employee",
                column: "EmployeeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContent_ContentGroupId",
                table: "EmployeeContent",
                column: "ContentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContent_EmployeeIId",
                table: "EmployeeContent",
                column: "EmployeeIId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeContent");

            migrationBuilder.DropTable(
                name: "ContentGroup");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "ContentMaster");

            migrationBuilder.DropTable(
                name: "EmployeeGroup");
        }
    }
}
