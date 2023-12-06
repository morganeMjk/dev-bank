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

    enum ActionsCompte
    {
        DEPOT = 1,
        RETRAIT = 2,
        HISTORIQUE = 3,
        RETOUR_CHOIX_COMPTE = 4,
        QUITTER = 5
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenue dans l'application bancaire !");
        CompteCourant monCompteCourant = new CompteCourant();
        CompteEpargne monCompteEpargne = new CompteEpargne();

        while (true)
        {
            AfficherMenuPrincipal();
            TypeChoixCompte choixTypeCompte = GetTypeCompte();
            switch (choixTypeCompte)
            {
                case TypeChoixCompte.COMPTE_COURANT:
                    TraiterChoixCompte(monCompteCourant, choixTypeCompte);
                    break;
                case TypeChoixCompte.COMPTE_EPARGNE:
                    TraiterChoixCompte(monCompteEpargne, choixTypeCompte);
                    break;
                case TypeChoixCompte.QUITTER:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Option invalide. Veuillez choisir une option valide.");
                    break;
            }
        }
    }

    private static void TraiterChoixCompte(CompteBancaire monCompte, TypeChoixCompte choixTypeCompte)
    {
        var choixQuitter = false;
        while (!choixQuitter)
        {
            AfficherActionsCompte(monCompte, choixTypeCompte);
            ActionsCompte choixActionCompte = GetActionCompte();

            switch (choixActionCompte)
            {
                case ActionsCompte.DEPOT:
                    monCompte.EffectuerDepot();
                    break;
                case ActionsCompte.RETRAIT:
                    monCompte.EffectuerRetrait();
                    break;
                case ActionsCompte.HISTORIQUE:
                    monCompte.AfficherHistorique();
                    break;
                case ActionsCompte.RETOUR_CHOIX_COMPTE:
                    choixQuitter = true;
                    break;
                case ActionsCompte.QUITTER:
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

    private static ActionsCompte GetActionCompte()
    {
        Console.Write("Selectionnez une action à effectuer sur votre compte : ");

        int.TryParse(Console.ReadLine(), out int choixActionCompte);

        ActionsCompte actionCompte = (ActionsCompte)choixActionCompte;

        return actionCompte;
    }

    static void AfficherActionsCompte(CompteBancaire monCompteBancaire, TypeChoixCompte choixCompte)
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