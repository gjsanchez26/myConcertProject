using MyConcert.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConcert.database
{
    class BandasDB
    {

        public void añadirBanda(bandas banda, List<integrantes> integ, List<canciones> can, List<generos> gen)
        {

            using (myconcertEntities context = new myconcertEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        banda = context.bandas.Add(banda);

                        foreach (integrantes i in integ)
                        {
                            i.FK_INTEGRANTES_BANDAS = banda.PK_bandas;
                            context.integrantes.Add(i);
                        }
                        foreach (canciones c in can)
                        {
                            c.FK_CANCIONES_BANDAS = banda.PK_bandas;
                            context.canciones.Add(c);
                        }
                        foreach (generos g in gen)
                        {
                            generosbanda gB = new generosbanda
                            {
                                FK_GENEROSBANDA_BANDAS = banda.PK_bandas,
                                FK_GENEROSBANDA_GENEROS = g.PK_generos
                            };

                            context.generosbanda.Add(gB);
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

        public bandas obtenerBanda(int PK_banda)
        {
            bandas obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.bandas.FirstOrDefault(r => r.PK_bandas == PK_banda);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }

        public bandas obtenerBanda(string banda)
        {
            bandas obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.bandas.FirstOrDefault(r => r.nombreBan == banda);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }

        public List<canciones> obtenerCanciones(bandas banda)
        {
            List<canciones> obj = null;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.canciones.Where(r => r.FK_CANCIONES_BANDAS == banda.PK_bandas).ToList();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }

        public List<integrantes> obtenerIntegrantes(bandas banda)
        {
            List<integrantes> obj = null;

            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.integrantes.Where(i => i.FK_INTEGRANTES_BANDAS == banda.PK_bandas).ToList();

                    
                }



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }

        public List<comentarios> obtenerComentarios (bandas banda)
        {
            List<comentarios> obj = null;

            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.comentarios.Where(i => i.FK_COMENTARIOS_BANDAS == banda.PK_bandas).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }
     
        public List<generos> obtenerGenerosBanda(bandas banda)
        {
            List<generos> obj = new List<generos>();
            
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {
                    var aType = context.generos.Join(context.generosbanda,
                                                g=> g.PK_generos,
                                                gb=> gb.FK_GENEROSBANDA_GENEROS,
                                                (g,gb)=> new { g,gb})
                                                .Where(f=>f.gb.FK_GENEROSBANDA_BANDAS==banda.PK_bandas).
                                                Select(s=>  new {PK_generos =s.g.PK_generos,
                                                                 genero= s.g.genero} ).ToList();

                    foreach (var i in aType)
                    {
                        obj.Add(context.generos.FirstOrDefault(g => g.PK_generos == i.PK_generos));
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }
        public List<bandas> obtenerBandas()
        {
            List<bandas> obj = null;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.bandas.ToList();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }

        public void añadirComentario(comentarios coment)
        {
            using (myconcertEntities context = new myconcertEntities())
            {

                try
                {
                    context.comentarios.Add(coment);

                    context.SaveChanges();

                }
                catch (Exception e)
                {
                    throw (e);
                }
            }
        }
       }
}
