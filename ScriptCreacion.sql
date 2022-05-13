CREATE TABLE [AspNetRoles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [AspNetUsers] (
    [Id] int NOT NULL IDENTITY,
    [nombre_usuario] nvarchar(256) NOT NULL,
    [Email] nvarchar(256) NOT NULL,
    [password] nvarchar(max) NOT NULL,
    [primer_nombre] nvarchar(50) NOT NULL,
    [segundo_nombre] nvarchar(50) NULL,
    [primer_apellido] nvarchar(50) NOT NULL,
    [segundo_apellido] nvarchar(50) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [ColorGafete] (
    [Id] int NOT NULL,
    [Color] nvarchar(12) NOT NULL,
    CONSTRAINT [PK_ColorGafete] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [TipoVisita] (
    [Id] int NOT NULL,
    [Tipo] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_TipoVisita] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Visitantes] (
    [Id] bigint NOT NULL IDENTITY,
    [Cedula] nvarchar(50) NOT NULL,
    [PrimerNombre] nvarchar(50) NOT NULL,
    [SegundoNombre] nvarchar(50) NULL,
    [PrimerApellido] nvarchar(50) NOT NULL,
    [SegundoApellido] nvarchar(50) NULL,
    [NombreEmpresa] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Visitantes] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] int NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [AspNetUserRoles] (
    [UserId] int NOT NULL,
    [RoleId] int NOT NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [AspNetUserTokens] (
    [UserId] int NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [Visitas] (
    [Id] int NOT NULL IDENTITY,
    [VisitanteId] bigint NOT NULL,
    [UsuarioId] int NOT NULL,
    [ColorGafeteId] int NOT NULL,
    [NumeroGafete] int NOT NULL,
    [TipoVisitaId] int NOT NULL,
    [Temperatura] nvarchar(8) NULL,
    [HoraEntrada] datetime2 NOT NULL,
    [HoraSalida] datetime2 NULL,
    [FechaVisita] datetime2 NOT NULL,
    [VisitaTerminada] bit NOT NULL,
    CONSTRAINT [PK_Visitas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Visitas_AspNetUsers_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Visitas_ColorGafete_ColorGafeteId] FOREIGN KEY ([ColorGafeteId]) REFERENCES [ColorGafete] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Visitas_TipoVisita_TipoVisitaId] FOREIGN KEY ([TipoVisitaId]) REFERENCES [TipoVisita] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Visitas_Visitantes_VisitanteId] FOREIGN KEY ([VisitanteId]) REFERENCES [Visitantes] ([Id]) ON DELETE CASCADE
);
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
VALUES (1, N'5ccd5b7f-29d2-4874-959d-1fece9231989', N'Administrador', N'ADMINISTRADOR'),
(2, N'0e91d51e-551e-4dd5-835e-2a0532d71f3e', N'Usuario', N'USUARIO');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] OFF;
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Email', N'NormalizedEmail', N'NormalizedUserName', N'password', N'primer_apellido', N'primer_nombre', N'segundo_apellido', N'segundo_nombre', N'nombre_usuario') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
    SET IDENTITY_INSERT [AspNetUsers] ON;
INSERT INTO [AspNetUsers] ([Id], [ConcurrencyStamp], [Email], [NormalizedEmail], [NormalizedUserName], [password], [primer_apellido], [primer_nombre], [segundo_apellido], [segundo_nombre], [nombre_usuario])
VALUES (1, NULL, N'dfchacon@uned.cr', N'DFCHACON@UNED.CR', N'DANICHAC', N'AQAAAAEAACcQAAAAEPLyeGxO5mw42NeMcpbk54/JU3Eer8oY763FsBrqVly66eeIqh0dOgd+BubMHV4sUQ==', N'Chacón', N'Daniel', N'Navarro', N'', N'danichac');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Email', N'NormalizedEmail', N'NormalizedUserName', N'password', N'primer_apellido', N'primer_nombre', N'segundo_apellido', N'segundo_nombre', N'nombre_usuario') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
    SET IDENTITY_INSERT [AspNetUsers] OFF;
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Color') AND [object_id] = OBJECT_ID(N'[ColorGafete]'))
    SET IDENTITY_INSERT [ColorGafete] ON;
INSERT INTO [ColorGafete] ([Id], [Color])
VALUES (1, N'Negro'),
(2, N'Amarillo'),
(3, N'Café'),
(4, N'Rojo'),
(5, N'Verde');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Color') AND [object_id] = OBJECT_ID(N'[ColorGafete]'))
    SET IDENTITY_INSERT [ColorGafete] OFF;
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Tipo') AND [object_id] = OBJECT_ID(N'[TipoVisita]'))
    SET IDENTITY_INSERT [TipoVisita] ON;
INSERT INTO [TipoVisita] ([Id], [Tipo])
VALUES (1, N'Entrega'),
(2, N'Extensa');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Tipo') AND [object_id] = OBJECT_ID(N'[TipoVisita]'))
    SET IDENTITY_INSERT [TipoVisita] OFF;
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId', N'Discriminator') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
    SET IDENTITY_INSERT [AspNetUserRoles] ON;
INSERT INTO [AspNetUserRoles] ([RoleId], [UserId], [Discriminator])
VALUES (1, 1, N'UsuarioRol');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId', N'Discriminator') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
    SET IDENTITY_INSERT [AspNetUserRoles] OFF;
GO


CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO


CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO


CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO


CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO


CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO


CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO


CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO


CREATE INDEX [IX_Visitas_ColorGafeteId] ON [Visitas] ([ColorGafeteId]);
GO


CREATE INDEX [IX_Visitas_TipoVisitaId] ON [Visitas] ([TipoVisitaId]);
GO


CREATE INDEX [IX_Visitas_UsuarioId] ON [Visitas] ([UsuarioId]);
GO


CREATE INDEX [IX_Visitas_VisitanteId] ON [Visitas] ([VisitanteId]);
GO


