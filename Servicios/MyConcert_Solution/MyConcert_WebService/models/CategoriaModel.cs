using MyConcert_WebService.viewModels;
using MyConcert_WebService.res.resultados;
using System;
using System.Collections.Generic;
using MyConcert_WebService.res.assembler;
using Newtonsoft.Json.Linq;

namespace MyConcert_WebService.models
{
    public class CategoriaModel
    {
        private ManejadorBD _manejador = new ManejadorBD();
        private FabricaRespuestas _creador = new FabricaRespuestas();
        private Assembler _convertidor = new Assembler();

        public Respuesta nuevaCategoria(string pNombre)
        {
            Respuesta respuesta = null;
            Categoria nueva = new Categoria(0, pNombre);

            try
            {
                _manejador.añadirCategoria(_convertidor.updatecategorias(nueva));
                respuesta = _creador.crearRespuesta(true, "Categoria creada satisfactoriamente.");
            } catch(Exception e)
            {
                respuesta = _creador.crearRespuesta(false, "Error al crear categoria. Intente de nuevo.");
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
                respuesta = _creador.crearRespuesta(true, arregloCategorias);

            } catch(Exception e)
            {
                respuesta = _creador.crearRespuesta(false, "Error al obtener cartegorias.", e.ToString());
            }

            return respuesta;
        }
    }
}
