namespace DevBank;

public static class Montant
{
    private const string MESSAGEERREURPRECISIONMONTANT = "Le montant ne peut pas avoir plus de deux chiffres après la virgule";

    public static double ConvertirEnDouble(string montant)
    {
        if (!double.TryParse(montant, out double montantDouble))
        {
            throw new FormatException("Veuillez saisir un montant valide.");
        }
        return montantDouble;
    }

    public static void VerifierSiNull(double montant)
    {
        if (montant <= 0)
        {
            throw new FormatException("Le montant doit être supérieur à zéro.");
        }
    }

    public static void VerifierSiSuperieurSolde(double montant, double solde)
    {
        if (montant > solde)
        {
            throw new InvalidOperationException("Le montant du retrait est supérieur au solde.");
        }
    }

    public static void VerifierSiSuperieurMontantMax(double montant, double montantMax)
    {
        if (montant >= montantMax)
        {
            throw new FormatException($"Le retrait ne peut pas être supérieur à {montantMax}€");
        }
    }

    public static void VerifierDecimales(double montant)
    {
        int decimales = BitConverter.GetBytes(decimal.GetBits((decimal)montant)[3])[2];
        if (decimales > 2)
        {
            throw new FormatException(MESSAGEERREURPRECISIONMONTANT);
        }
    }
}