using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConcert_WebService.res.chef
{
    class CommentsTable
    {
        List<int> _commentsTable;

        public CommentsTable()
        {
            _commentsTable = new List<int>();
            fillTable();
        }

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

        public int getCommentPercentage(int pindex)
        {
            return (pindex<25) ? _commentsTable[pindex] : 0;            
        }
    }
}
