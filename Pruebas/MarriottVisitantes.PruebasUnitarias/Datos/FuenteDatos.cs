using System;
using System.Linq;
using System.Collections.Generic;
using MarriottVisitantes.Dominio.Entidades;
using MarriottVisitantes.Dominio.Identidad;
using MarriottVisitantes.Web.Models.ViewModels;
using MarriottVisitantes.Dominio.DTOs;

namespace MarriottVisitantes.PruebasUnitarias
{
    public static class FuenteDatos
    {
        public static List<Visita> ObtenerVisitas()
        {
            var usuario = new Usuario()
            {
                Id = 1,
                PrimerNombre = "Usuario",
                PrimerApellido = "Prueba",
                Email = "prueba@usuario.com"
            };
            var visitante = new Visitante()
            {
                Id = 1,
                Cedula = "1-1111-1111",
                PrimerNombre = "Visitante",
                PrimerApellido = "Prueba",
                NombreEmpresa ="Empresa Prueba"
            };

            var visitas = new List<Visita>();
            visitas.Add(new Visita()
                {
                    Id = 1,
                    VisitanteId = visitante.Id,
                    Visitante = visitante,
                    UsuarioId = usuario.Id,
                    Usuario = usuario,
                    HoraEntrada = DateTime.Now,
                    HoraSalida = DateTime.Now,
                    TipoVisitaId = TipoVisitaId.Entrega,
                    NumeroGafete = 0,
                    VisitaTerminada = true,
                    FechaVisita = DateTime.Today
                }
            );
            visitas.Add(new Visita()
                {
                    Id = 2,
                    VisitanteId = visitante.Id,
                    Visitante = visitante,
                    UsuarioId = usuario.Id,
                    Usuario = usuario,
                    HoraEntrada = DateTime.Now.AddHours(-2),
                    HoraSalida = DateTime.Now,
                    TipoVisitaId = TipoVisitaId.Extensa,
                    ColorGafeteId = GafeteId.Rojo,
                    NumeroGafete = 12,
                    VisitaTerminada = true,
                    FechaVisita = DateTime.Today
                }
            );
            visitas.Add(new Visita()
                {
                    Id = 3,
                    VisitanteId = visitante.Id,
                    Visitante = visitante,
                    UsuarioId = usuario.Id,
                    Usuario = usuario,
                    HoraEntrada = DateTime.Now.AddHours(-3),
                    HoraSalida = DateTime.Now.AddHours(-1),
                    TipoVisitaId = TipoVisitaId.Extensa,
                    ColorGafeteId = GafeteId.Rojo,
                    NumeroGafete = 13,
                    VisitaTerminada = true,
                    FechaVisita = DateTime.Today
                }
            );
            visitas.Add(new Visita()
                {
                    Id = 4,
                    VisitanteId = visitante.Id,
                    Visitante = visitante,
                    UsuarioId = usuario.Id,
                    Usuario = usuario,
                    HoraEntrada = DateTime.Now.AddHours(-6),
                    HoraSalida = DateTime.Now.AddHours(-3),
                    TipoVisitaId = TipoVisitaId.Extensa,
                    ColorGafeteId = GafeteId.Rojo,
                    NumeroGafete = 14,
                    VisitaTerminada = true,
                    FechaVisita = DateTime.Today
                }
            );
            visitas.Add(new Visita()
                {
                    Id = 5,
                    VisitanteId = visitante.Id,
                    Visitante = visitante,
                    UsuarioId = usuario.Id,
                    Usuario = usuario,
                    HoraEntrada = DateTime.Now.AddHours(-10),
                    HoraSalida = DateTime.Now.AddHours(-8),
                    TipoVisitaId = TipoVisitaId.Extensa,
                    ColorGafeteId = GafeteId.Rojo,
                    NumeroGafete = 15,
                    VisitaTerminada = true,
                    FechaVisita = DateTime.Today
                }
            );

            return visitas;
        } 

        public static VisitasPaginacionDTO ObtenerVisitasPaginacion(bool terminada)
        {
            var visitas = new VisitasPaginacionDTO();
            visitas.Visitas = ObtenerVisitas().Where(v => v.VisitaTerminada = terminada).ToList();
            visitas.TotalResultados = visitas.Visitas.Count;
            visitas.IndicePagina = 1;
            visitas.CantidadPaginas = 1;

            return visitas;
        }

        public static UsuarioCreacionViewModel UsuarioValido()
        {
            var usuario = new UsuarioCreacionViewModel()
            {
                UserName = "usuarioTest",
                PrimerNombre = "Usuario",
                SegundoNombre = "De",
                PrimerApellido = "Prueba",
                SegundoApellido = "Ramírez",
                Email = "usuario_prueba@gmail.com",
                Password = "kejdu$3lo-23",
                PasswordConfirm = "kejdu$3lo-23",
                Rol = "Administrador"
            };

            return usuario;
        }

