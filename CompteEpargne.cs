using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timer = System.Timers.Timer;


namespace DevBank
{
    public class CompteEpargne : CompteBancaire, ITransactionnel
    {
        private const double SOLDE_INITIAL_EPARGNE = 50;

        private double _tauxInteret;
        private double _tauxFrais;
        private Timer _timer;

        public CompteEpargne() : base()
        {
            _solde = SOLDE_INITIAL_EPARGNE;
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
            while (true)
            {
                try
                {
                    Console.WriteLine("Veuillez saisir le montant de votre retrait :");
                    string montant = Console.ReadLine();

                    if (double.TryParse(montant, out double montantDouble))
                    {
                        _montantRetrait = montantDouble;
                        if (montantDouble > 0)
                        {
                            double totalAmount = montantDouble + CalculFrais();

                            if (_solde - totalAmount >= 50)
                            {
                                int decimales = BitConverter.GetBytes(decimal.GetBits((decimal)montantDouble)[3])[2];
                                if (decimales <= 2)
                                {
                                    _solde -= totalAmount;
                                    Transaction retrait = new Transaction("Retrait", montantDouble, DateTime.Now);
                                    _listeTransactions.Add(retrait);

                                    Transaction transactionFrais = new Transaction("Frais de retrait", CalculFrais(), DateTime.Now);
                                    _listeTransactions.Add(transactionFrais);

                                    Console.WriteLine($"Votre retrait a bien été pris en compte, votre solde est désormais de {_solde} €");

                                    return true;
                                }
                                else
                                {
                                    throw new FormatException("Le montant ne peut pas avoir plus de deux chiffres après la virgule");
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException("Le solde après retrait et frais doit être supérieur ou égal à 50.");
                            }
                        }
                        else
                        {
                            throw new FormatException("Le montant doit être supérieur à zéro.");
                        }
                    }
                    else
                    {
                        throw new FormatException("Veuillez saisir un montant valide.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Une erreur s'est produite : " + ex.Message);
                }
            }
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
            Console.WriteLine($"En cas de retrait, les frais s'élèvent à {_tauxFrais * 100}% du montant du retrait.");
            Console.ReadLine();
        }
    }
}