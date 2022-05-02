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
    "segundo_nombre" TEXT NOT NULL,
    "primer_apellido" TEXT NOT NULL,
    "segundo_apellido" TEXT NOT NULL,
    "NormalizedUserName" TEXT NULL,
    "NormalizedEmail" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL
);


CREATE TABLE "Visitantes" (
    "IdVisitante" INTEGER NOT NULL CONSTRAINT "PK_Visitantes" PRIMARY KEY AUTOINCREMENT,
    "Cedula" TEXT NOT NULL,
    "PrimerNombre" TEXT NOT NULL,
    "SegundoNombre" TEXT NULL,
    "PrimerApellido" TEXT NOT NULL,
    "SegundoApellido" TEXT NOT NULL,
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
    "IdVisita" INTEGER NOT NULL CONSTRAINT "PK_Visitas" PRIMARY KEY AUTOINCREMENT,
    "IdVisitante" INTEGER NOT NULL,
    "VisitanteIdVisitante" INTEGER NULL,
    "ColorGafete" INTEGER NOT NULL,
    "NumeroGafete" INTEGER NOT NULL,
    "HoraEntrada" TEXT NOT NULL,
    "HoraSalida" TEXT NOT NULL,
    "FechaVisita" TEXT NOT NULL,
    "VisitaTerminada" INTEGER NOT NULL,
    CONSTRAINT "FK_Visitas_Visitantes_VisitanteIdVisitante" FOREIGN KEY ("VisitanteIdVisitante") REFERENCES "Visitantes" ("IdVisitante") ON DELETE RESTRICT
);


INSERT INTO "AspNetUsers" ("Id", "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "password", "primer_apellido", "primer_nombre", "segundo_apellido", "segundo_nombre", "nombre_usuario")
VALUES (1, NULL, 'dfchacon@uned.cr', 'DFCHACON@UNED.CR', 'DANICHAC', 'Welcome123', 'Chacón', 'Daniel', 'Navarro', '', 'danichac');


CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ("RoleId");


CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("NormalizedName");


CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId");


CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId");


CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId");


CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");


CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");


CREATE INDEX "IX_Visitas_VisitanteIdVisitante" ON "Visitas" ("VisitanteIdVisitante");


