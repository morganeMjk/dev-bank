using System;
using System.Collections.Generic;

namespace DevBank
{
    public class CompteBancaire : ITransactionnel
    {
        private Guid _numeroCompte;

        private double _solde;

        private List<Transaction> _listeTransactions;

        public List<Transaction> ListeTransactions
        {
            get { return _listeTransactions; }
            set { _listeTransactions = value; }
        }

        public CompteBancaire()
        {
            _solde = 0;
            _numeroCompte = Guid.NewGuid();
            _listeTransactions = new List<Transaction>();
        }

        public void ConsulterSolde()
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

        public void AfficherHistorique()
        {
            throw new System.NotImplementedException();
        }

        public bool EffectuerVirement()
        {
            throw new System.NotImplementedException();
        }

        public bool EffectuerRetrait(string montant)
        {
            if (!double.TryParse(montant, out double montantDouble) || montantDouble <= 0)
            {

                Console.WriteLine("Erreur : le montant du retrait doit être positif");
                return false;
            }
            else
            {
                montantDouble = Math.Round(montantDouble, 2);

                _solde -= montantDouble;
                Transaction retrait = new Transaction("Retrait", montantDouble, DateTime.Now);
                _listeTransactions.Add(retrait);

                Console.WriteLine($"Votre solde est désormais de {_solde} €");
                return true;
            }
        }

        public bool EffectuerDepot(string montant)
        {
            if (!double.TryParse(montant, out double montantDouble) || montantDouble <= 0)
            {

                Console.WriteLine("Erreur : le montant du dépot doit être positif");
                return false;
            }
            else
            {
                montantDouble = Math.Round(montantDouble, 2);

                _solde += montantDouble;

                Transaction depot = new Transaction("Depot", montantDouble, DateTime.Now);
                _listeTransactions.Add(depot);

                Console.WriteLine($"Votre solde est désormais de {_solde} €");
                return true;
            }
        }
    }
}