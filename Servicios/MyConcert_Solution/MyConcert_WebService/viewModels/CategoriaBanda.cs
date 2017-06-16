using Newtonsoft.Json.Linq;
using System;

namespace MyConcert.viewModels
{
    public class CategoriaBanda
    {
        public int _categoriaID;
        public int[] _bandasID;

        public CategoriaBanda(int categoriaID, int[] bandasID)
        {
            _categoriaID = categoriaID;
            _bandasID = bandasID;
        }
    }
}
