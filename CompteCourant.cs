using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBank
{
    public class CompteCourant : CompteBancaire, ITransactionnel
    {
        private double _decouvertAutorise;

        public CompteCourant() : base()
        {
            _decouvertAutorise = -500;
        }

        public void CalculFrais()
        {
            if (getSolde() < _decouvertAutorise){

            }
            else
            {


            }
        }

        public void ObtenirPolitique()
        {
            throw new System.NotImplementedException(); 
        }
    }
}