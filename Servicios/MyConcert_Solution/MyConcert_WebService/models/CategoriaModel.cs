using MyConcert.viewModels;
using MyConcert.resources.results;
using System;
using System.Collections.Generic;
using MyConcert.resources.assembler;
using Newtonsoft.Json.Linq;

namespace MyConcert.models
{
    public class CategoriaModel : AbstractModel
    {
        public CategoriaModel()
        {
            _manejador = new FacadeDB();
            _convertidor = new Assembler();
            _fabricaRespuestas = new FabricaRespuestas();
        }

        //Registrar nueva categoria
        public Respuesta nuevaCategoria(string pNombre)
        {
            Respuesta respuesta = null;
            Categoria nueva = new Categoria(0, pNombre);

            try
            {
                //Almacena categoria
                _manejador.añadirCategoria(_convertidor.updatecategorias(nueva));
                //Retorna respuesta exitosa
                respuesta = _fabricaRespuestas.crearRespuesta(true, "Categoria creada satisfactoriamente.");
            } catch(Exception e)
            {
                //Retorna respuesta de error
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al crear categoria. Intente de nuevo.");
                throw (e);
            }

            return respuesta;
        }

        //Obtener categorias
        public Respuesta getCategorias()
        {
            Respuesta respuesta = null;

            try
            {
                List<categorias> listaCategorias = _manejador.obtenerCategorias(); //Solicita categorias
                JObject[] arregloCategorias = new JObject[listaCategorias.Count];
                int iterator = 0;
                //Organiza informacion para envio
                foreach (categorias catActual in listaCategorias)
                {
                    Categoria auxiliar = new Categoria(catActual.PK_categorias,
                                        catActual.categoria);
                    arregloCategorias[iterator] = JObject.FromObject(auxiliar);
                    iterator++;
                }
                //Retorna respuesta exitosa
                respuesta = _fabricaRespuestas.crearRespuesta(true, arregloCategorias);

            } catch(Exception)
            {
                //Retorna respuesta de error
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al obtener cartegorias.");
                //respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al obtener cartegorias.", e.ToString());
            }

            return respuesta;
        }
    }
}
