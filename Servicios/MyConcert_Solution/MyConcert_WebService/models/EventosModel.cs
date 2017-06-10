using MyConcert_WebService.database;
using MyConcert_WebService.res.resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.models
{
    public class EventosModel
    {
        EventosDB _eventosDB = new EventosDB();

        public Respuesta getCarteleras()
        {
            try
            {
                

            }
            catch (Exception e)
            {
                throw (e);
            }

            return new Respuesta();
        }
    }
}
