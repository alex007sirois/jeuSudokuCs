using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPersistence
{
    public class GrilleDepartTO
    {
        private List<byte> cases;
        private byte id;

        public byte Id
        {
            get { return id; }
            set { id = value; }
        }


        public List<byte> Cases
        {
            get { return cases; }
            set { cases = value; }
        }
    }
}
