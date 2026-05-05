using Microsoft.EntityFrameworkCore.Migrations;

namespace Proeventos.Persistence.Migrations
{
    public partial class RenameDefaultNameIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_TbEvento_AspNetUsers_UserId",
                table: "TbEvento");

            migrationBuilder.DropForeignKey(
                name: "FK_TbPalestrante_AspNetUsers_UserId",
                table: "TbPalestrante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "TbUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "TbUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "TbUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "TbUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "TbUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "TbRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "TbRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "TbUserRoles",
                newName: "IX_TbUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "TbUserLogins",
                newName: "IX_TbUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "TbUserClaims",
                newName: "IX_TbUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "TbRoleClaims",
                newName: "IX_TbRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbUserTokens",
                table: "TbUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbUsers",
                table: "TbUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbUserRoles",
                table: "TbUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbUserLogins",
                table: "TbUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbUserClaims",
                table: "TbUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbRoles",
                table: "TbRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbRoleClaims",
                table: "TbRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbEvento_TbUsers_UserId",
                table: "TbEvento",
                column: "UserId",
                principalTable: "TbUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbPalestrante_TbUsers_UserId",
                table: "TbPalestrante",
                column: "UserId",
                principalTable: "TbUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbRoleClaims_TbRoles_RoleId",
                table: "TbRoleClaims",
                column: "RoleId",
                principalTable: "TbRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbUserClaims_TbUsers_UserId",
                table: "TbUserClaims",
                column: "UserId",
                principalTable: "TbUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbUserLogins_TbUsers_UserId",
                table: "TbUserLogins",
                column: "UserId",
                principalTable: "TbUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbUserRoles_TbRoles_RoleId",
                table: "TbUserRoles",
                column: "RoleId",
                principalTable: "TbRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbUserRoles_TbUsers_UserId",
                table: "TbUserRoles",
                column: "UserId",
                principalTable: "TbUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbUserTokens_TbUsers_UserId",
                table: "TbUserTokens",
                column: "UserId",
                principalTable: "TbUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbEvento_TbUsers_UserId",
                table: "TbEvento");

            migrationBuilder.DropForeignKey(
                name: "FK_TbPalestrante_TbUsers_UserId",
                table: "TbPalestrante");

            migrationBuilder.DropForeignKey(
                name: "FK_TbRoleClaims_TbRoles_RoleId",
                table: "TbRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_TbUserClaims_TbUsers_UserId",
                table: "TbUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_TbUserLogins_TbUsers_UserId",
                table: "TbUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_TbUserRoles_TbRoles_RoleId",
                table: "TbUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_TbUserRoles_TbUsers_UserId",
                table: "TbUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_TbUserTokens_TbUsers_UserId",
                table: "TbUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbUserTokens",
                table: "TbUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbUsers",
                table: "TbUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbUserRoles",
                table: "TbUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbUserLogins",
                table: "TbUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbUserClaims",
                table: "TbUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbRoles",
                table: "TbRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbRoleClaims",
                table: "TbRoleClaims");

            migrationBuilder.RenameTable(
                name: "TbUserTokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "TbUsers",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "TbUserRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "TbUserLogins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "TbUserClaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "TbRoles",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "TbRoleClaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_TbUserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TbUserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TbUserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TbRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbEvento_AspNetUsers_UserId",
                table: "TbEvento",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbPalestrante_AspNetUsers_UserId",
                table: "TbPalestrante",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
