using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Restaurant.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true),
                    Joined = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "Menu1s",
                columns: table => new
                {
                    Menu1ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description1 = table.Column<string>(nullable: true),
                    Ingredients1 = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Name1 = table.Column<string>(nullable: true),
                    NameOfRest1 = table.Column<string>(nullable: true),
                    Price1 = table.Column<decimal>(nullable: false),
                    Stars1 = table.Column<int>(nullable: false),
                    Type1 = table.Column<string>(nullable: true),
                    TypeOfMeat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu1s", x => x.Menu1ID);
                });

            migrationBuilder.CreateTable(
                name: "Menu2s",
                columns: table => new
                {
                    Menu2ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description2 = table.Column<string>(nullable: true),
                    Ingredients2 = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Name2 = table.Column<string>(nullable: true),
                    NameOfRest2 = table.Column<string>(nullable: true),
                    Price2 = table.Column<decimal>(nullable: false),
                    Stars2 = table.Column<int>(nullable: false),
                    Type2 = table.Column<string>(nullable: true),
                    TypeOfMeat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu2s", x => x.Menu2ID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FromMemberID = table.Column<int>(nullable: true),
                    Subject = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Messages_Members_FromMemberID",
                        column: x => x.FromMemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewMessage",
                columns: table => new
                {
                    NewMessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(maxLength: 175, nullable: false),
                    MessageID = table.Column<int>(nullable: true),
                    Subject = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewMessage", x => x.NewMessageID);
                    table.ForeignKey(
                        name: "FK_NewMessage_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "MessageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromMemberID",
                table: "Messages",
                column: "FromMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_NewMessage_MessageID",
                table: "NewMessage",
                column: "MessageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu1s");

            migrationBuilder.DropTable(
                name: "Menu2s");

            migrationBuilder.DropTable(
                name: "NewMessage");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
