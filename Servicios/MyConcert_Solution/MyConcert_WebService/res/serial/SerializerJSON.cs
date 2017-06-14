using MyConcert_WebService.viewModels;
using Newtonsoft.Json.Linq;
using System;

namespace MyConcert_WebService.res.serial
{
    public class SerializerJSON
    {
        ManejadorBD _manejador = new ManejadorBD();

        public Usuario leerDatosUsuario(string pRol, dynamic pDatosUsuario)
        {
            Usuario nuevoUsuario = null;
            switch (pRol)
            {
                case "fanatico":
                    string stateFanatico = _manejador.obtenerEstado(1).estado;
                    string country = _manejador.obtenerPais((int)pDatosUsuario.country).pais;
                    string university = _manejador.obtenerUniversidad((int)pDatosUsuario.university).nombreUni;
                    string user_type = _manejador.obtenerTipoUsuario(2).tipo;

                    nuevoUsuario =
                        new Fanatico((string)pDatosUsuario.name,
                                    (string)pDatosUsuario.last_name,
                                    (string)pDatosUsuario.username,
                                    (string)pDatosUsuario.password,
                                    (string)pDatosUsuario.email,
                                    stateFanatico,
                                    DateTime.Today,
                                    (string)pDatosUsuario.profile_pic,
                                    fecha((string)pDatosUsuario.birth_date),
                                    (string)pDatosUsuario.phone,
                                    country,
                                    (string)pDatosUsuario.description,
                                    university,
                                    user_type,
                                    (string)pDatosUsuario.ubication);
                    break;
                case "colaborador":
                    string stateColaborador = _manejador.obtenerEstado(1).estado;
                    string user_typeColaborador = _manejador.obtenerTipoUsuario(1).tipo;

                    nuevoUsuario =
                        new Colaborador((string)pDatosUsuario.name,
                                        (string)pDatosUsuario.last_name,
                                        (string)pDatosUsuario.username,
                                        (string)pDatosUsuario.password,
                                        (string)pDatosUsuario.email,
                                        stateColaborador,
                                        DateTime.Today,
                                        user_typeColaborador);
                    break;
                default:
                    break;
            }

            return nuevoUsuario;
        }

        private DateTime fecha(string pFecha)
        {
            DateTime dt = Convert.ToDateTime(pFecha);

            return dt;
        }

        public Banda leerDatosBanda(dynamic pDatosBanda)
        {
            Banda bandaNueva =
                new Banda(pDatosBanda.nombre,
                          _manejador.obtenerEstado(1).estado);

            return bandaNueva;

        }

        public int[] getArrayInt(JArray pArray)
        {
            dynamic arrayInt = pArray;
            int[] lista = new int[pArray.Count];
            int iterator = 0;

            foreach (dynamic i in arrayInt)
            {
                lista[iterator] = i;
                iterator++;
            }

            return lista;
        }

        public string[] getArrayString(JArray pArray)
        {
            dynamic arrayString = pArray;
            string[] lista = new string[pArray.Count];
            int iterator = 0;

            foreach (dynamic i in arrayString)
            {
                lista[iterator] = i;
                iterator++;
            }

            return lista;
        }
    }
}
