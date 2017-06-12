using MyConcert_WebService.viewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConcert_WebService.database
{
    public class EventosDB
    {
        private UtilidadesDB _utilidadesDB = new UtilidadesDB();

        //CREADORES DE OBJETOS
        public void añadirCartelera(Cartelera pCartelera, CategoriaBanda[] pCategorias)
        {
            eventos nuevoEvento = convertirCarteleraAeventos(pCartelera);
            List<categoriasevento> categoriasBanda = convertirCategoriaBandaAcategoriasevento(pCategorias);

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
                        throw (ex);
                    }
                }
            }
        }

        private List<categoriasevento> convertirCategoriaBandaAcategoriasevento(CategoriaBanda[] pArrayCategoriaBanda)
        {
            List<categoriasevento> categoriasBandas = new List<categoriasevento>();
            categoriasevento cat_even_aux = null;
            for (int i = 0; i < pArrayCategoriaBanda.Length; i++)
            {
                for (int j=0; j < pArrayCategoriaBanda[i]._bandasID.Length; i++)
                {
                    cat_even_aux = new categoriasevento();
                    cat_even_aux.FK_CATEGORIASEVENTO_BANDAS = pArrayCategoriaBanda[i]._bandasID[j];
                    cat_even_aux.FK_CATEGORIASEVENTO_CATEGORIAS = pArrayCategoriaBanda[i]._categoriaID;
                    categoriasBandas.Add(cat_even_aux);
                }
            }
            return categoriasBandas;
        }

        private eventos convertirCarteleraAeventos(Cartelera pEvento)
        {
            eventos event_carte = new eventos();
            event_carte.PK_eventos = pEvento.Id;
            event_carte.nombreEve = pEvento.Nombre;
            event_carte.ubicacion = pEvento.Ubicacion;
            event_carte.FK_EVENTOS_PAISES = _utilidadesDB.obtenerPais(pEvento.Pais).PK_paises;
            event_carte.fechaInicio = pEvento.FechaInicioFestival;
            event_carte.fechaFinal = pEvento.FechaInicioFestival;
            event_carte.finalVotacion = pEvento.FechaFinalVotacion;
            event_carte.FK_EVENTOS_TIPOSEVENTOS = obtenerTipoEvento(pEvento.TipoEvento).PK_tiposEventos;
            event_carte.FK_EVENTOS_ESTADOS = _utilidadesDB.obtenerEstado(pEvento.Estado).PK_estados;

            return event_carte;
        }

        //OBTENER LISTA DE OBJETOS
        public Evento[] obtenerCarteleras()
        {
            List<eventos> obj = null;
            Evento[] arreglo = null;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.eventos.Where(r => r.FK_EVENTOS_TIPOSEVENTOS==1).ToList();
                }
                arreglo = new Evento[obj.Count];
                int c = 0;
                foreach (eventos i in obj)
                {
                    arreglo[c] = convertireventosAEvento(i);
                    c++;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return arreglo;
        }


        public Evento convertireventosAEvento(eventos pEvento)
        {
            Evento evento;
            string country, event_type, state, chef;

            if (pEvento.FK_EVENTOS_TIPOSEVENTOS == 1)
            {
                country = _utilidadesDB.obtenerPais(pEvento.FK_EVENTOS_PAISES).pais;
                event_type = obtenerTipoEvento(pEvento.FK_EVENTOS_TIPOSEVENTOS).tipo;
                state = _utilidadesDB.obtenerEstado(pEvento.FK_EVENTOS_ESTADOS).estado;

                evento =
                new Cartelera(pEvento.PK_eventos,
                                pEvento.nombreEve,
                                pEvento.ubicacion,
                                country,
                                pEvento.fechaInicio,
                                pEvento.fechaFinal,
                                pEvento.finalVotacion.Value,
                                event_type,
                                state);
            }
            else
            {
                country = _utilidadesDB.obtenerPais(pEvento.FK_EVENTOS_PAISES).pais;
                event_type = obtenerTipoEvento(pEvento.FK_EVENTOS_TIPOSEVENTOS).tipo;
                state = _utilidadesDB.obtenerEstado(pEvento.FK_EVENTOS_ESTADOS).estado;
                chef = null;

                evento =
                new Festival(pEvento.PK_eventos,
                            pEvento.nombreEve,
                            pEvento.ubicacion,
                            country,
                            pEvento.fechaInicio,
                            pEvento.finalVotacion.Value,
                            event_type,
                            state,
                            pEvento.comida,
                            pEvento.transporte,
                            pEvento.servicios,
                            chef);
            }

            return evento;
        }

        public Evento[] obtenerFestivales()
        {
            List<eventos> obj = null;
            Evento[] arreglo = null;
            try
            {
                
                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.eventos.Where(r => r.FK_EVENTOS_TIPOSEVENTOS == 2).ToList();
                }
                arreglo = new Evento[obj.Count];
                int c = 0;
                foreach (eventos i in obj)
                {
                    arreglo[c] = convertireventosAEvento(i);
                    c++;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return arreglo;
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
