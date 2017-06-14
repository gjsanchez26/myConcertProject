using MyConcert_WebService.res.assembler;
using MyConcert_WebService.res.resultados;
using MyConcert_WebService.viewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MyConcert_WebService.models
{
    public class VotacionesModel
    {
        private ManejadorBD _manejador = new ManejadorBD();
        private Assembler _assembler = new Assembler();
        private FabricaRespuestas _creador = new FabricaRespuestas();

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
                //respuesta = _creador.crearRespuesta(false, "Error al interpretar votaciones.");
                respuesta = _creador.crearRespuesta(false, "Error al interpretar votaciones.", e.ToString());
            }

            try
            {
                _manejador.añadirVotos(listaVotaciones);
                respuesta = _creador.crearRespuesta(true, "Votacion procesada.");
            }
            catch (Exception e)
            {
                //respuesta = _creador.crearRespuesta(false, "Error al procesar votacion.");
                respuesta = _creador.crearRespuesta(false, "Error al procesar votacion.", e.ToString());
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
            List<votos> listaVotaciones = _assembler.updateListavotos(listaParseVotaciones.ToArray());
            return listaVotaciones;
        }
    }
}
