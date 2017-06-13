using MyConcert_WebService.objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConcert_WebService.database
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
                Console.Write(ex.InnerException.ToString());
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
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }
        public integrantes obtenerIntegrante(int PK_integrante)
        {
            integrantes obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.integrantes.FirstOrDefault(g => g.PK_integrantes == PK_integrante);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public generosbanda obtenerGenerosBanda(int PK_generosBanda)
        {
            generosbanda obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.generosbanda.FirstOrDefault(g => g.PK_generosBanda == PK_generosBanda);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public void añadirCancion(canciones cancion)
        {
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    context.canciones.Add(cancion);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
        }

        public canciones obtenerCancion(int PK_cancion)
        {
            canciones obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.canciones.FirstOrDefault(r => r.PK_canciones == PK_cancion);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public comentarios obtenerComentario(int PK_comentario)
        {
            comentarios obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.comentarios.FirstOrDefault(r => r.PK_comentarios == PK_comentario);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
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
                Console.Write(ex.InnerException.ToString());
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
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }
    }
    }

}
