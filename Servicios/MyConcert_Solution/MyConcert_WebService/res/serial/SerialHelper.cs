using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;

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

        public string[] getArrayString(JArray pArray)
        {
            dynamic arrayString = pArray;
            string[] lista = new string[pArray.Count];
            int iterator = 0;

            foreach (dynamic i in arrayString)
            {
                lista[iterator] = (string) i;
                iterator++;
            }
            return lista;
        }

        public DateTime fecha(string pFecha)
        {
            DateTime d = DateTime.ParseExact(pFecha.Substring(0, 24),
                              "ddd MMM d yyyy HH:mm:ss",
                              CultureInfo.InvariantCulture);

            return d;
        }

        public string[] agruparGeneros(List<generos> pLista)
        {
            string[] generosString = new string[pLista.Count];
            int iterator = 0;
            foreach (generos gen in pLista)
            {
                generosString[iterator] = gen.genero;
                iterator++;
            }
            return generosString;
        }

        public string[] agruparMiembros(List<integrantes> pLista)
        {
            string[] miembrosString = new string[pLista.Count];
            int iterator = 0;
            foreach (integrantes miembro in pLista)
            {
                miembrosString[iterator] = miembro.nombreInt;
                iterator++;
            }
            return miembrosString;
        }
    }
}