        public static UsuarioCreacionViewModel UsuarioNoValido()
        {
            var usuario = new UsuarioCreacionViewModel()
            {
                UserName = "usuarioTest",
                PrimerNombre = "Usuario",
                SegundoNombre = "De",
                PrimerApellido = "Prueba",
                SegundoApellido = "Ramírez",
                Email = "",
                Password = "",
                PasswordConfirm = "",
                Rol = "Usuario"
            };

            return usuario;
        }

        public static LoginViewModel LoginValido()
        {
            return new LoginViewModel()
            {
                Email = "usuarioPrueba@gmail.com",
                Password = "kfjur-eoi32$jf",
                RememberMe = true
            };
        }
        public static LoginViewModel LoginNoValido()
        {
            return new LoginViewModel()
            {
                Email = "",
                Password = "",
                RememberMe = true
            };
        }

        public static UsuarioEdicionViewModel UsuarioEdicion()
        {
            return new UsuarioEdicionViewModel()
            {
                UserName = "usuarioTest",
                PrimerNombre = "Usuario",
                SegundoNombre = "De",
                PrimerApellido = "Prueba",
                SegundoApellido = "Ramírez",
                Email = "Usuario@prueba.com",
                PasswordOld = "fekeie83h3jnj",
                Password = "ededed",
                PasswordConfirm = "ededed",
                Rol = "Usuario"
            };
        }

        public static Usuario UsuarioIdentidad()
        {
            var usuario = new Usuario()
            {
                Id = 1,
                PrimerNombre = "Usuario",
                PrimerApellido = "Prueba",
                Email = "prueba@usuario.com",
                PasswordHash = "EKDEKEJFEJNEEMFEFE%#$##$34343334r34",
                UserName = "usuarioTest",
            };

            return usuario;
        }

        public static PasswordRecuperacionViewModel DatosPassword()
        {
            return new PasswordRecuperacionViewModel()
            {
                Id = 1,
                Token = "dnenkjebrfjhewbf3wFEWFewfjwefjwu23293hrjhwbfkjfsd",
                Password = "gfgfgfgfgf",
                PasswordConfirm = "gfgfgfgfgf"
            };
        }

        public static Visitante VisitanteValido()
        {
            var visitante = new Visitante()
            {
                Id = 1,
                Cedula = "1-1111-1111",
                PrimerNombre = "Visitante",
                PrimerApellido = "Prueba",
                NombreEmpresa ="Empresa Prueba"
            };

            return visitante;
        }

        public static Visitante VisitanteNoValido()
        {
            var visitante = new Visitante()
            {
                Id = 1,
                Cedula = "",
                PrimerNombre = "Visitante",
                PrimerApellido = "Prueba",
                NombreEmpresa =""
            };

            return visitante;
        }

        public static Visita ObtenerVisitaEnCurso()
        {
            var usuario = UsuarioIdentidad();
            var visitante = VisitanteValido();

            var visita = new Visita()
            {
                Id = 2,
                VisitanteId = visitante.Id,
                Visitante = visitante,
                UsuarioId = usuario.Id,
                Usuario = usuario,
                HoraEntrada = DateTime.Now.AddHours(-2),
                TipoVisitaId = TipoVisitaId.Extensa,
                ColorGafeteId = GafeteId.Rojo,
                NumeroGafete = 12,
                VisitaTerminada = false,
                FechaVisita = DateTime.Today
            };

            return visita;
        }

        public static VisitantesPaginacionDTO ObtenerVisitantesPaginacion()
        {
            var resultado = new VisitantesPaginacionDTO();

            var visitantes = new List<Visitante>();
            visitantes.Add(VisitanteValido());
            resultado.Visitantes = visitantes;
            resultado.IndicePagina = 1;
            resultado.TotalResultados = 1;
            resultado.CantidadPaginas = 1;
            return resultado;
        }

        public static AgregarVisitasViewModel ObtenerVisitaAgregar()
        {
            var nuevaVisita = new AgregarVisitasViewModel();

            nuevaVisita.Usuario = UsuarioIdentidad();
            nuevaVisita.Visitante = VisitanteValido();
            nuevaVisita.NuevaVisita = new Visita()
            {
                Id = 2,
                VisitanteId = nuevaVisita.Visitante.Id,
                Visitante = nuevaVisita.Visitante,
                UsuarioId = nuevaVisita.Usuario.Id,
                Usuario = nuevaVisita.Usuario,
                HoraEntrada = DateTime.Now.AddHours(-2),
                TipoVisitaId = TipoVisitaId.Extensa,
                ColorGafeteId = GafeteId.Rojo,
                NumeroGafete = 12,
                VisitaTerminada = false,
                FechaVisita = DateTime.Today
            };

            return nuevaVisita;
        }
    }
}