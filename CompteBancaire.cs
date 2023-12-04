using System;
using System.Collections.Generic;

namespace DevBank
{
    public class CompteBancaire : ITransactionnel
    {
        private Guid _numeroCompte;

        private int _solde;


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

        public void EffectuerDépôt()
        {
            throw new System.NotImplementedException();
        }

        public void AfficherSolde()
        {
            throw new System.NotImplementedException();
        }
    }
}