using MyConcert_WebService.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.database
{
    class CategoriasDB
    {
        public void añadirCategoria(categorias pCategoria)
        {

            using (myconcertEntities context = new myconcertEntities())
            {
                
                    try
                    {
                        context.categorias.Add(pCategoria);

                        context.SaveChanges();

                    }
                    catch (Exception e)
                    {
                        throw (e);
                    }
            }
        }

        public categorias obtenerCategoria(int PK_categoria)
        {
            categorias obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.categorias.FirstOrDefault(r => r.PK_categorias == PK_categoria);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public List<categorias> obtenerCategorias()
        {
            List<categorias> obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.categorias.ToList();
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }
    }
}
