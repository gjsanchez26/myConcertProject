using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.resources.security
{
    public class SimpleOperations
    {
        /**
        * @brief Verifica si la cantidad de items es la correcta
        * @param pitems Numero de items actual.
        * @param pamount Numero indicado de items.
        * @return Falso o verdadero.
        */
        public bool isAmountItems(int pitems, int pamount)
        {
            return (pitems == pamount) ? true : false;            
        }

        /**
        * @brief Calcula el valor absoluto.
        * @param px Numero al que se desea obtener el valor absoluto.
        * @return El resultado del valor absoluto.
        */
        public double double_abs(double px)
        {
            if (px < 0)
            {
                px *= -1;
            }
            return px;
        }
    }
}
