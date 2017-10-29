using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace SudokuPersistence
{
   public  class JsonGrilleDepartDAO : JsonDAO, IGrilleDepartDAO
    {
        public JsonGrilleDepartDAO(string repertoire)
            : base(repertoire) { }

        public GrilleDepartTO getTransfertObject(long id)
        {
            StreamReader sr = new StreamReader(this.cheminRepertoire + @"\" + id + ".json", Encoding.Default);

            string json = sr.ReadToEnd();
            GrilleDepartTO GrilleDepart = JsonConvert.DeserializeObject<GrilleDepartTO>(json);

            sr.Dispose();

            return GrilleDepart;
        }

        public List<GrilleDepartTO> getAllTransfertObject()
        {
            List<GrilleDepartTO> GrilleDeparts = new List<GrilleDepartTO>();

            string[] fichiers = Directory.GetFiles(this.cheminRepertoire);

            StreamReader sr;
            string json;

            foreach (string f in fichiers)
            {
                sr = new StreamReader(f, Encoding.Default);
                json = sr.ReadToEnd();

                GrilleDepartTO GrilleDepart = JsonConvert.DeserializeObject<GrilleDepartTO>(json);
                GrilleDeparts.Add(GrilleDepart);

                sr.Dispose();
            }

            return GrilleDeparts;
        }


        void IDAO<GrilleDepartTO>.insertTransfertObject(GrilleDepartTO to)
        {
            throw new NotImplementedException();
        }

        void IDAO<GrilleDepartTO>.updateTransfertObject(GrilleDepartTO to)
        {
            throw new NotImplementedException();
        }

        public void deleteTransfertObject(long id)
        {
            throw new NotImplementedException();
        }
    }
}
