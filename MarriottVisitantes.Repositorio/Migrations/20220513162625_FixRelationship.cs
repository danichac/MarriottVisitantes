using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarriottVisitantes.Repositorio.Migrations
{
    public partial class FixRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre_usuario = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    primer_nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    segundo_nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    primer_apellido = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    segundo_apellido = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorGafete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Color = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorGafete", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoVisita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVisita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitantes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cedula = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PrimerNombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SegundoNombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PrimerApellido = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    NombreEmpresa = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VisitanteId = table.Column<int>(type: "INTEGER", nullable: false),
                    VisitanteId1 = table.Column<long>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    ColorGafeteId = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroGafete = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoVisitaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Temperatura = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    HoraEntrada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HoraSalida = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FechaVisita = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VisitaTerminada = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitas_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitas_ColorGafete_ColorGafeteId",
                        column: x => x.ColorGafeteId,
                        principalTable: "ColorGafete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitas_TipoVisita_TipoVisitaId",
                        column: x => x.TipoVisitaId,
                        principalTable: "TipoVisita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitas_Visitantes_VisitanteId1",
                        column: x => x.VisitanteId1,
                        principalTable: "Visitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "7612dc6b-8af6-4cc8-92f4-aab5ff757312", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, "06cded73-3f6d-4b07-87c9-4faaa7b36104", "Usuario", "USUARIO" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "password", "primer_apellido", "primer_nombre", "segundo_apellido", "segundo_nombre", "nombre_usuario" },
                values: new object[] { 1, null, "dfchacon@uned.cr", "DFCHACON@UNED.CR", "DANICHAC", "AQAAAAEAACcQAAAAEMIM8Vst6JAu7rwIyYT6/N9VoCiofk1e6DZb7i1/deW8oWSHHhgTMXZsLWZpzj9rPA==", "Chacón", "Daniel", "Navarro", "", "danichac" });

            migrationBuilder.InsertData(
                table: "ColorGafete",
                columns: new[] { "Id", "Color" },
                values: new object[] { 1, "Negro" });

            migrationBuilder.InsertData(
                table: "ColorGafete",
                columns: new[] { "Id", "Color" },
                values: new object[] { 2, "Amarillo" });

            migrationBuilder.InsertData(
                table: "ColorGafete",
                columns: new[] { "Id", "Color" },
                values: new object[] { 3, "Café" });

            migrationBuilder.InsertData(
                table: "ColorGafete",
                columns: new[] { "Id", "Color" },
                values: new object[] { 4, "Rojo" });

            migrationBuilder.InsertData(
                table: "ColorGafete",
                columns: new[] { "Id", "Color" },
                values: new object[] { 5, "Verde" });

            migrationBuilder.InsertData(
                table: "TipoVisita",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 1, "Entrega" });

            migrationBuilder.InsertData(
                table: "TipoVisita",
                columns: new[] { "Id", "Tipo" },
                values: new object[] { 2, "Extensa" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { 1, 1, "UsuarioRol" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_ColorGafeteId",
                table: "Visitas",
                column: "ColorGafeteId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_TipoVisitaId",
                table: "Visitas",
                column: "TipoVisitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_UsuarioId",
                table: "Visitas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_VisitanteId1",
                table: "Visitas",
                column: "VisitanteId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Visitas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ColorGafete");

            migrationBuilder.DropTable(
                name: "TipoVisita");

            migrationBuilder.DropTable(
                name: "Visitantes");
        }
    }
}
