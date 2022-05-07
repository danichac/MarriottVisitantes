using Microsoft.EntityFrameworkCore.Migrations;

namespace MarriottVisitantes.Repositorio.Migrations
{
    public partial class ColorGafete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f6481adf-0c51-4e04-b73d-911ee30f4805");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "11c07ac4-501a-4fd2-98ba-f96514068249");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEB4KxCUBC+0la7Je4bTjg/FA06LHtFZlHdlAbyl0Q4yyqHHb7oZgvDy/K3qFRufLzA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "fa213205-6fe3-4044-ba25-7ae52360d0b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "198f0f4d-7543-4efb-b1e5-4f38d27ca7ad");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEE9tiHORpEVBpm+Y5DacFUP5NZjKIMTnOzmXSd38yt5W9N2zBZJaeK1sFkCSgK5Qnw==");
        }
    }
}
