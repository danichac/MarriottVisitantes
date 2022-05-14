using Microsoft.EntityFrameworkCore.Migrations;

namespace MarriottVisitantes.Repositorio.Migrations
{
    public partial class NullableFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Temperatura",
                table: "Visitas",
                type: "TEXT",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "SegundoApellido",
                table: "Visitantes",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "segundo_nombre",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "segundo_apellido",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "19edaa13-6666-42c8-865f-b1b6bde4f45c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e1a0e3c4-8b9f-46a3-9af0-95ec3c2dc352");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHfgs7q9vvLfDwkyyTSNl6FIy0YnCrSRE16u5eJDv9LY0ISPzmB10zauO9OmHZ+iFQ==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Temperatura",
                table: "Visitas",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SegundoApellido",
                table: "Visitantes",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "segundo_nombre",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "segundo_apellido",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

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
        }
    }
}
