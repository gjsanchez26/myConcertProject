using System.Collections.Generic;

/**
 * @namespace MyConcert.resources.chef
 * @brief Almacena las clases relacionadas al
 * algoritmo del chef para la recomendacion de 
 * una banda. 
 */
namespace MyConcert.resources.operations
{
    /**
     * @class CommentsTable
     * @brief Objeto que contiene la tabla de porcentaje
     * del numero de comentarios que tiene una banda.
     */
    class CommentsTable
    {
        List<int> _commentsTable;
        
        //Constructor
        public CommentsTable()
        {
            _commentsTable = new List<int>();
            fillTable();
        }

        /**
         * @brief Llena la tabla de porcentajes con valores
         * por defecto.
         */
        private void fillTable()
        {
            _commentsTable.Add(0);
            _commentsTable.Add(5);
            _commentsTable.Add(5);
            _commentsTable.Add(5);
            _commentsTable.Add(10);
            _commentsTable.Add(10);
            _commentsTable.Add(15);
            _commentsTable.Add(15);
            _commentsTable.Add(20);
            _commentsTable.Add(20);
            _commentsTable.Add(20);
            _commentsTable.Add(25);
            _commentsTable.Add(25);
            _commentsTable.Add(30);
            _commentsTable.Add(30);
            _commentsTable.Add(30);
            _commentsTable.Add(30);
            _commentsTable.Add(35);
            _commentsTable.Add(35);
            _commentsTable.Add(40);
            _commentsTable.Add(40);
            _commentsTable.Add(40);
            _commentsTable.Add(45);
            _commentsTable.Add(45);
            _commentsTable.Add(50);
            _commentsTable.Add(50);
            _commentsTable.Add(50);
        }

        /**
         * @brief Obtiene el porcentaje específico en una tabla
         * @param pindex Indice para acceder al dato de la tabla 
         * @return El indice requerido o bien, un 0 si no está en el rango de la tabla
         */
        public int getCommentPercentage(int pindex)
        {
            return (pindex<25) ? _commentsTable[pindex] : 0;            
        }
    }
}
