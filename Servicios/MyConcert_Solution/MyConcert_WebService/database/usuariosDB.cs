using MyConcert_WebService.objects;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace MyConcert_WebService.database
{
    class UsuariosDB
    {
        private UtilidadesDB _utilidades = new UtilidadesDB();

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

        public tiposusuarios obtenerTipoUsuario(string tipoUsuario)
        {
            tiposusuarios obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.tiposusuarios.FirstOrDefault(g => g.tipo == tipoUsuario);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public Usuario obtenerUsuario(string username)
        {
            usuarios us = null;
            Usuario user = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    us = context.usuarios.FirstOrDefault(r => r.username == username);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            user = convertirusuariosAUsuario(us);
            return user;
        }

        public void añadirUsuario(Usuario pUsuarioNuevo, int[] pGenerosFavoritos)
        {
            usuarios us = convertirUsuarioAusuarios(pUsuarioNuevo);

            List<generos> gen = covertirGenerosFavoritos(pGenerosFavoritos);

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

        private usuarios convertirUsuarioAusuarios(Usuario pUser)
        {
            usuarios usuario = new usuarios();
            usuario.nombre = pUser.Nombre;
            usuario.apellido = pUser.Apellido;
            usuario.username = pUser.NombreUsuario;
            usuario.contraseña = pUser.Contrasena;
            usuario.correo = pUser.Email;
            usuario.FK_USUARIOS_ESTADOS = _utilidades.obtenerEstado(pUser.Estado).PK_estados;
            usuario.fechaInscripcion = pUser.FechaInscripcion;

            if (pUser.TipoUsuario == obtenerTipoUsuario(2).tipo)
            {
                Fanatico fanatico = (Fanatico) pUser;
                usuario.fechaNacimiento = fanatico.FechaNacimiento;
                usuario.telefono = fanatico.Telefono;
                usuario.FK_USUARIOS_PAISES = _utilidades.obtenerPais(fanatico.Pais).PK_paises;
                usuario.descripcion = fanatico.DescripcionPersonal;
                usuario.FK_USUARIOS_TIPOSUSUARIOS = obtenerTipoUsuario(fanatico.TipoUsuario).PK_tiposUsuarios;
                usuario.FK_USUARIOS_UNIVERSIDADES = _utilidades.obtenerUniversidad(fanatico.Universidad).PK_universidades;
                usuario.ubicacion = fanatico.Ubicacion;
                usuario.foto = fanatico.FotoPerfil;
            } else
            {
                usuario.FK_USUARIOS_TIPOSUSUARIOS = obtenerTipoUsuario(pUser.TipoUsuario).PK_tiposUsuarios;
            }
            return usuario;
        }

        private Usuario convertirusuariosAUsuario(usuarios pUser)
        {
            Usuario user = null;

            if (obtenerTipoUsuario(pUser.FK_USUARIOS_TIPOSUSUARIOS).tipo == obtenerTipoUsuario(1).tipo)
            {
                string country = _utilidades.obtenerPais(pUser.FK_USUARIOS_ESTADOS).pais;
                string state = _utilidades.obtenerEstado((int) pUser.FK_USUARIOS_PAISES).estado;
                string university = _utilidades.obtenerUniversidad((int)pUser.FK_USUARIOS_UNIVERSIDADES).nombreUni;
                string user_type = obtenerTipoUsuario(pUser.FK_USUARIOS_TIPOSUSUARIOS).tipo;
                user = 
                    new Fanatico(pUser.nombre,
                                pUser.apellido,
                                pUser.username,
                                pUser.contraseña,
                                pUser.correo,
                                state,
                                pUser.fechaInscripcion,
                                pUser.foto,
                                pUser.fechaNacimiento.Value,
                                pUser.telefono,
                                country,
                                pUser.descripcion,
                                university,
                                user_type,
                                pUser.ubicacion);

            } else if(obtenerTipoUsuario(pUser.FK_USUARIOS_TIPOSUSUARIOS).tipo == obtenerTipoUsuario(2).tipo)
            {
                string stateColaborador = _utilidades.obtenerEstado(pUser.FK_USUARIOS_ESTADOS).estado;
                string user_typeColaborador = obtenerTipoUsuario(pUser.FK_USUARIOS_TIPOSUSUARIOS).tipo;
                user = 
                    new Colaborador(pUser.nombre,
                                    pUser.apellido,
                                    pUser.username,
                                    pUser.contraseña,
                                    pUser.correo,
                                    stateColaborador,
                                    pUser.fechaInscripcion,
                                    user_typeColaborador);
            }

            return user;
        }

        private List<generos> covertirGenerosFavoritos(int[] pGeneros)
        {
            List<generos> listaGeneros = new List<generos>();

            foreach (int genero in pGeneros)
            {
                listaGeneros.Add(_utilidades.obtenerGenero(genero));
            }

            return listaGeneros;
        }


        public void añadirUsuario(Usuario pUser)
        {
            usuarios us = convertirUsuarioAusuarios(pUser);

            using (myconcertEntities context = new myconcertEntities())
            {

                try
                {
                    us = context.usuarios.Add(us);
                    context.SaveChanges();
                }

                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw (e);
                }
                
            }



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

        public List<generos> obtenerGenerosUsuario(usuarios us)
        {
            List<generos> obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    var gen = context.generos.Join(context.generosusuario,
                                               g=>g.PK_generos,
                                               gu=> gu.FK_GENEROSUSUARIO_GENEROS,
                                               (g,gu)=> new {g,gu})
                                         .Where(r=> r.gu.FK_GENEROSUSUARIO_USUARIOS==us.username)
                                         .Select(z=> new { PK_generos = z.g.PK_generos,
                                                           genero=z.g.genero}).ToList();

                    foreach(var i in gen)
                    {
                        obj.Add(context.generos.FirstOrDefault(g=>g.PK_generos==i.PK_generos));
                    }
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
