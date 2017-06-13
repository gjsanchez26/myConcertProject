using MyConcert_WebService.viewModels;
using MyConcert_WebService.res.resultados;
using System;
using MyConcert_WebService.res.assembler;

namespace MyConcert_WebService.models
{
    public class BandaModel
    {
        private ManejadorBD _manejador;
        private FabricaRespuestas _creador;
        private Assembler _convertidor;

        public BandaModel()
        {
            _manejador = new ManejadorBD();
            _creador = new FabricaRespuestas();
            _convertidor = new Assembler();
        }

        public Respuesta nuevaBanda(string pNombre, string[] pMiembros,
                                string[] pCanciones, int[] pGeneros)
        {
            Respuesta respuesta = null;
            Banda banda = new Banda(pNombre, _manejador.obtenerEstado(1).estado);

            try
            {
                _manejador.añadirBanda(_convertidor.updatebandas(banda), 
                                       _convertidor.updateintegrantes(pMiembros),
                                       _convertidor.updatecanciones(pCanciones),
                                       _convertidor.updateListaGeneros(pGeneros));
                respuesta = _creador.crearRespuesta(true, "Banda registrada correctamente.");
            } catch(Exception e)
            {
                //respuesta = _creador.crearRespuesta(false, "Fallo al ingresar banda o banda ya esxistente.");
                respuesta = _creador.crearRespuesta(false, e.ToString());
            }

            return respuesta;
        }
    }
}
