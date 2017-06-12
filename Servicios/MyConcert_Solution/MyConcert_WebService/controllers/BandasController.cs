using MyConcert_WebService.models;
using MyConcert_WebService.res;
using MyConcert_WebService.res.resultados;
using MyConcert_WebService.res.serial;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyConcert_WebService.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BandasController : ApiController
    {
        private BandaModel _model = new BandaModel();
        private SerializerJSON _serial = new SerializerJSON();

        //Obtener todas las bandas disponibles.
        public JObject Get()
        {
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Solicita bandas a base de datos.
            return JObject.FromObject(respuesta); //Retorna lista con bandas.
        }

        //Obtener banda especifica.
        public JObject Get(int pIDBanda)
        {
            ResultadoObjeto respuesta = new ResultadoObjeto();

            return JObject.FromObject(respuesta);
        }

        //Crear banda nueva.
        public JObject Post(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            string datosBanda = peticion.band_data;
            string[] listaMiembros = _serial.getArrayString((JArray) peticion.members);
            string[] listaCanciones = _serial.getArrayString((JArray) peticion.songs);
            int[] listaGenerosMusicales = _serial.getArrayInt((JArray) peticion.genres);

            Respuesta respuesta = new Respuesta();

            respuesta = _model.nuevaBanda(datosBanda, listaMiembros, listaCanciones, listaGenerosMusicales);

            return JObject.FromObject(respuesta);
        }

        //Actualiza banda especifica.
        public JObject Put(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Convierte datos ingresados en Banda.
            //Actualiza en base de datos.
            return JObject.FromObject(respuesta);   //Retorna estado de modificacion.
        }

        //Elimina banda especifica.
        public JObject Delete(JObject pPeticion)
        {
            dynamic peticion = pPeticion;
            ResultadoObjeto respuesta = new ResultadoObjeto();

            //Convierte datos ingresados en Banda.
            //Elimina en base de datos.
            return JObject.FromObject(respuesta);   //Retorna estado de eliminacion.
        }
    }
}
