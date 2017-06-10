using MyConcert_WebService.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.database
{
    class BandasDB
    {
        UtilidadesDB utiDB = new UtilidadesDB();
        
        public void añadirBanda(bandas banda, string[] pIntegrantes, string[] pCanciones,int[] pGeneros )
        {
            UsuariosDB usuDB = new UsuariosDB();
            List<generos> gen = usuDB.covertirGenerosFavoritos(pGeneros);
            List<canciones> can = convertirCancionesAcanciones(pCanciones);
            List<integrantes> integ = convertirIntegrantesAintegrantes(pIntegrantes);
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
                        Console.Write(ex.InnerException.ToString());
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }

        private List<integrantes> convertirIntegrantesAintegrantes(string[] pIntegrantes)
        {
            List<integrantes> integran = new List<integrantes>();
            for (int i = 0; i < integran.Count; i++)
            {
                integrantes integrante = new integrantes();
                 integrante.nombreInt= pIntegrantes[i];
                integran.Add(integrante);
            }
            return integran;
        }

        private List<canciones> convertirCancionesAcanciones(string[] pCanciones)
        {
            List<canciones> canciones= new List<canciones>();
            for(int i=0; i < canciones.Count; i++)
            {
                canciones cancion = new canciones();
                cancion.cancion = pCanciones[i];
                canciones.Add(cancion);
            }
            return canciones;
        }
        
 
        private Banda convertirbandaABanda(bandas pBanda)
        {
            EventosDB eveDB = new EventosDB();
            int id = pBanda.PK_bandas;
            string nombre = pBanda.nombreBan;
            float calificacion = eveDB.getCalificacion(pBanda);
            string estado = utiDB.obtenerEstado(pBanda.FK_BANDAS_ESTADOS).estado;
            Banda ban = new Banda(id, nombre, calificacion, estado);
            return ban;
        } 

        private bandas convertirBandaAbanda(Banda pBanda)
        {
            EventosDB eveDB = new EventosDB();
            string nombre = pBanda.Nombre;
            int estado = utiDB.obtenerEstado(pBanda.Estado).PK_estados;
            bandas ban = new bandas();
            ban.FK_BANDAS_ESTADOS = estado;
            ban.nombreBan = nombre;
            return ban;
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
    }

}
