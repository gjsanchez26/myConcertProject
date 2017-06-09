using MyConcert_WebService.objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConcert_WebService.database
{
    class UsuariosDB
    {
        public tiposusuarios obtenerTipoUsuario(int PK_tipoUsuario)
        {
            tiposusuarios obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.tiposusuarios.FirstOrDefault(g => g.PK_tiposUsuarios == PK_tipoUsuario);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public usuarios obtenerUsuario(string username)
        {
            usuarios us = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    us = context.usuarios.FirstOrDefault(r => r.username == username);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return us;
        }

        public void añadirFanatico(Usuario pUsuarioNuevo, int[] pGenerosFavoritos)
        {
            using (myconcertEntities context = new myconcertEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        us = context.usuarios.Add(us);

                        foreach (generos g in gen)
                        {
                            generosusuario genUs = new generosusuario
                            {
                                FK_GENEROSUSUARIO_USUARIOS = us.username,
                                FK_GENEROSUSUARIO_GENEROS = g.PK_generos
                            };
                            context.generosusuario.Add(genUs);
                        }
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw (ex);
                    }
                }
            }
        }

        private usuarios convertirUsuario(Usuario pUser)
        {
            usuarios usuario = new usuarios();
            usuario.nombre = pUser.Nombre;
            usuario.apellido = pUser.Apellido;
            usuario.username = pUser.NombreUsuario;
            usuario.contraseña = pUser.Contrasena;
            usuario.correo = pUser.Email;
            usuario.estados = pUser.Estado;
            usuario.fechaInscripcion = pUser.FechaInscripcion;
            usuario.foto = pUser.FotoPerfil;

            if (pUser.TipoUsuario == "fanatico")
            {
                Fanatico fanatico = (Fanatico) pUser;
                usuario.fechaNacimiento = fanatico.FechaNacimiento;
                usuario.telefono = fanatico.Telefono;
                usuario.paises = fanatico.Pais;
                usuario.descripcion = fanatico.DescripcionPersonal;
                usuario.tiposusuarios = fanatico.TipoUsuario;
            }

            return usuario;
        }

        public void añadirGeneroUsuario(generosusuario genUs)
        {
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    context.generosusuario.Add(genUs);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
        }

        public generosusuario obtenerGenerosUsuario(int PK_generosUsuario)
        {
            generosusuario obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.generosusuario.FirstOrDefault(g => g.PK_generosUsuario == PK_generosUsuario);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

    }
}
