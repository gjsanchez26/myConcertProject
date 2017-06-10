using MyConcert_WebService.database;
using MyConcert_WebService.objects;
using System;
using System.Globalization;

namespace MyConcert_WebService.res
{
    public class SerializerJSON
    {
        UtilidadesDB _utilidadesDB = new UtilidadesDB();
        UsuariosDB _usuariosDB = new UsuariosDB();

        public Usuario leerDatosUsuario(string pRol, dynamic pDatosUsuario)
        {
            Usuario nuevoUsuario = null;
            switch (pRol)
            {
                case "fanatico":
                    string stateFanatico = _utilidadesDB.obtenerEstado(1).estado;
                    string country = _utilidadesDB.obtenerPais((int)pDatosUsuario.country).pais;
                    string university = _utilidadesDB.obtenerUniversidad((int)pDatosUsuario.university).nombreUni;
                    string user_type = _usuariosDB.obtenerTipoUsuario(2).tipo;

                    nuevoUsuario = 
                        new Fanatico((string) pDatosUsuario.name,
                                    (string) pDatosUsuario.last_name,
                                    (string) pDatosUsuario.username,
                                    (string) pDatosUsuario.password,
                                    (string) pDatosUsuario.email,
                                    stateFanatico,
                                    DateTime.Today,
                                    (string) pDatosUsuario.profile_pic,
                                    fecha((string) pDatosUsuario.birth_date),
                                    (string) pDatosUsuario.phone,
                                    country,
                                    (string) pDatosUsuario.description,
                                    university,
                                    user_type,
                                    (string) pDatosUsuario.ubication);
                    break;
                case "colaborador":
                    string stateColaborador = _utilidadesDB.obtenerEstado(1).estado;
                    string user_typeColaborador = _usuariosDB.obtenerTipoUsuario(1).tipo;

                    nuevoUsuario = 
                        new Colaborador((string) pDatosUsuario.name,
                                        (string) pDatosUsuario.last_name,
                                        (string) pDatosUsuario.username,
                                        (string) pDatosUsuario.password,
                                        (string) pDatosUsuario.email,
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
    }
}
