using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.database
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
    }
}
