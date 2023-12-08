using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timer = System.Timers.Timer;


namespace DevBank
{
    public class CompteEpargne : CompteBancaire, ITransactionnel
    {

        private double _tauxInteret;
        private double _tauxFrais;
        private Timer _timer;

        public CompteEpargne() : base()
        {
            _tauxInteret = 0.046;
            _tauxFrais = 0.0335;
            _timer = new Timer(60000);
            _timer.Elapsed += CalculerIntérêt;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void CalculerIntérêt(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Vérifier si la liste de transactions n'est pas vide
            if (_listeTransactions.Count > 0)
            {
                // Obtenir la dernière transaction
                Transaction derniereTransaction = _listeTransactions[_listeTransactions.Count - 1];

                TimeSpan difference = DateTime.Now - derniereTransaction.Date;

                if (difference.TotalMinutes >= 1)
                {
                    // Calculer et ajouter les intérêts
                    double interet = _solde * _tauxInteret;
                    _solde += interet;

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"\n Des intérêts de {interet}€ ont été ajoutés à votre compte.");
                    Console.ResetColor();

                    // Mettre à jour la dernière transaction
                    derniereTransaction = new Transaction("Intérêts", interet, DateTime.Now);
                    _listeTransactions.Add(derniereTransaction);
                }
            }
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