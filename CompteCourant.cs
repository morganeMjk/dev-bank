using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBank
{
    public class CompteCourant : CompteBancaire, ITransactionnel
    {
        private double _decouvertAutorise;
        private const double _pourcentageFrais = 0.05;

        public CompteCourant() : base()
        {
            _decouvertAutorise = -500;

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
                        if (montantDouble > _decouvertAutorise)
                        {
                            double soldeAvantRetrait = _solde;

                            // Utilisation de la méthode de la classe de base avec le découvert autorisé spécifique
                            bool retraitEffectue = base.EffectuerRetrait();

                            if (retraitEffectue && _solde < 0 && soldeAvantRetrait >= 0)
                            {
                                // Le solde est devenu négatif suite à ce retrait, déclencher le calcul des frais
                                CalculFrais();
                            }

                            return retraitEffectue;
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


        public void CalculFrais()
        {
            double montantFrais = Math.Abs(_solde) * _pourcentageFrais;

            Console.WriteLine($"Frais appliqués : -{montantFrais} € ({_pourcentageFrais * 100}% du solde en raison de solde négatif)");

            _solde -= montantFrais;

            Transaction frais = new Transaction("Frais", montantFrais, DateTime.Now);
            _listeTransactions.Add(frais);
        }

    }


}

