using MyConcert_WebService.viewModels;
using MyConcert_WebService.res.resultados;
using System;
using MyConcert_WebService.res.assembler;
using Newtonsoft.Json.Linq;
using MyConcert_WebService.res.serial;

namespace MyConcert_WebService.models
{
    public class BandaModel
    {
        private ManejadorBD _manejador;
        private FabricaRespuestas _creador;
        private Assembler _convertidor;
        private SerialHelper _serial;

        public BandaModel()
        {
            _manejador = new ManejadorBD();
            _creador = new FabricaRespuestas();
            _convertidor = new Assembler();
            _serial = new SerialHelper();
        }

        public Respuesta nuevaBanda(string pNombre, JArray pMiembros,
                                JArray pCanciones, JArray pGeneros)
        {
            Respuesta respuesta = null;
            Banda banda = new Banda(pNombre, _manejador.obtenerEstado(1).estado);
            string[] miembros = _serial.getArrayString(pMiembros);
            string[] canciones = _serial.getArrayString(pCanciones);
            int[] generos = _serial.getArrayInt(pGeneros);

            try
            {
                _manejador.añadirBanda(_convertidor.updatebandas(banda), 
                                       _convertidor.updateintegrantes(miembros),
                                       _convertidor.updatecanciones(canciones),
                                       _convertidor.updateListaGeneros(generos));
                respuesta = _creador.crearRespuesta(true, "Banda registrada correctamente.");
            } catch(Exception e)
            {
                respuesta = _creador.crearRespuesta(false, "Fallo al ingresar banda o banda ya esxistente.");
                //respuesta = _creador.crearRespuesta(false, e.ToString());
            }

            return respuesta;
        }
    }
}
