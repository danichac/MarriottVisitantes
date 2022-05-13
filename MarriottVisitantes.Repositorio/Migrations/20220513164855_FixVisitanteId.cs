using Microsoft.EntityFrameworkCore.Migrations;

namespace MarriottVisitantes.Repositorio.Migrations
{
    public partial class FixVisitanteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitas_Visitantes_VisitanteId1",
                table: "Visitas");

            migrationBuilder.DropIndex(
                name: "IX_Visitas_VisitanteId1",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "VisitanteId1",
                table: "Visitas");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7a2f4b4f-88bb-442a-97e8-b2ebfcb36211");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7c50163b-ccb9-4607-944c-4fb3d3bd09a1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMfkdQzg6j79Ov+vjIMQTK4GNhkRKBYhEp6zOASWPMZmtvjlgc0n8+Ijme9TEPC/sA==");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_VisitanteId",
                table: "Visitas",
                column: "VisitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_Visitantes_VisitanteId",
                table: "Visitas",
                column: "VisitanteId",
                principalTable: "Visitantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitas_Visitantes_VisitanteId",
                table: "Visitas");

            migrationBuilder.DropIndex(
                name: "IX_Visitas_VisitanteId",
                table: "Visitas");

            migrationBuilder.AddColumn<long>(
                name: "VisitanteId1",
                table: "Visitas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7612dc6b-8af6-4cc8-92f4-aab5ff757312");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "06cded73-3f6d-4b07-87c9-4faaa7b36104");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMIM8Vst6JAu7rwIyYT6/N9VoCiofk1e6DZb7i1/deW8oWSHHhgTMXZsLWZpzj9rPA==");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_VisitanteId1",
                table: "Visitas",
                column: "VisitanteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_Visitantes_VisitanteId1",
                table: "Visitas",
                column: "VisitanteId1",
                principalTable: "Visitantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
