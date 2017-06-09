using MyConcert_WebService.objects;
using System;

namespace MyConcert_WebService.res
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
                    string stateFanatico = _manejador.obtenerEstado(pDatosUsuario.state).estado;
                    string country = _manejador.obtenerPais(pDatosUsuario.country).pais;
                    nuevoUsuario = 
                        new Fanatico(pDatosUsuario.name,
                                    pDatosUsuario.last_name,
                                    pDatosUsuario.username,
                                    pDatosUsuario.password,
                                    pDatosUsuario.email,
                                    stateFanatico,
                                    DateTime.Today,
                                    pDatosUsuario.profile_pic,
                                    pDatosUsuario.birth_date,
                                    pDatosUsuario.phone,
                                    country,
                                    pDatosUsuario.description);
                    break;
                case "colaborador":
                    string stateColaborador = _manejador.obtenerEstado(pDatosUsuario.state).estado;
                    nuevoUsuario = 
                        new Colaborador(pDatosUsuario.name,
                                        pDatosUsuario.last_name,
                                        pDatosUsuario.username,
                                        pDatosUsuario.password,
                                        pDatosUsuario.email,
                                        stateColaborador,
                                        DateTime.Today,
                                        pDatosUsuario.profile_pic);
                    break;
                default:
                    break;
            }

            return nuevoUsuario;
        }
    }
}
