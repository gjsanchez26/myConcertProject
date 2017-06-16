using MyConcert.viewModels;
using MyConcert.res.resultados;
using System;
using System.Collections.Generic;
using MyConcert.res.assembler;
using Newtonsoft.Json.Linq;

namespace MyConcert.models
{
    public class CategoriaModel : AbstractModel
    {
        private ManejadorBD _manejador = new ManejadorBD();
        private FabricaRespuestas _fabricaRespuestas = new FabricaRespuestas();
        private Assembler _convertidor = new Assembler();

        public Respuesta nuevaCategoria(string pNombre)
        {
            Respuesta respuesta = null;
            Categoria nueva = new Categoria(0, pNombre);

            try
            {
                _manejador.añadirCategoria(_convertidor.updatecategorias(nueva));
                respuesta = _fabricaRespuestas.crearRespuesta(true, "Categoria creada satisfactoriamente.");
            } catch(Exception e)
            {
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al crear categoria. Intente de nuevo.");
                throw (e);
            }

            return respuesta;
        }

        public Respuesta getCategorias()
        {
            Respuesta respuesta = null;

            try
            {
                List<categorias> listaCategorias = _manejador.obtenerCategorias();
                JObject[] arregloCategorias = new JObject[listaCategorias.Count];
                int iterator = 0;
                foreach (categorias catActual in listaCategorias)
                {
                    Categoria auxiliar = new Categoria(catActual.PK_categorias,
                                        catActual.categoria);
                    arregloCategorias[iterator] = JObject.FromObject(auxiliar);
                    iterator++;
                }
                respuesta = _fabricaRespuestas.crearRespuesta(true, arregloCategorias);

            } catch(Exception e)
            {
                respuesta = _fabricaRespuestas.crearRespuesta(false, "Error al obtener cartegorias.", e.ToString());
            }

            return respuesta;
        }
    }
}
