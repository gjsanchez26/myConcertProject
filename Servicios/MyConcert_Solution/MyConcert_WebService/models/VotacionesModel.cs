using MyConcert.resources.assembler;
using MyConcert.resources.operations;
using MyConcert.resources.results;
using MyConcert.viewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MyConcert.models
{
    /**
     * Votaciones Model
     * */
    public class VotacionesModel : AbstractModel
    {
        //Inicializa variables locales
        public VotacionesModel()
        {
            _manejador = new FacadeDB();
            _convertidor = new Assembler();
            _fabricaRespuestas = new FabricaRespuestas();
        }

        //Crear votaciones 
        public Respuesta nuevaVotacion(JArray pCategorias)
        {
            Respuesta respuesta = null;
            List<votos> listaVotaciones = null;

            try
            {
                //Organiza la informacion de votos
                listaVotaciones = generarVotos(pCategorias);

                //Comprobar que el fanatico no haya votado previamente en cartelera
                votos votoActual = listaVotaciones[0];
                usuarios userActual = _manejador.obtenerUsuario(votoActual.FK_VOTOS_USUARIOS);
                eventos eventoActual = _manejador.obtenerEvento(votoActual.FK_VOTOS_EVENTOS);
                if (_manejador.comprobarUsuarioVotacion(userActual, eventoActual))
                    return _fabricaRespuestas.crearRespuesta(false, "El usuario "+userActual.username+" ya había realizado su única votación.");

                List<List<votos>> matrizVotos = mapearVotacionesPorCategoria(listaVotaciones);
                
                if (!comprobarEstrategiaCienDolares(matrizVotos))
                {
                    //Retorna mensaje de error por no cumplir con la estrategia de los cien dolares 
                    respuesta = _fabricaRespuestas.crearRespuesta(false, "Error: Es necesario completar los cien créditos en todas las categorías. Por favor intente de nuevo.");
                }
            }
            catch (Exception)
            {
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al interpretar votaciones. Por favor intente de nuevo.");
                //respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al interpretar votaciones.", e.ToString());
            }

            try
            {
                _manejador.añadirVotos(listaVotaciones);
                respuesta = _fabricaRespuestas.crearRespuesta(true, "Votacion procesada satisfactoriamente.");
            }
            catch (Exception)
            {
                //Retorna mensaje de error
                respuesta = _fabricaRespuestas.crearRespuesta(false,  "Error al procesar votacion. Por favor intente de nuevo.");
                //respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al procesar votacion. Por favor intente de nuevo.", e.ToString());
            }

            //Retorna respuesta respectiva
            return respuesta;
        }

        //Mapear las votaciones en una matriz de categorias
        public List<List<votos>> mapearVotacionesPorCategoria(List<votos> listaVotaciones)
        {
            //Crea matriz de respuesta
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
                            //Si categorias son iguales las agrupa en la misma lista
                            lista.Add(votoARevisar);
                            agregado = true;
                            break;
                        }
                    }
                }
                if (!agregado)
                {
                    //Agrega lista de votaciones a matriz de categorias
                    List<votos> nuevaLista = new List<votos>();
                    nuevaLista.Add(votoARevisar);
                    matrizVotos.Add(nuevaLista);
                }
            }

            //Retorna matriz de categorias
            return matrizVotos;
        }

        //Interpretar votaciones desde JSON Array
        private List<votos> generarVotos(JArray pCategorias)
        {
            //Lee informacion recibida
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

            //Convierte a dato almacenable
            List<votos> listaVotaciones = _convertidor.updateListavotos(listaParseVotaciones.ToArray());
            return listaVotaciones;
        }

        //Comprobar que se cumpla con la estrategia de los cien dólares
        public bool comprobarEstrategiaCienDolares(List<List<votos>> matrizVotos)
        {
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
                    //Estrategia falla
                    return false;
                }
            }

            //Estrategia cumplida 
            return true;
        }
    }
}
