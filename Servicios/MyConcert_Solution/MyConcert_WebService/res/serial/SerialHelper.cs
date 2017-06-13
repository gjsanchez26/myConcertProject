using Newtonsoft.Json.Linq;
using System;

namespace MyConcert_WebService.res.serial
{
    public class SerialHelper
    {
        public int[] getArrayInt(JArray pArray)
        {
            dynamic arrayInt = pArray;
            int[] lista = new int[pArray.Count];
            int iterator = 0;

            foreach (dynamic i in arrayInt)
            {
                lista[iterator] = i;
                iterator++;
            }

            return lista;
        }

        public DateTime fecha(string pFecha)
        {
            DateTime dt = Convert.ToDateTime(pFecha);

            return dt;
        }
    }
}
