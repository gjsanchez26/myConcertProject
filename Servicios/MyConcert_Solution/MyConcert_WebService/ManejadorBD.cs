using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public List<bandas> obtenerBandasNoCartelera(eventos cartelera)
        {
            List<bandas> bandasCarte=null;
            string query = @"SELECT B.PK_bandas, B.nombreBan, B.FK_BANDAS_ESTADOS " +
                            "FROM bandas as B INNER JOIN categoriasevento as CE " +
                            "on CE.FK_CATEGORIASEVENTO_BANDAS = B.PK_bandas " +
                            "where CE.FK_CATEGORIASEVENTO_EVENTOS != ?PK_eventos";

            MySqlParameter[] parameters = {
            new MySqlParameter("?PK_eventos", cartelera.PK_eventos)
        };
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {
                  
                    bandasCarte = context.bandas.SqlQuery(query, parameters).ToList<bandas>();
                    
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return bandasCarte;
        }
        
        public int getCantidadComentarios (bandas banda)
        {
            int cantidadComen = 0;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    cantidadComen = context.comentarios.Count(r => r.FK_COMENTARIOS_BANDAS == banda.PK_bandas);

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return cantidadComen;
        }
        
        public float getCalificacion(bandas banda)
        {
            float calificacion = 0;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    calificacion = (float)context.comentarios.Where(r=> r.FK_COMENTARIOS_BANDAS==banda.PK_bandas).Average(r=>r.calificacion);

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return calificacion;
        } 
    }
}
