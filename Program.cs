using System;
using System.ComponentModel.Design;
using DevBank;

namespace Quizz;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenue dans l'application bancaire !");
        CompteCourant monCompteCourant = new CompteCourant();
        CompteEpargne monCompteEpargne = new CompteEpargne();

        while (true)
        {
            AfficherMenuPrincipal();
            Console.Write("Veuillez choisir un compte (1-2) : ");
            string choixCompte = Console.ReadLine();
            switch (choixCompte)
            {

                case "1":
                    while (true)
                    {
                        AfficherPageAccueil(monCompteCourant);

                        Console.Write("Veuillez choisir une option (1-4) : ");
                        string choix = Console.ReadLine();

                        switch (choix)
                        {
                            case "1":
                                monCompteCourant.EffectuerDepot();
                                break;
                            case "2":
                                monCompteCourant.EffectuerRetrait();
                                break;
                            case "3":
                                monCompteCourant.AfficherHistorique();
                                break;
                            case "4":
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Option invalide. Veuillez choisir une option valide.");
                                break;
                        }
                    }
                case "2":
                    while (true)
                    {
                        AfficherPageAccueil(monCompteEpargne);

                        Console.Write("Veuillez choisir une option (1-4) : ");
                        string choix = Console.ReadLine();

                        switch (choix)
                        {
                            case "1":
                                monCompteEpargne.EffectuerDepot();
                                break;
                            case "2":
                                monCompteEpargne.EffectuerRetrait();
                                break;
                            case "3":
                                monCompteEpargne.AfficherHistorique();
                                break;
                            case "4":
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Option invalide. Veuillez choisir une option valide.");
                                break;
                        }
                    }
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

    static void AfficherMenuPrincipal()
    {
        Console.WriteLine("1. Compte courant");
        Console.WriteLine("2. Compte epargne");
        Console.WriteLine("3. Quitter");
    }

}

