using MyConcert_WebService.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.database
{
    class UtilidadesDB
    {

        private Universidad convertiruniversidadesAUniversidad(universidades pUniversidad )
        {
            
            int id = pUniversidad.PK_universidades;
            string nombre = obtenerUniversidad(id).nombreUni;
            Universidad uni = new Universidad(id,nombre);
            return uni;


        }
        //OBTENER LISTA DE OBJETOS

        private Pais convertirpaisesAPais(paises pPais)
        {
            int id = pPais.PK_paises;
            string nombre = obtenerPais(id).pais;
            Pais pais = new Pais(id,nombre);
            return pais;
        }
        
        private GeneroMusical convertirgenerosAGenero(generos pGenero)
        {
            int id = pGenero.PK_generos;
            string nombre = obtenerGenero(id).genero;
            GeneroMusical gene = new GeneroMusical(id, nombre);
            return gene;
        }
        public GeneroMusical[] obtenerGeneros()
        {
            List<generos> gen = null;
            GeneroMusical[] arGenMus=null;


            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    gen = context.generos.ToList();

                }
                arGenMus = new GeneroMusical[gen.Count];
                int c = 0;
                foreach (generos i in gen)
                {
                    arGenMus[c] = convertirgenerosAGenero(i);
                    c++;
                }


            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return arGenMus;
        }

        public Pais[] obtenerPaises()
        {
            List<paises> lista = null;
            Pais[] arreglo = null;

            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    lista = context.paises.ToList();

                }
                arreglo = new Pais[lista.Count];
                int c = 0;
                foreach (paises i in lista)
                {
                    arreglo[c] = convertirpaisesAPais(i);
                    c++;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return arreglo;
        }

        public Universidad[] obtenerUniversidades()
        {
            List<universidades> lista = null;
            Universidad[] arreglo = null;

            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    lista = context.universidades.ToList();

                }
                arreglo = new Universidad[lista.Count];
                int c = 0;
                foreach (universidades i in lista)
                {
                    arreglo[c] = convertiruniversidadesAUniversidad(i);
                    c++;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return arreglo;
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
                Console.Write(ex.InnerException.ToString());
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
                Console.Write(ex.InnerException.ToString());
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
                Console.Write(ex.InnerException.ToString());
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
                Console.Write(ex.InnerException.ToString());
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
                Console.Write(ex.InnerException.ToString());
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
                Console.Write(ex.InnerException.ToString());
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
                Console.Write(ex.InnerException.ToString());
            }
            return ge;
        }
        public generos obtenerGenero(string genero)
        {
            generos ge = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    ge = context.generos.FirstOrDefault(g => g.genero == genero);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return ge;
        }
    }

}
