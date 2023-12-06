using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBank
{
    public class CompteEpargne : CompteBancaire, ITransactionnel
    {

        private double _tauxInteret;

        public CompteEpargne() : base()
        {
            _tauxInteret = 0.046;
        }


        public void CalculIntérêt()
        {
            Console.WriteLine(_tauxInteret);
            // Capital x Taux x (nmb jours/365)
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