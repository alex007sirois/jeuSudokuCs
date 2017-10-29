using SudokuPersistence;
using System;
using System.Collections.Generic;

namespace Sudoku.Metier
{
    public class JeuSudoku
    {
        private bool partieTerminee;
        private Grille grille;
        private PartieTO partieSauvee;
        private IGrilleDepartDAO daoGrilleDepart;
        private IPartieDAO daoPartie;

        public JeuSudoku()
        {
            this.partieTerminee = true;
            daoGrilleDepart = new JsonGrilleDepartDAO("grilles");
            daoPartie = new JsonPartieDAO("parties");
        }


        public void nouvellePartie()
        {
            List<GrilleDepartTO> grillesDepart;

            grillesDepart = daoGrilleDepart.getAllTransfertObject();

            byte random = (byte)((DateTime.Now.Ticks % grillesDepart.Count));
            

            grille = new Grille(grillesDepart[random].Cases);

            this.partieTerminee = false;
        }

        public bool sauverPartie()
        {
            if (grille != null && !partieTerminee)
            {
                if (this.partieSauvee == null)
                {
                    partieSauvee = new PartieTO();

                    partieSauvee.Date = DateTime.Now;
                    partieSauvee.Cases = grille.getTuplesCases();

                    daoPartie.insertTransfertObject(partieSauvee);
                }
                else
                {
                    partieSauvee.Date = DateTime.Now;
                    partieSauvee.Cases = grille.getTuplesCases();

                    daoPartie.updateTransfertObject(partieSauvee);
                }
                return true;
            }
            return false;
        }

        public void reprendrePartie(long id)
        {
            this.partieSauvee = daoPartie.getTransfertObject(id);
            grille = new Grille(partieSauvee.Cases);

            this.partieTerminee = false;
        }

        public List<Tuple<long,string>> obtenirPartiesSauvegardees()
        {
            List<Tuple<long, string>> list = new List<Tuple<long, string>>();

            List<PartieTO> parties = daoPartie.getAllTransfertObject();

            foreach(PartieTO p in parties)
            {
                list.Add(new Tuple<long, string>(p.Id, p.Date.ToString()));
            }

            return list;
        }


        public void modifierCase(byte i, byte j, byte chiffre)
        {
            if (!this.partieTerminee)
                grille.modifierCase(i,j,chiffre);
        }


        public bool validerGrille()
        {
            if (!this.partieTerminee)
                this.partieTerminee = grille.estValide();

            if (this.partieTerminee && partieSauvee != null)
            {
                daoPartie.deleteTransfertObject(partieSauvee.Id);
                this.partieSauvee = null;
            }
            
            return this.partieTerminee;
        }


        public void resoudre(IObserverResolution observer)
        {
            if (!this.partieTerminee)
            {
                grille.resoudre(observer);
                this.partieTerminee = true;
                
                if (partieSauvee != null)
                {
                    daoPartie.deleteTransfertObject(partieSauvee.Id);
                    this.partieSauvee = null;
                }
            }
        }


        public Grille Grille
        {
            get { return this.grille; }
        }


        public bool PartieTerminee
        {
            get { return this.partieTerminee; }
        }
    }
}
