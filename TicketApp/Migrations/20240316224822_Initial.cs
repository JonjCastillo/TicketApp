using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    PriorityID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PriorityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.PriorityID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    issueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticketTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticketDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticketName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticketEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    submitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriorityID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.issueID);
                    table.ForeignKey(
                        name: "FK_Issues_Priorities_PriorityID",
                        column: x => x.PriorityID,
                        principalTable: "Priorities",
                        principalColumn: "PriorityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issues_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "PriorityID", "PriorityName" },
                values: new object[,]
                {
                    { "1", "Low" },
                    { "2", "Medium" },
                    { "3", "High" },
                    { "4", "Critical" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusID", "StatusName" },
                values: new object[,]
                {
                    { "1", "Open" },
                    { "2", "In Progress" },
                    { "3", "Closed" },
                    { "4", "Resolved" }
                });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "issueID", "PriorityID", "StatusID", "submitDate", "ticketDescription", "ticketEmail", "ticketName", "ticketTitle" },
                values: new object[] { 1, "3", "1", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "I can't log in to my account", "johndoe@mail.com", "John Doe", "Can't log in" });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "issueID", "PriorityID", "StatusID", "submitDate", "ticketDescription", "ticketEmail", "ticketName", "ticketTitle" },
                values: new object[] { 2, "2", "2", new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "I can't access my email", "janedoe@mail.com", "Jane Doe", "Can't access my email" });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "issueID", "PriorityID", "StatusID", "submitDate", "ticketDescription", "ticketEmail", "ticketName", "ticketTitle" },
                values: new object[] { 3, "3", "3", new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "I need to reset my password", "manmichael@mail.com", "Michael Man", "Password Reset" });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_PriorityID",
                table: "Issues",
                column: "PriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_StatusID",
                table: "Issues",
                column: "StatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
