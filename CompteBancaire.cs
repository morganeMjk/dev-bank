namespace DevBank
{
    public abstract class CompteBancaire : ITransactionnel
    {
        public int NumeroCompte
        {
            get => default;
            set
            {
            }
        }

        public int Solde
        {
            get => default;
            set
            {
            }
        }

        public int ListeTransactions
        {
            get => default;
            set
            {
            }
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