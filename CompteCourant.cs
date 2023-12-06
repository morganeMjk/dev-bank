using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBank
{
    public class CompteCourant : CompteBancaire, ITransactionnel
    {
        private double _tauxInteret;

        public CompteCourant() : base()
        {
        }
        
        public int DécouvertAutorisé
        {
            get => default;
            set
            {
            }
        }

        public void CalculFrais()
        {
            throw new System.NotImplementedException();
        }

        public void ObtenirPolitique()
        {
            throw new System.NotImplementedException();
        }
    }
}