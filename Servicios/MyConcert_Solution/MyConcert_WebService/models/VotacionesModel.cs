using MyConcert.resources.assembler;
using MyConcert.resources.operations;
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

        public Respuesta nuevaVotacion(JArray pCategorias)
        {
            Respuesta respuesta = null;
            List<votos> listaVotaciones = null;

            try
            {
                listaVotaciones = generarVotos(pCategorias);

                List<List<votos>> matrizVotos = new List<List<votos>>();
                foreach (votos votoARevisar in listaVotaciones)
                {
                    bool agregado = false;
                    foreach (List<votos> lista in matrizVotos)
                    {
                        foreach (votos votoActual in lista)
                        {
                            if (votoActual.FK_VOTOS_CATEGORIAS == votoARevisar.FK_VOTOS_CATEGORIAS)
                            {
                                lista.Add(votoARevisar);
                                agregado = true;
                                break;
                            }
                        }
                    }
                    if (!agregado)
                    {
                        List<votos> nuevaLista = new List<votos>();
                        nuevaLista.Add(votoARevisar);
                        matrizVotos.Add(nuevaLista);
                    }
                }

                DolarStrategy verificadorEstrategia = new DolarStrategy();
                foreach (List<votos> lista in matrizVotos)
                {
                    List<int> suma = new List<int>();
                    votos auxiliarVoto = null;
                    foreach (votos votoActual in lista)
                    {
                        suma.Add(votoActual.valor);
                        auxiliarVoto = votoActual;
                    }
                    if (!verificadorEstrategia.checkDolars(suma)) 
                    {
                        return _fabricaRespuestas.crearRespuesta(false, "Ingrese la cantidad de créditos necesarios en la categoría: "
                            +_manejador.obtenerCategoria(auxiliarVoto.FK_VOTOS_CATEGORIAS).categoria);
                    }
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

        private List<votos> generarVotos(JArray pCategorias)
        {
            List<Voto> listaParseVotaciones = new List<Voto>();
            foreach (dynamic categoria in pCategorias)
            {
                string band = (string)categoria.band;
                int cartelera = (int)categoria.cartelera;
                string category = (string)categoria.category;
                string username = (string)categoria.username;
                int cantidadVoto = (int)categoria.vote;
                Voto votoActual =
                        new Voto(0,
                                username,
                                cantidadVoto,
                                _manejador.obtenerBanda(band).nombreBan,
                                _manejador.obtenerCategoria(category).categoria,
                                cartelera);
                listaParseVotaciones.Add(votoActual);
            }
            List<votos> listaVotaciones = _convertidor.updateListavotos(listaParseVotaciones.ToArray());
            return listaVotaciones;
        }
    }
}
