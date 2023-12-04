using System;

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

        public static double Solde
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

        public bool EffectuerDepot(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Erreur : le montant du dépot doit être positif");
                return false;
            }
            Solde += montant;
        
            Console.WriteLine($"Votre solde est désormais de {Solde}");
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