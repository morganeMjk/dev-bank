namespace DevBank
{
    public class CompteCourant : CompteBancaire, ITransactionnel
    {
        private const double _decouvertAutorise = -500;
        private const double _pourcentageFraisRetrait = 0.02;

        // Autres membres et méthodes

        private double CalculerFraisRetrait()
        {
            double montant = Math.Abs(_solde) * _pourcentageFraisRetrait;
            Console.WriteLine($"Frais appliqués : -{montant} € ({_pourcentageFraisRetrait * 100}% du solde en raison de solde négatif)");
            return montant;
        }

        public override void EffectuerRetrait(string? montant)
        {
            if (!double.TryParse(montant, out double montantDouble))
            {
                throw new FormatException("Veuillez saisir un montant valide.");
            }

            if (montantDouble <= 0 || montantDouble >= 500)
            {
                throw new FormatException("Le retrait doit être d'un montant compris entre 0 et 500.");
            }

            // Vérifier si le retrait est possible avec le solde actuel et le découvert autorisé
            if (_solde - montantDouble < _decouvertAutorise)
            {
                throw new InvalidOperationException("Le montant du retrait est supérieur au solde autorisé (y compris le découvert).");
            }

            int decimales = BitConverter.GetBytes(decimal.GetBits((decimal)montantDouble)[3])[2];
            if (decimales > 2)
            {
                throw new FormatException("Le montant ne peut pas avoir plus de deux chiffres après la virgule");
            }

            double soldeAvantRetrait = _solde;

            // Effectuer le retrait
            _solde -= montantDouble;

            // Si le solde est devenu négatif avant le retrait, appliquer des frais
            if (soldeAvantRetrait < 0)
            {
                double montantFraisAvantRetrait = CalculerFraisRetrait();
                _solde -= montantFraisAvantRetrait;
            }

            Transaction retrait = new Transaction("Retrait", montantDouble, DateTime.Now);
            _listeTransactions.Add(retrait);

            Console.WriteLine($"Votre retrait a bien été pris en compte, votre solde est désormais de {_solde} €");

            // Si le solde est devenu négatif après le retrait, appliquer des frais
            if (_solde < 0)
            {
                double montantFraisApresRetrait = CalculerFraisRetrait();
                _solde -= montantFraisApresRetrait;

                Transaction transactionFrais = new Transaction("Frais de retrait", montantFraisApresRetrait, DateTime.Now);
                _listeTransactions.Add(transactionFrais);
            }
        }
    }
}