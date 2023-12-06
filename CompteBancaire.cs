using System;
using System.Collections.Generic;

namespace DevBank
{
    public abstract class CompteBancaire : ITransactionnel
    {
        private Guid _numeroCompte;

        public Guid getNumeroCompte()
        {
            return _numeroCompte;
        }


        private double _solde;

        public double getSolde()
        {
            return _solde;
        }

        public double setSolde(double solde)
        {
            _solde = solde;
            return _solde;
        }

        private List<Transaction> _listeTransactions;

        public List<Transaction> getListeTransactions()
        {
            return _listeTransactions;
        }

        public List<Transaction> setListeTransactions(List<Transaction> listeTransactions)
        {
            _listeTransactions = listeTransactions;
            return _listeTransactions;
        }
        

        public CompteBancaire()
        {
            _solde = 0;
            _numeroCompte = Guid.NewGuid();
            _listeTransactions = new List<Transaction>();
        }

        public virtual void ConsulterSolde()
        {
            Console.WriteLine($"Numero de compte {_numeroCompte}. Votre solde est de: {_solde} €");
        }


        public void CalculFrais()
        {
            throw new System.NotImplementedException();
        }

        public void ObtenirPolitique()
        {
            throw new System.NotImplementedException();
        }

        public virtual void AfficherHistorique()
        {
            Console.WriteLine("Voici l'historique de vos transactions sur les 30 derniers jours :");

            DateTime dateLimite = DateTime.Now.AddDays(-30);

            foreach (var userTransaction in _listeTransactions)
            {
                if (userTransaction.Date >= dateLimite)
                {
                    if (userTransaction.Type == "Depot")
                    {
                        Console.Write(userTransaction.Date.ToShortDateString());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($" +{userTransaction.Montant} €");
                        Console.ResetColor();
                    }
                    else if (userTransaction.Type == "Retrait")
                    {
                        Console.Write(userTransaction.Date.ToShortDateString());
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($" -{userTransaction.Montant} €");
                        Console.ResetColor();
                    }
                }
            }
        }

        public virtual bool EffectuerVirement()
        {
            throw new System.NotImplementedException();
        }

        public virtual bool EffectuerRetrait()
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
                            if (montantDouble <= _solde)
                            {
                                int decimales = BitConverter.GetBytes(decimal.GetBits((decimal)montantDouble)[3])[2];
                                if (decimales <= 2)
                                {
                                    _solde -= montantDouble;
                                    Transaction retrait = new Transaction("Retrait", montantDouble, DateTime.Now);
                                    _listeTransactions.Add(retrait);
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
                                throw new InvalidOperationException("Le montant du retrait est supérieur au solde.");
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



        public virtual bool EffectuerDepot()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Veuillez saisir le montant de votre dépôt :");
                    string montant = Console.ReadLine();

                    if (double.TryParse(montant, out double montantDouble))
                    {
                        if (montantDouble >= 0.01)
                        {
                            int decimales = BitConverter.GetBytes(decimal.GetBits((decimal)montantDouble)[3])[2];
                            if (decimales <= 2)
                            {
                                _solde += montantDouble;
                                Transaction depot = new Transaction("Depot", montantDouble, DateTime.Now);
                                _listeTransactions.Add(depot);
                                Console.WriteLine($"Votre dépôt a bien été pris en compte, votre solde est désormais de {_solde} €");
                                return true;
                            }
                            else
                            {
                                throw new FormatException("Le montant ne peut pas avoir plus de deux chiffres après la virgule");
                            }
                        }
                        else
                        {
                            throw new FormatException("Le montant doit être supérieur ou égal à 0,01.");
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