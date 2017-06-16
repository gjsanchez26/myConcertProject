using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConcert.database
{
    class VotosDB
    {
        public votos obtenerVoto(int PK_voto)
        {
            votos obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.votos.FirstOrDefault(g => g.PK_votos == PK_voto);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public List<votos> obtenerVotos(int PK_categoria)
        {
            List<votos> obj = null;
            try
            {

                using (myconcertEntities context = new myconcertEntities())
                {
                    obj = context.votos.Where(v=> v.FK_VOTOS_CATEGORIAS== PK_categoria).ToList();
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.ToString());
            }
            return obj;
        }

        public void añadirVotos(List<votos> votaciones)
        {
            using (myconcertEntities context = new myconcertEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (votos i in votaciones) {
                            context.votos.Add(i);
                        }
                        
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw (ex);
                    }
                }
            }
        }

        public int obtenerCantidadVotos(int cartelera, int categoria, int banda)
        {
            int votos = 0;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    votos = (int)context.votos.Where(r => (r.FK_VOTOS_EVENTOS == cartelera)
                                                    && (r.FK_VOTOS_CATEGORIAS == categoria)
                                                    && (r.FK_VOTOS_BANDAS == banda))
                                                    .Sum(r => r.valor);

                }
            }
            catch (Exception )
            {
                votos = 0;
            }
            return votos;
        }

        public int obtenerCantidadVotos(int cartelera, int banda)
        {
            int votos = 0;
            try
            {
                using (myconcertEntities context = new myconcertEntities())
                {

                    votos = (int)context.votos.Where(r => (r.FK_VOTOS_EVENTOS == cartelera)
                                                    && (r.FK_VOTOS_BANDAS == banda))
                                                    .Sum(r => r.valor);

                }
            }
            catch (Exception )
            {
                votos = 0;
            }
            return votos;
        }
    }
}
