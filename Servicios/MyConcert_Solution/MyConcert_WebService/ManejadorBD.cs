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
            try
            {
                
                using (myconcertEntities context = new myconcertEntities())
                {
                    us = context.usuarios.FirstOrDefault(r => r.username == username);
                }
                
            }
            catch(Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return us;
        }

        public void añadirUsuario (usuarios us)
        {
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    context.usuarios.Add(us);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
        }
    }
}
