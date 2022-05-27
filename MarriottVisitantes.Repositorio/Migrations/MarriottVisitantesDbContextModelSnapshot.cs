﻿// <auto-generated />
using System;
using MarriottVisitantes.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarriottVisitantes.Repositorio.Migrations
{
    [DbContext(typeof(MarriottVisitantesDbContext))]
    partial class MarriottVisitantesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("MarriottVisitantes.Dominio.Entidades.ColorGafete", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ColorGafete");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Negro"
                        },
                        new
                        {
                            Id = 2,
                            Color = "Amarillo"
                        },
                        new
                        {
                            Id = 3,
                            Color = "Café"
                        },
                        new
                        {
                            Id = 4,
                            Color = "Rojo"
                        },
                        new
                        {
                            Id = 5,
                            Color = "Verde"
                        });
                });

            modelBuilder.Entity("MarriottVisitantes.Dominio.Entidades.TipoVisita", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TipoVisita");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Tipo = "Entrega"
                        },
                        new
                        {
                            Id = 2,
                            Tipo = "Extensa"
                        });
                });

            modelBuilder.Entity("MarriottVisitantes.Dominio.Entidades.Visita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ColorGafeteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaVisita")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HoraEntrada")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("HoraSalida")
                        .HasColumnType("TEXT");

                    b.Property<int?>("NumeroGafete")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoVisitaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("VisitaTerminada")
                        .HasColumnType("INTEGER");

                    b.Property<long>("VisitanteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ColorGafeteId");

                    b.HasIndex("TipoVisitaId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("VisitanteId");

                    b.ToTable("Visitas");
                });

            modelBuilder.Entity("MarriottVisitantes.Dominio.Entidades.Visitante", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreEmpresa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("SegundoApellido")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("SegundoNombre")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Visitantes");
                });

            modelBuilder.Entity("MarriottVisitantes.Dominio.Identidad.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "d1bfcfda-447a-495d-a7db-2ba9a86066aa",
                            Name = "Administrador",
                            NormalizedName = "ADMINISTRADOR"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "48566ad0-35a6-46f3-ba32-4327c2de13aa",
                            Name = "Usuario",
                            NormalizedName = "USUARIO"
                        });
                });

            modelBuilder.Entity("MarriottVisitantes.Dominio.Identidad.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("password");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("primer_apellido");

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("primer_nombre");

                    b.Property<string>("SegundoApellido")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("segundo_apellido");

                    b.Property<string>("SegundoNombre")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("segundo_nombre");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("nombre_usuario");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "dfchacon@uned.cr",
                            NormalizedEmail = "DFCHACON@UNED.CR",
                            NormalizedUserName = "DANICHAC",
                            PasswordHash = "AQAAAAEAACcQAAAAEHgNPEdr9C4Wz6S5CkhLHAbcV32Q+fiHWZDgmB6CAICa9AxCESEBwc5n6J1/EfPWcQ==",
                            PrimerApellido = "Chacón",
                            PrimerNombre = "Daniel",
                            SegundoApellido = "Navarro",
                            SegundoNombre = "",
                            UserName = "danichac"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<int>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MarriottVisitantes.Dominio.Identidad.UsuarioRol", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<int>");

                    b.HasIndex("RoleId");

                    b.HasDiscriminator().HasValue("UsuarioRol");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("MarriottVisitantes.Dominio.Entidades.Visita", b =>
                {
                    b.HasOne("MarriottVisitantes.Dominio.Entidades.ColorGafete", "ColorGafete")
                        .WithMany()
                        .HasForeignKey("ColorGafeteId");

                    b.HasOne("MarriottVisitantes.Dominio.Entidades.TipoVisita", "TipoVisita")
                        .WithMany()
                        .HasForeignKey("TipoVisitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarriottVisitantes.Dominio.Identidad.Usuario", "Usuario")
                        .WithMany("Visitas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarriottVisitantes.Dominio.Entidades.Visitante", "Visitante")
                        .WithMany("Visitas")
                        .HasForeignKey("VisitanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ColorGafete");

                    b.Navigation("TipoVisita");

                    b.Navigation("Usuario");

                    b.Navigation("Visitante");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("MarriottVisitantes.Dominio.Identidad.Rol", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("MarriottVisitantes.Dominio.Identidad.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("MarriottVisitantes.Dominio.Identidad.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("MarriottVisitantes.Dominio.Identidad.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarriottVisitantes.Dominio.Identidad.UsuarioRol", b =>
                {
                    b.HasOne("MarriottVisitantes.Dominio.Identidad.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarriottVisitantes.Dominio.Identidad.Usuario", "Usuario")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MarriottVisitantes.Dominio.Entidades.Visitante", b =>
                {
                    b.Navigation("Visitas");
                });

            modelBuilder.Entity("MarriottVisitantes.Dominio.Identidad.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("MarriottVisitantes.Dominio.Identidad.Usuario", b =>
                {
                    b.Navigation("Roles");

                    b.Navigation("Visitas");
                });
#pragma warning restore 612, 618
        }
    }
}
