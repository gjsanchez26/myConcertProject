using MyConcert_WebService.viewModels;
using MyConcert_WebService.res.resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.models
{
    public class CategoriaModel
    {
        private ManejadorBD _manejador = new ManejadorBD();
        private FabricaRespuestas _creador = new FabricaRespuestas();

        public Respuesta nuevaCategoria(string pNombre)
        {
            Respuesta respuesta = null;
            Categoria nueva = new Categoria(0, pNombre);

            try
            {
                //_manejador.añadirCategoria(nueva);
                respuesta = _creador.crearRespuesta(true, "Categoria creada satisfactoriamente.");
            } catch(Exception e)
            {
                respuesta = _creador.crearRespuesta(false, "Error al crear categoria. Intente de nuevo.");
                throw (e);
            }

            return respuesta;
        }

    }
}
