using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBank
{
    public class CompteCourant : CompteBancaire, ITransactionnel
    {
        private const double _decouvertAutorise = -500;
        private const double _pourcentageFraisRetrait = 0.02;

        // Autres membres et méthodes

        private double CalculerFraisRetrait()
        {
            double montant = Math.Abs(_solde) * _pourcentageFraisRetrait;
            Console.WriteLine($"Frais appliqués : -{montant} € ({_pourcentageFraisRetrait * 100}% du solde en raison de solde négatif)");
            return montant;
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
                        if (montantDouble > 0)
                        {
                            // Vérifier si le retrait est possible avec le solde actuel et le découvert autorisé
                            if (_solde - montantDouble >= _decouvertAutorise)
                            {
                                int decimales = BitConverter.GetBytes(decimal.GetBits((decimal)montantDouble)[3])[2];
                                if (decimales <= 2)
                                {
                                    double soldeAvantRetrait = _solde;

                                    // Effectuer le retrait
                                    _solde -= montantDouble;

                                    // Si le solde est devenu négatif avant le retrait, appliquer des frais
                                    if (soldeAvantRetrait < 0)
                                    {
                                        double montantFraisAvantRetrait = CalculerFraisRetrait();
                                        _solde -= montantFraisAvantRetrait;

                                        Transaction transactionFrais = new Transaction("Retrait", montantFraisAvantRetrait, DateTime.Now);
                                        _listeTransactions.Add(transactionFrais);
                                    }

                                    Transaction retrait = new Transaction("Retrait", montantDouble, DateTime.Now);
                                    _listeTransactions.Add(retrait);




                                    Console.WriteLine($"Votre retrait a bien été pris en compte, votre solde est désormais de {_solde} €");

                                    // Si le solde est devenu négatif après le retrait, appliquer des frais
                                    if (_solde < 0)
                                    {
                                        double montantFraisApresRetrait = CalculerFraisRetrait();
                                        _solde -= montantFraisApresRetrait;

                                        Transaction transactionFrais = new Transaction("Retrait", montantFraisApresRetrait, DateTime.Now);
                                        _listeTransactions.Add(transactionFrais);
                                    }

                                    return true;
                                }
                                else
                                {
                                    throw new FormatException("Le montant ne peut pas avoir plus de deux chiffres après la virgule");
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException("Le montant du retrait est supérieur au solde autorisé (y compris le découvert).");
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
    }
}