using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemasDeTarefas.Migrations
{
    public partial class VinculoTarefaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TaskModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "TaskModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskModels_UserModelId",
                table: "TaskModels",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskModels_Users_UserModelId",
                table: "TaskModels",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskModels_Users_UserModelId",
                table: "TaskModels");

            migrationBuilder.DropIndex(
                name: "IX_TaskModels_UserModelId",
                table: "TaskModels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskModels");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "TaskModels");
        }
    }
}
