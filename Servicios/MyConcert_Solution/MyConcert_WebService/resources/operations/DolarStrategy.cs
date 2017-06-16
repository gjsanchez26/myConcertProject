using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert.resources.operations
{
    /**
     * @class DolarStrategy
     * @brief Objeto que verifica la estrategia
     * de los cien dolares.
     */
    class DolarStrategy
    {
        /**
        * @brief Verifica si los votos de un participante suman cien como resultado.
        * @param pdolars Lista con las votaciones por parte de un usuario. 
        * @return valor booleano que verifica si está correcta la estrategia.
        */
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
            return _flag;
        }

    }
}
