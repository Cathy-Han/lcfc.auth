using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lcfc.auth.data.Migrations
{
    public partial class _20190218r1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Number = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    MobileNum = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    TargetKey = table.Column<string>(nullable: true),
                    ParentNumber = table.Column<long>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    IsSystemed = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    TimeStamp = table.Column<TimeSpan>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Domain = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Account_Account_ParentNumber",
                        column: x => x.ParentNumber,
                        principalTable: "Account",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountRoleMap",
                columns: table => new
                {
                    Account = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false),
                    ByManual = table.Column<bool>(nullable: false),
                    ByDepend = table.Column<bool>(nullable: false),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    TimeStamp = table.Column<TimeSpan>(nullable: false),
                    Domain = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRoleMap", x => new { x.Account, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Domain = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Deep = table.Column<int>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    ParentCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    TimeStamp = table.Column<TimeSpan>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Location_Location_ParentCode",
                        column: x => x.ParentCode,
                        principalTable: "Location",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passport",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Account = table.Column<long>(nullable: false),
                    LoginName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    EncryptType = table.Column<string>(nullable: true),
                    IsExternal = table.Column<bool>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    TimeStamp = table.Column<TimeSpan>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Domain = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    TimeStamp = table.Column<TimeSpan>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Domain = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleModuleMap",
                columns: table => new
                {
                    RoleId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Package = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    TimeStamp = table.Column<TimeSpan>(nullable: false),
                    Domain = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModuleMap", x => new { x.RoleId, x.Name });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Domain",
                table: "Account",
                column: "Domain");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email",
                table: "Account",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Account_MobileNum",
                table: "Account",
                column: "MobileNum");

            migrationBuilder.CreateIndex(
                name: "IX_Account_ParentNumber",
                table: "Account",
                column: "ParentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_ParentCode",
                table: "Location",
                column: "ParentCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_Domain_Name",
                table: "Location",
                columns: new[] { "Domain", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passport_Account",
                table: "Passport",
                column: "Account");

            migrationBuilder.CreateIndex(
                name: "IX_Passport_LoginName_Domain",
                table: "Passport",
                columns: new[] { "LoginName", "Domain" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name_Domain",
                table: "Role",
                columns: new[] { "Name", "Domain" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleModuleMap_Title_Domain",
                table: "RoleModuleMap",
                columns: new[] { "Title", "Domain" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "AccountRoleMap");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Passport");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RoleModuleMap");
        }
    }
}
