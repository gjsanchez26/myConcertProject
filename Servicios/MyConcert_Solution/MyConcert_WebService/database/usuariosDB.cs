using MyConcert_WebService.viewModels;
using MyConcert_WebService.security;
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
                throw (ex);
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
                throw (ex);
            }
            
            return us;
        }

        public void añadirUsuario(usuarios us, List<generos> gen)
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
