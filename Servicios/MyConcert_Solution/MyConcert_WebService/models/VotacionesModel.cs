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
        public VotacionesModel()
        {
            _manejador = new FacadeDB();
            _convertidor = new Assembler();
            _fabricaRespuestas = new FabricaRespuestas();
        }

        public Respuesta nuevaVotacion(int pEvento, string pNombreUsuario, JArray pCategorias)
        {
            Respuesta respuesta = null;
            List<votos> listaVotaciones = null;

            try
            {
                listaVotaciones = generarVotos(pEvento, pNombreUsuario, pCategorias);

                List<List<votos>> matrizVotos = new List<List<votos>>();
                foreach(votos votoActual in listaVotaciones)
                {

                }
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
            List<Voto> listaParseVotaciones = new List<Voto>();
            foreach (dynamic categoria in pCategorias)
            {
                int idCategoria = (int)categoria.category;
                int idBanda = (int)categoria.band;
                int cantidadVoto = (int)categoria.vote;
                Voto votoActual =
                        new Voto(0,
                                pNombreUsuario,
                                cantidadVoto,
                                _manejador.obtenerBanda(idBanda).nombreBan,
                                _manejador.obtenerCategoria(idCategoria).categoria,
                                pEvento);
                listaParseVotaciones.Add(votoActual);
            }
            List<votos> listaVotaciones = _convertidor.updateListavotos(listaParseVotaciones.ToArray());
            return listaVotaciones;
        }
    }
}
