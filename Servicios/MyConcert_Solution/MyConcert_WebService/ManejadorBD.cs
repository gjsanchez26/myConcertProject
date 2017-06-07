using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService
{
    public class ManejadorBD
    {
        public usuarios obtenerUsuario(string username)
        {
            usuarios us = null;
            using (myconcertEntities context = new myconcertEntities())
            {
                us = context.usuarios.FirstOrDefault(r=> r.username==username);
            }
            return us;
        }
    }
}
