using MyConcert_WebService.objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.database
{
    class EventosDB
    {   //OBTENER LISTA DE OBJETOS
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
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }


        public Evento convertirCartelera(eventos pEvento)
        {
            Evento evento;
            if (pEvento.FK_EVENTOS_TIPOSEVENTOS == 1)
            {
                evento =
                new Cartelera(pEvento.nombreEve,
                                pEvento.ubicacion,
                                pEvento.FK_EVENTOS_PAISES,
                                pEvento.fechaInicio,
                                pEvento.fechaFinal,
                                pEvento.finalVotacion,
                                pEvento.FK_EVENTOS_TIPOSEVENTOS);
            } else
            {
                evento = 
                new Festival(pEvento.nombreEve,
                            pEvento.ubicacion,
                            pEvento.FK_EVENTOS_PAISES,
                            pEvento.fechaInicio,
                            pEvento.finalVotacion,
                            pEvento.FK_EVENTOS_TIPOSEVENTOS,
                            pEvento.FK_EVENTOS_ESTADOS,
                            pEvento.comida,
                            pEvento.transporte,
                            pEvento.servicios,
                            pEvento.recomendacionChef);
            }


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
                Console.Write(ex.InnerException.ToString());
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
                Console.Write(ex.InnerException.ToString());
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
                Console.Write(ex.InnerException.ToString());
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
                Console.Write(ex.InnerException.ToString());
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
                Console.Write(ex.InnerException.ToString());
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
                Console.Write(ex.InnerException.ToString());
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
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return calificacion;
        }
    }
}
