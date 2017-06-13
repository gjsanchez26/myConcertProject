using MyConcert_WebService.viewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConcert_WebService.database
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
                        nuevoEvento = context.eventos.Add(nuevoEvento);

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
        public categoriasevento obtenerCategoriasEvento(int PK_categoriasEvento)
        {
            categoriasevento obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.categoriasevento.FirstOrDefault(r => r.PK_categoriasEvento == PK_categoriasEvento);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }

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
            }
            catch (Exception e)
            {
                throw (e);
            }
            return calificacion;
        }

        public int obtenerCantidadVotos(int cartelera, int categoria, int banda)
        {
            int votos = 0;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    votos = (int)context.votos.Where(r => (r.FK_VOTOS_EVENTOS == cartelera) 
                                                    && (r.FK_VOTOS_CATEGORIAS==categoria)
                                                    &&(r.FK_VOTOS_BANDAS==banda))
                                                    .Sum(r => r.valor);

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return votos;
        }
    }
    }
}
