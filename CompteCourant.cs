namespace DevBank
{
    public class CompteCourant : CompteBancaire, ITransactionnel
    {
        private const double _decouvertAutorise = -500;
        private const double _montantMax = 500;

        private const double _pourcentageFraisRetrait = 0.02;

        public CompteCourant(double solde) : base()
        {
            _solde = solde;
        }

        // Autres membres et méthodes

        private double CalculerFraisRetrait()
        {
            double montant = Math.Round(Math.Abs(_solde) * _pourcentageFraisRetrait, 2);
            return montant;
        }

        public override void EffectuerRetrait(string? montant)
        {

            var montantDouble = Montant.ConvertirEnDouble(montant);

            Montant.VerifierSiNull(montantDouble);

            Montant.VerifierSiSuperieurMontantMax(montantDouble, _montantMax);

            // Vérifier si le retrait est possible avec le solde actuel et le découvert autorisé
            if (_solde - montantDouble < _decouvertAutorise)
            {
                throw new InvalidOperationException("Le montant du retrait est supérieur au solde autorisé (y compris le découvert).");
            }

            Montant.VerifierDecimales(montantDouble);

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
            Notification?.Invoke($"Retrait de {montantDouble}€ effectué sur le compte n°{_numeroCompte}. Votre solde est désormais de {_solde} €");

            // Si le solde est devenu négatif après le retrait, appliquer des frais
            if (_solde < 0)
            {
                double montantFraisApresRetrait = CalculerFraisRetrait();
                _solde -= montantFraisApresRetrait;

                Transaction transactionFrais = new Transaction("Frais de retrait", montantFraisApresRetrait, DateTime.Now);
                _listeTransactions.Add(transactionFrais);
                Notification?.Invoke($"Frais appliqués : -{montant} € {_pourcentageFraisRetrait * 100}% du solde en raison de solde négatif, effectué sur le compte n°{_numeroCompte}");
            }
        }

        public override void ObtenirPolitique()
        {
            Console.WriteLine($"Le découvert autoisé est de {_decouvertAutorise} €");
            Console.WriteLine($"Le retrait maximum autorisé est de {_montantMax} €");
            Console.WriteLine($"En cas de retrait qui donne un solde négatif, les frais s'élèvent à {_pourcentageFraisRetrait * 100}% du montant du retrait.");
            Console.ReadLine();
        }
  }
}