namespace DevBank;

public abstract class CompteBancaire : ITransactionnel
{

    public Guid _numeroCompte;

    protected double _solde;

    protected List<Transaction> _listeTransactions;
    protected double _montantRetrait;

    public delegate void NotificationDelegate(string message);

    // event
    public NotificationDelegate Notification;

    public CompteBancaire()
    {
        _solde = 0;
        _numeroCompte = Guid.NewGuid();
        _listeTransactions = new List<Transaction>();
    }

    public virtual void ConsulterSolde(string typeDeCompte)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{typeDeCompte} {_numeroCompte}. Votre solde est de: {_solde} €");
        Console.ResetColor();
    }

    public virtual double CalculFrais()
    {
        throw new System.NotImplementedException();
    }

    public virtual void ObtenirPolitique()
    {
        Console.WriteLine("Voici la politique de votre compte :");
    }

    public virtual void AfficherHistorique()
    {
        Console.WriteLine("Voici l'historique de vos transactions sur les 30 derniers jours :");

        DateTime dateLimite = DateTime.Now.AddDays(-30);

        foreach (var userTransaction in _listeTransactions)
        {
            if (userTransaction.Date >= dateLimite)
            {
                if (userTransaction.Type == "Depot")
                {
                    Console.Write(userTransaction.Date.ToShortDateString());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($" +{userTransaction.Montant}€ ");
                    Console.WriteLine(userTransaction.Type);
                    Console.ResetColor();
                }
                else if (userTransaction.Type == "Retrait")
                {
                    Console.Write(userTransaction.Date.ToShortDateString());
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($" -{userTransaction.Montant}€ ");
                    Console.WriteLine(userTransaction.Type);
                    Console.ResetColor();
                }
                else if (userTransaction.Type == "Frais de retrait")
                {
                    Console.Write(userTransaction.Date.ToShortDateString());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($" -{userTransaction.Montant}€ ");
                    Console.WriteLine(userTransaction.Type);
                    Console.ResetColor();
                }
                else if (userTransaction.Type == "Intérêts")
                {
                    Console.Write(userTransaction.Date.ToShortDateString());
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($" +{userTransaction.Montant}€ ");
                    Console.WriteLine(userTransaction.Type);
                    Console.ResetColor();
                }
            }
        }
    }

    public virtual void EffectuerVirement(CompteBancaire compteDestination, string? montant)
    {
        EffectuerRetrait(montant);

        compteDestination.EffectuerDepot(montant);

        // "Virement entrant"

        Console.WriteLine($"Le virement de {montant} € vers le compte {compteDestination._numeroCompte} a été effectué avec succès.");
    }

    public virtual void EffectuerRetrait(string? montant)
    {
        var montantDouble = Montant.ConvertirEnDouble(montant);

        _montantRetrait = montantDouble;

        Montant.VerifierSiNull(montantDouble);

        Montant.VerifierSiSuperieurSolde(montantDouble, _solde);

        Montant.VerifierDecimales(montantDouble);

        _solde -= montantDouble;
        Transaction retrait = new Transaction("Retrait", montantDouble, DateTime.Now);
        _listeTransactions.Add(retrait);
        Console.WriteLine($"Votre retrait a bien été pris en compte, votre solde est désormais de {_solde} €");

    }

    public virtual void EffectuerDepot(string? montant)
    {
        try
        {
            var montantDouble = Montant.ConvertirEnDouble(montant);

            Montant.VerifierSiNull(montantDouble);

            Montant.VerifierDecimales(montantDouble);

            _solde += montantDouble;
            Transaction depot = new Transaction("Depot", montantDouble, DateTime.Now);
            _listeTransactions.Add(depot);
            Notification?.Invoke($"Dépôt effectué sur le compte n°{_numeroCompte}. votre solde est désormais de {_solde}€");
        }

        catch (Exception ex)
        {
            Console.WriteLine("Une erreur s'est produite : " + ex.Message);
        }
    }
}