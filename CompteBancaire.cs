using System.Collections.Generic;

namespace DevBank
{
    public abstract class CompteBancaire : ITransactionnel
    {
        public int NumeroCompte;

        public int Solde
        {
            get => default;
            set
            {
            }
        }

        public List<Transaction> ListeTransactions
        {
            get => default;
            set
            {
            }
        }

        public void ConsulterSolde()
        {
            throw new System.NotImplementedException();
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
    }
}