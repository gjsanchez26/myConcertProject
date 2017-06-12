using MyConcert_WebService.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.database
{
    class CategoriasDB
    {
        public void añadirCategoria(Categoria pCategoria)
        {
            categorias categoriaNueva = convertirCategoriaAcategorias(pCategoria);

            using (myconcertEntities context = new myconcertEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        categoriaNueva = context.categorias.Add(categoriaNueva);

                        context.SaveChanges();
                        dbContextTransaction.Commit();

                    }
                    catch (Exception e)
                    {
                        throw (e);
                    }
                }
            }
        }
         
        
        private categorias convertirCategoriaAcategorias(Categoria pCategoria)
        {
            categorias cat = new categorias();
            cat.categoria = pCategoria.Nombre;
            return cat;
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
