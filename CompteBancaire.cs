using System;
using System.Collections.Generic;

namespace DevBank
{
    public class CompteBancaire : ITransactionnel
    {
        private Guid _numeroCompte;

        private double _solde;


        public List<Transaction> ListeTransactions
        {
            get => default;
            set
            {
            }
        }

        public CompteBancaire()
        {
            _solde = 0;
            _numeroCompte = Guid.NewGuid();
        }

        public void ConsulterSolde()
        {
            Console.WriteLine($"Solde du compte {_numeroCompte}: {_solde} €");
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

        public void EffectuerRetrait()
        {
            throw new System.NotImplementedException();
        }

        public void EffectuerVirement()
        {
            throw new System.NotImplementedException();
        }

        public bool EffectuerDepot(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Erreur : le montant du dépot doit être positif");
                return false;
            }
            _solde += montant;
        
            Console.WriteLine($"Votre solde est désormais de {_solde}");
            return true;
        }

        public void AfficherSolde()
        {
            throw new System.NotImplementedException();
        }

        public void EffectuerDépôt()
        {
            throw new NotImplementedException();
        }
    }
}