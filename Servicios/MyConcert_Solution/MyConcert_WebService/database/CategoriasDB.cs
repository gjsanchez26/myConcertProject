﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConcert.database
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

        public categorias obtenerCategoria(string categoria)
        {
            categorias obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.categorias.FirstOrDefault(r => r.categoria == categoria);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }

        public categorias obtenerCategoria(int categoria)
        {
            categorias obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.categorias.FirstOrDefault(r => r.PK_categorias == categoria);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
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
                throw (ex);
            }
            return obj;
        }

        public List<categorias> obtenerCategoriasEvento(int evento)
        {
            List<categorias> obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                     obj = context.categorias.Join(context.categoriasevento,
                                                   c => c.PK_categorias,
                                                   ce => ce.FK_CATEGORIASEVENTO_CATEGORIAS,
                                                   (c, ce) => new { c, ce })
                                                   .Where(w => w.ce.FK_CATEGORIASEVENTO_EVENTOS == evento)
                                                   .Select(s => s.c).OrderBy(g=>g.PK_categorias).ToList();


                   
                }


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }

        public List<bandas> obtenerBandasCategoria(int categoria, int evento) {
            List<bandas> obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.bandas.Join(context.categoriasevento,
                                                   b => b.PK_bandas,
                                                   ce => ce.FK_CATEGORIASEVENTO_CATEGORIAS,
                                                   (b, ce) => new { b, ce })
                                                   .Where(w => w.ce.FK_CATEGORIASEVENTO_CATEGORIAS == categoria && w.ce.FK_CATEGORIASEVENTO_EVENTOS==evento )
                                                   .Select(s => s.b).ToList(); ;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }
    }
}
