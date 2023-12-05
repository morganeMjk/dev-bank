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

        public void EffectuerVirement()
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

                Console.WriteLine($"Votre solde est désormais de {_solde} €");
                return true;
            }
        }
    }
}