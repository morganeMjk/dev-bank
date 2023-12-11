namespace DevBank;

public abstract class CompteBancaire : ITransactionnel
{
    private const string MESSAGEERREURPRECISIONMONTANT = "Le montant ne peut pas avoir plus de deux chiffres après la virgule";
    private Guid _numeroCompte;

    protected double _solde;

    protected List<Transaction> _listeTransactions;
    protected double _montantRetrait;

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

    public virtual bool EffectuerVirement(CompteBancaire compteDestination)
    {
        
        while (true)
        {
            try
            {
                Console.WriteLine("Veuillez saisir le montant du virement :");
                string? montant = Console.ReadLine();

                EffectuerRetrait(montant);

                compteDestination.EffectuerDepot(montant);

                // "Virement entrant"

                Console.WriteLine($"Le virement de {montant} € vers le compte {compteDestination._numeroCompte} a été effectué avec succès.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }
        }
    }

    public virtual void EffectuerRetrait(string? montant)
    {
        if (!double.TryParse(montant, out double montantDouble))
        {
            throw new FormatException("Veuillez saisir un montant valide.");
        }
        _montantRetrait = montantDouble;
        if (montantDouble <= 0)
        {
            throw new FormatException("Le montant doit être supérieur à zéro.");
        }

        if (montantDouble > _solde)
        {
            throw new InvalidOperationException("Le montant du retrait est supérieur au solde.");
        }

        int decimales = BitConverter.GetBytes(decimal.GetBits((decimal)montantDouble)[3])[2];
        if (decimales > 2)
        {
            throw new FormatException("Le montant ne peut pas avoir plus de deux chiffres après la virgule");
        }

        _solde -= montantDouble;
        Transaction retrait = new Transaction("Retrait", montantDouble, DateTime.Now);
        _listeTransactions.Add(retrait);
        Console.WriteLine($"Votre retrait a bien été pris en compte, votre solde est désormais de {_solde} €");

    }

    public virtual void EffectuerDepot(string? montant)
    {
        if (!double.TryParse(montant, out double montantDouble))
        {
            throw new FormatException("Veuillez saisir un montant valide.");
        }

        if (montantDouble < 0.01)
        {
            throw new FormatException("Le montant doit être supérieur ou égal à 0,01.");
        }

        int decimales = BitConverter.GetBytes(decimal.GetBits((decimal)montantDouble)[3])[2];
        if (decimales > 2)
        {
            throw new FormatException(MESSAGEERREURPRECISIONMONTANT);
        }

        _solde += montantDouble;
        Transaction depot = new Transaction("Depot", montantDouble, DateTime.Now);
        _listeTransactions.Add(depot);
        Console.WriteLine($"Votre dépôt a bien été pris en compte, votre solde est désormais de {_solde} €");
    }
}