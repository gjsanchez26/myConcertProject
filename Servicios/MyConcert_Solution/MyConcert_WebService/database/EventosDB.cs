using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConcert.database
{
    public class EventosDB
    {

        /*Añade una evento a la base de datos, ya sea una cartelera o un festival
         */
        public void añadirEvento(eventos pEvento, List<categoriasevento> categoriasBanda)
        {
            eventos nuevoEvento = null;

            using (myconcertEntities context = new myconcertEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        nuevoEvento = context.eventos.Add(pEvento);

                        foreach (categoriasevento cat_eve in categoriasBanda)
                        {
                            cat_eve.FK_CATEGORIASEVENTO_EVENTOS = nuevoEvento.PK_eventos;
                            context.categoriasevento.Add(cat_eve);
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
        /*
         */
        public List<eventos> obtenerCarteleras()
        {
            List<eventos> obj = null;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.eventos.Where(r => r.FK_EVENTOS_TIPOSEVENTOS==1).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }
        /*
         */
        public List<eventos> obtenerFestivales()
        {
            List<eventos> obj = null;
            try
            {
                
                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.eventos.Where(r => r.FK_EVENTOS_TIPOSEVENTOS == 2).ToList();
                }
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }
        /*
         */
  
        public eventos obtenerEvento(int PK_evento)
        {
            eventos obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.eventos.FirstOrDefault(r => r.PK_eventos == PK_evento);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }

        public eventos obtenerEvento(string evento)
        {
            eventos obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.eventos.FirstOrDefault(r => r.nombreEve == evento);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }
        /*
         */
        public tiposeventos obtenerTipoEvento(int PK_tipoEvento)
        {
            tiposeventos obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.tiposeventos.FirstOrDefault(g => g.PK_tiposEventos == PK_tipoEvento);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }
        /*
         */
        public tiposeventos obtenerTipoEvento(string tipoEvento)
        {
            tiposeventos obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.tiposeventos.FirstOrDefault(g => g.tipo == tipoEvento);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }
        /*
         */
 
        public List<bandas> obtenerBandasNoCartelera(eventos cartelera)
        {
            List<bandas> bandasCarte = null;
            string query = @"SELECT B.PK_bandas, B.nombreBan, B.FK_BANDAS_ESTADOS " +
                            "FROM bandas as B INNER JOIN categoriasevento as CE " +
                            "on CE.FK_CATEGORIASEVENTO_BANDAS = B.PK_bandas " +
                            "where CE.FK_CATEGORIASEVENTO_EVENTOS = ?PK_eventos";

            MySqlParameter[] parameters = {
            new MySqlParameter("?PK_eventos", cartelera.PK_eventos)
            };
            List<bandas> bandasTotal = null;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    bandasCarte = context.bandas.SqlQuery(query, parameters).ToList<bandas>();

                  bandasTotal = context.bandas.ToList();
                    foreach (bandas bandaCartelera in bandasCarte)
                    {
                        bandas bandaEliminar = bandasTotal.Find(x => x.nombreBan.Equals(bandaCartelera.nombreBan));
                        if (bandaEliminar != null)
                        {
                            bandasTotal.Remove(bandaEliminar);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return bandasTotal;
        }
        /*
         */
        public int getCantidadComentarios(bandas banda)
        {
            int cantidadComen = 0;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    cantidadComen = context.comentarios.Count(r => r.FK_COMENTARIOS_BANDAS == banda.PK_bandas);

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return cantidadComen;
        }
        /*
         */
        public float getCalificacion(bandas banda)
        {
            float calificacion = 0;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    calificacion = (float)context.comentarios.Where(r => r.FK_COMENTARIOS_BANDAS == banda.PK_bandas).Average(r => r.calificacion);

                }
                return calificacion;
            }
            catch (Exception)
            {
                return calificacion;
            }
            
        }
        /*
         */
        public void crearFestival(eventos festival,List<bandas> perdedoras)
        {
            using (myconcertEntities context = new myconcertEntities())
            {
                
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        eventos fest = context.eventos.FirstOrDefault(e => e.PK_eventos == festival.PK_eventos);

                        fest.FK_EVENTOS_BANDAS_CHEF=festival.FK_EVENTOS_BANDAS_CHEF;
                        fest.comida = festival.comida;
                        fest.servicios = festival.servicios;
                        fest.transporte = festival.transporte;
                        fest.FK_EVENTOS_TIPOSEVENTOS = festival.FK_EVENTOS_TIPOSEVENTOS;
                        context.SaveChanges();
                        foreach (bandas b in perdedoras)
                        {

                            categoriasevento ce = context.categoriasevento.FirstOrDefault(categoria => categoria.FK_CATEGORIASEVENTO_BANDAS == b.PK_bandas && categoria.FK_CATEGORIASEVENTO_EVENTOS == festival.PK_eventos);
                            context.categoriasevento.Remove(ce);
                            List<votos> vot = context.votos.Where(w => w.FK_VOTOS_BANDAS == b.PK_bandas && w.FK_VOTOS_EVENTOS == festival.PK_eventos).ToList();

                            foreach (votos v in vot)
                            {
                                context.votos.Remove(v);
                            }
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

        public bool comprobarBandaEnCartelera(DateTime fInicial, DateTime fFinal,bandas banda)
        {
            int conteo = 0; ;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    conteo = context.eventos.Join(context.categoriasevento,
                                                       e=>e.PK_eventos,
                                                       ce=>ce.FK_CATEGORIASEVENTO_EVENTOS,
                                                       (e,ce)=>new { e,ce})
                                                       .Where(w=>w.ce.FK_CATEGORIASEVENTO_BANDAS==banda.PK_bandas)
                                                       .Select(s=>s.e)
                                                       .Count(c=>c.fechaInicio<fInicial&& c.fechaFinal>fInicial || c.fechaInicio < fFinal && c.fechaFinal > fFinal);

                }
                if (conteo == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}

