using MyConcert_WebService.viewModels;
using MyConcert_WebService.res.resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyConcert_WebService.res.assembler;

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

    }
}
