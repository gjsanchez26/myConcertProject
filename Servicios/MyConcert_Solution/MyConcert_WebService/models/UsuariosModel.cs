using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.models
{
    public class UsuariosModel
    {
        private ManejadorBD _manejador;

        public UsuariosModel()
        {
            _manejador = new ManejadorBD();
        }

        public usuarios getUsuarioPorNombreDeUsuario(string pUsuario)
        {
            usuarios user = _manejador.obtenerUsuario(pUsuario);
            return user;
        }
    }
}
