using System;
using DevBank;

namespace Quizz;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenue dans l'application bancaire !");
        CompteBancaire monCompteBancaire = new CompteBancaire();

        while (true)
        {
            AfficherPageAccueil(monCompteBancaire);

            Console.Write("Veuillez choisir une option (1-4) : ");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    monCompteBancaire.EffectuerDepot();
                    break;
                case "2":
                    monCompteBancaire.EffectuerRetrait();
                    break;
                case "3":
                    monCompteBancaire.AfficherHistorique();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Option invalide. Veuillez choisir une option valide.");
                    break;
            }
        }
    }

    static void AfficherPageAccueil(CompteBancaire monCompteBancaire)
    {

        // Affichage des informations du compte
        monCompteBancaire.ConsulterSolde();

        // Affichage du menu
        Console.WriteLine("1. Effectuer un dépôt");
        Console.WriteLine("2. Effectuer un retrait");
        Console.WriteLine("3. Afficher l'historique des transactions");
        Console.WriteLine("4. Quitter\n");
    }


}

