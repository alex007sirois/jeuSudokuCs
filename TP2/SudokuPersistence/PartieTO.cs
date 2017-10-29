using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPersistence
{
    public class PartieTO
    {
        private List<Tuple<byte,bool>> cases;
        private long id;
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }


        public List<Tuple<byte, bool>> Cases
        {
            get { return cases; }
            set { cases = value; }
        }
    }
}
