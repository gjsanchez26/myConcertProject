using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConcert.database
{
    class VotosDB
    {
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
