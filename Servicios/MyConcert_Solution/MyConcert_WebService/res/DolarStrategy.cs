using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.res
{
    class DolarStrategy
    {

        /**
         * Verifica si los votos de un participante
         * suman cien como resultado
         * */
        public bool checkDolars(List<int> pdolars)
        {
            bool _flag = false;
            int res = 0;
            for (int i = 0; i < pdolars.Count; i++)
            {
                res += pdolars[i];
            }
            if (res == 100)
            {
                _flag = true;
            }
            Console.WriteLine("Resultado dólares: " + res);
            return _flag;
        }

    }
}
