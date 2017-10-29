using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SudokuPersistence
{
    public abstract class JsonDAO
    {
        protected string cheminRepertoire;

        protected JsonDAO(string cheminRepertoire)
        {
            this.cheminRepertoire = cheminRepertoire;

            if (!Directory.Exists(cheminRepertoire))
                Directory.CreateDirectory(cheminRepertoire);
        }
    }
}
