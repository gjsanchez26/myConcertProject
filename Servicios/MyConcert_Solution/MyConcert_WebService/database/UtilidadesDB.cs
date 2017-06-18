using MyConcert.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert.database
{
    class UtilidadesDB
    {
        //OBTENER LISTA DE OBJETOS
        public List<generos> obtenerGeneros()
        {
            List<generos> gen = null;
            
            
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {
                    gen = context.generos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
                
            }

            return gen;
        }

        public List<paises> obtenerPaises()
        {
            List<paises> lista = null;
            

            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    lista = context.paises.ToList();

                }
                
            }
            catch (Exception ex)
            {
                throw (ex);
                
            }
            return lista;
        }

        public List<universidades> obtenerUniversidades()
        {
            List<universidades> lista = null;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    lista = context.universidades.ToList();

                }
                
            }
            catch (Exception ex)
            {
                throw (ex);
                
            }
            return lista;
        }
        //OBTENER 1 OBJETO

        public universidades obtenerUniversidad(string universidad)
        {
            universidades obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.universidades.FirstOrDefault(g => g.nombreUni == universidad);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }
        public universidades obtenerUniversidad(int PK_universidad)
        {
            universidades obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.universidades.FirstOrDefault(g => g.PK_universidades == PK_universidad);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }

        public paises obtenerPais(string pais)
        {
            paises obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.paises.FirstOrDefault(g => g.pais == pais);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }
        public paises obtenerPais(int PK_pais)
        {
            paises obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.paises.FirstOrDefault(g => g.PK_paises == PK_pais);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }

        public estados obtenerEstado(int PK_estado)
        {
            estados obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.estados.FirstOrDefault(r => r.PK_estados == PK_estado);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }

        public estados obtenerEstado(string estado)
        {
            estados obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.estados.FirstOrDefault(r => r.estado == estado);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obj;
        }
        public generos obtenerGenero(int PK_genero)
        {
            generos ge = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    ge = context.generos.FirstOrDefault(g => g.PK_generos == PK_genero);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ge;
        }
    }
}
