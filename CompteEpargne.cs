using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBank
{
    public class CompteEpargne : CompteBancaire, ITransactionnel
    {

        private double _tauxInteret;
        private double _tauxFrais;


        public CompteEpargne() : base()
        {
            _tauxInteret = 0.046;
            _tauxFrais = 0.0335;
        }


        public void CalculIntérêt()
        {
            Console.WriteLine(_tauxInteret);
            // Capital x Taux x (nmb jours/365)
        }

        public override bool EffectuerRetrait()
        {
            base.EffectuerRetrait();
            var frais = CalculFrais();

            _solde -= frais;

            Transaction retrait = new Transaction("Frais de retrait", frais, DateTime.Now);
            _listeTransactions.Add(retrait);

            return true;
        }

        public override double CalculFrais()
        {
            var frais = _montantRetrait * _tauxFrais;
            Console.WriteLine($"cette opération va engendrer des frais à hauteur de {frais}€");

            return frais;
        }

        public override void ObtenirPolitique()
        {
            Console.WriteLine($"Le taux d'intérêt est de {_tauxInteret * 100}%");
            Console.ReadLine();
        }
    }
}