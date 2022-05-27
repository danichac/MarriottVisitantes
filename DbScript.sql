CREATE TABLE "AspNetRoles" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AspNetRoles" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "NormalizedName" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL
);


CREATE TABLE "AspNetUsers" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AspNetUsers" PRIMARY KEY AUTOINCREMENT,
    "nombre_usuario" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "password" TEXT NOT NULL,
    "primer_nombre" TEXT NOT NULL,
    "segundo_nombre" TEXT NULL,
    "primer_apellido" TEXT NOT NULL,
    "segundo_apellido" TEXT NULL,
    "NormalizedUserName" TEXT NULL,
    "NormalizedEmail" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL
);


CREATE TABLE "ColorGafete" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_ColorGafete" PRIMARY KEY,
    "Color" TEXT NOT NULL
);


CREATE TABLE "TipoVisita" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_TipoVisita" PRIMARY KEY,
    "Tipo" TEXT NOT NULL
);


CREATE TABLE "Visitantes" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Visitantes" PRIMARY KEY AUTOINCREMENT,
    "Cedula" TEXT NOT NULL,
    "PrimerNombre" TEXT NOT NULL,
    "SegundoNombre" TEXT NULL,
    "PrimerApellido" TEXT NOT NULL,
    "SegundoApellido" TEXT NULL,
    "NombreEmpresa" TEXT NOT NULL
);


CREATE TABLE "AspNetRoleClaims" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY AUTOINCREMENT,
    "RoleId" INTEGER NOT NULL,
    "ClaimType" TEXT NULL,
    "ClaimValue" TEXT NULL,
    CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE
);


CREATE TABLE "AspNetUserClaims" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY AUTOINCREMENT,
    "UserId" INTEGER NOT NULL,
    "ClaimType" TEXT NULL,
    "ClaimValue" TEXT NULL,
    CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);


CREATE TABLE "AspNetUserLogins" (
    "LoginProvider" TEXT NOT NULL,
    "ProviderKey" TEXT NOT NULL,
    "ProviderDisplayName" TEXT NULL,
    "UserId" INTEGER NOT NULL,
    CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
    CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);


CREATE TABLE "AspNetUserRoles" (
    "UserId" INTEGER NOT NULL,
    "RoleId" INTEGER NOT NULL,
    "Discriminator" TEXT NOT NULL,
    CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);


CREATE TABLE "AspNetUserTokens" (
    "UserId" INTEGER NOT NULL,
    "LoginProvider" TEXT NOT NULL,
    "Name" TEXT NOT NULL,
    "Value" TEXT NULL,
    CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
    CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);


CREATE TABLE "Visitas" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Visitas" PRIMARY KEY AUTOINCREMENT,
    "VisitanteId" INTEGER NOT NULL,
    "UsuarioId" INTEGER NOT NULL,
    "ColorGafeteId" INTEGER NULL,
    "NumeroGafete" INTEGER NULL,
    "TipoVisitaId" INTEGER NOT NULL,
    "HoraEntrada" TEXT NOT NULL,
    "HoraSalida" TEXT NULL,
    "FechaVisita" TEXT NOT NULL,
    "VisitaTerminada" INTEGER NOT NULL,
    CONSTRAINT "FK_Visitas_AspNetUsers_UsuarioId" FOREIGN KEY ("UsuarioId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Visitas_ColorGafete_ColorGafeteId" FOREIGN KEY ("ColorGafeteId") REFERENCES "ColorGafete" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Visitas_TipoVisita_TipoVisitaId" FOREIGN KEY ("TipoVisitaId") REFERENCES "TipoVisita" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Visitas_Visitantes_VisitanteId" FOREIGN KEY ("VisitanteId") REFERENCES "Visitantes" ("Id") ON DELETE CASCADE
);


INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES (1, '6cb0e643-fd70-4c8a-98ad-091ae728cdaa', 'Administrador', 'ADMINISTRADOR');


INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES (2, 'f4f7fc2b-e83f-40e8-8006-68c2dfce409f', 'Usuario', 'USUARIO');


INSERT INTO "AspNetUsers" ("Id", "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "password", "primer_apellido", "primer_nombre", "segundo_apellido", "segundo_nombre", "nombre_usuario")
VALUES (1, NULL, 'dfchacon@uned.cr', 'DFCHACON@UNED.CR', 'DANICHAC', 'AQAAAAEAACcQAAAAEMc9zpBueyowX2TEHHoI+IEv9+ox/ozDkRBKNLR967y+9N0Iy4fM3nfAymYaNAvB6Q==', 'Chacón', 'Daniel', 'Navarro', '', 'danichac');


INSERT INTO "ColorGafete" ("Id", "Color")
VALUES (1, 'Negro');


INSERT INTO "ColorGafete" ("Id", "Color")
VALUES (2, 'Amarillo');


INSERT INTO "ColorGafete" ("Id", "Color")
VALUES (3, 'Café');


INSERT INTO "ColorGafete" ("Id", "Color")
VALUES (4, 'Rojo');


INSERT INTO "ColorGafete" ("Id", "Color")
VALUES (5, 'Verde');


INSERT INTO "TipoVisita" ("Id", "Tipo")
VALUES (1, 'Entrega');


INSERT INTO "TipoVisita" ("Id", "Tipo")
VALUES (2, 'Extensa');


INSERT INTO "AspNetUserRoles" ("RoleId", "UserId", "Discriminator")
VALUES (1, 1, 'UsuarioRol');


CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ("RoleId");


CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("NormalizedName");


CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId");


CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId");


CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId");


CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");


CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");


CREATE INDEX "IX_Visitas_ColorGafeteId" ON "Visitas" ("ColorGafeteId");


CREATE INDEX "IX_Visitas_TipoVisitaId" ON "Visitas" ("TipoVisitaId");


CREATE INDEX "IX_Visitas_UsuarioId" ON "Visitas" ("UsuarioId");


CREATE INDEX "IX_Visitas_VisitanteId" ON "Visitas" ("VisitanteId");


