using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConcert.database
{
    public class EventosDB
    {

        //CREADORES DE OBJETOS
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

       
        //OBTENER LISTA DE OBJETOS
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
        
        //OBTENER 1 OBJETO
       

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

        //ALGORITMO DEL CHEF
        public List<bandas> obtenerBandasNoCartelera(eventos cartelera)
        {
            List<bandas> bandasCarte = null;
            string query = @"SELECT B.PK_bandas, B.nombreBan, B.FK_BANDAS_ESTADOS " +
                            "FROM bandas as B INNER JOIN categoriasevento as CE " +
                            "on CE.FK_CATEGORIASEVENTO_BANDAS = B.PK_bandas " +
                            "where CE.FK_CATEGORIASEVENTO_EVENTOS != ?PK_eventos";

            MySqlParameter[] parameters = {
            new MySqlParameter("?PK_eventos", cartelera.PK_eventos)
        };
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    bandasCarte = context.bandas.SqlQuery(query, parameters).ToList<bandas>();

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return bandasCarte;
        }

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

       

        
        public void crearFestival(eventos festival,List<bandas> perdedoras)
        {
            using (myconcertEntities context = new myconcertEntities())
            {
                
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        eventos fest = context.eventos.FirstOrDefault(e => e.PK_eventos == festival.PK_eventos);

                        fest = festival;
                        foreach (bandas b in perdedoras)
                        {
                            categoriasevento ce = context.categoriasevento.FirstOrDefault(w => w.FK_CATEGORIASEVENTO_BANDAS == b.PK_bandas && w.FK_CATEGORIASEVENTO_EVENTOS==fest.PK_eventos);
                            List<votos> vot = context.votos.Where(w => w.FK_VOTOS_BANDAS == b.PK_bandas && w.FK_VOTOS_EVENTOS == fest.PK_eventos).ToList();
                            context.categoriasevento.Remove(ce);
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
    }
}

