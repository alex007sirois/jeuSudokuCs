using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPersistence
{
    class SudokuPersistenceException:Exception
    {
        internal SudokuPersistenceException(string msg) : base(msg) { }
    }
}
