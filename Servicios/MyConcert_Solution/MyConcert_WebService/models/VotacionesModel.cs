using MyConcert.resources.assembler;
using MyConcert.resources.results;
using MyConcert.viewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MyConcert.models
{
    public class VotacionesModel : AbstractModel
    {
        public Respuesta nuevaVotacion(int pEvento, string pNombreUsuario, JArray pCategorias)
        {
            Respuesta respuesta = null;
            List<votos> listaVotaciones = null;

            try
            {
                listaVotaciones = generarVotos(pEvento, pNombreUsuario, pCategorias);
            }
            catch (Exception e)
            {
                //respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al interpretar votaciones.");
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al interpretar votaciones.", e.ToString());
            }

            try
            {
                _manejador.añadirVotos(listaVotaciones);
                respuesta = _fabricaRespuestas.crearRespuesta(true, "Votacion procesada.");
            }
            catch (Exception e)
            {
                //respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al procesar votacion.");
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al procesar votacion.", e.ToString());
            }

            return respuesta;
        }

        private List<votos> generarVotos(int pEvento, string pNombreUsuario, JArray pCategorias)
        {
            JArray votosJSON = null;
            List<Voto> listaParseVotaciones = new List<Voto>();
            foreach (dynamic categoria in pCategorias)
            {
                string nombreCategoria = (string)categoria.category;
                votosJSON = (JArray)categoria.votes;
                foreach (dynamic votacion in votosJSON)
                {
                    string nombreBanda = (string)votacion.band;
                    int cantidadVoto = (int)votacion.vote;
                    Voto votoActual =
                        new Voto(0,
                                pNombreUsuario,
                                cantidadVoto,
                                nombreBanda,
                                nombreCategoria,
                                pEvento);
                    listaParseVotaciones.Add(votoActual);
                }
            }
            List<votos> listaVotaciones = _convertidor.updateListavotos(listaParseVotaciones.ToArray());
            return listaVotaciones;
        }
    }
}
