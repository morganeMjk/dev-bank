using DevBank;

namespace Quizz;

class Program
{
    enum TypeChoixCompte
    {
        COMPTE_COURANT = 1,
        COMPTE_EPARGNE = 2,
        QUITTER = 3
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenue dans l'application bancaire !");
        CompteCourant monCompteCourant = new CompteCourant();
        CompteEpargne monCompteEpargne = new CompteEpargne();

        while (true)
        {
            AfficherMenuPrincipal();
            int choixCompte;
            TypeChoixCompte choixTypeCompte = GetTypeCompte();
            switch (choixTypeCompte)
            {
                case TypeChoixCompte.COMPTE_COURANT:
                    TraiterActionCompte(monCompteCourant, choixTypeCompte);
                    break;
                case TypeChoixCompte.COMPTE_EPARGNE:
                    TraiterActionCompte(monCompteEpargne, choixTypeCompte);
                    break;
                default:
                    Console.WriteLine("Option invalide. Veuillez choisir une option valide.");
                    break;
            }
        }
    }

    private static void TraiterActionCompte(CompteBancaire monCompte, TypeChoixCompte choixTypeCompte)
    {
        var choixQuitter = false;
        while (!choixQuitter)
        {
            AfficherPageAccueil(monCompte, choixTypeCompte);

            Console.Write("Veuillez choisir une option (1-4) : ");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    monCompte.EffectuerDepot();
                    break;
                case "2":
                    monCompte.EffectuerRetrait();
                    break;
                case "3":
                    monCompte.AfficherHistorique();
                    break;
                case "4":
                    choixQuitter = true;
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Option invalide. Veuillez choisir une option valide.");
                    break;
            }
        };
    }

    private static TypeChoixCompte GetTypeCompte()
    {
        Console.Write("Veuillez choisir un compte (1-2) : ");
        int.TryParse(Console.ReadLine(), out int choixCompte);
        TypeChoixCompte choixTypeCompte = (TypeChoixCompte)choixCompte;
        return choixTypeCompte;
    }

    static void AfficherPageAccueil(CompteBancaire monCompteBancaire, TypeChoixCompte choixCompte)
    {
        // Affichage des informations du compte
        if (choixCompte == TypeChoixCompte.COMPTE_COURANT)
        {
            ((CompteCourant)monCompteBancaire).ConsulterSolde();
        }
        else if (choixCompte == TypeChoixCompte.COMPTE_EPARGNE)
        {
            ((CompteEpargne)monCompteBancaire).ConsulterSolde();
        }

        // Affichage du menu
        Console.WriteLine("1. Effectuer un dépôt");
        Console.WriteLine("2. Effectuer un retrait");
        Console.WriteLine("3. Afficher l'historique des transactions");
        Console.WriteLine("4. Revenir au choix du compte");
        Console.WriteLine("5. Quitter\n");
    }

    static void AfficherMenuPrincipal()
    {
        Console.WriteLine("1. Compte courant");
        Console.WriteLine("2. Compte epargne");
        Console.WriteLine("3. Quitter");
    }

}

