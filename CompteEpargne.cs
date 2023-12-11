using Timer = System.Timers.Timer;

namespace DevBank
{
    public class CompteEpargne : CompteBancaire, ITransactionnel
    {
        private const double SOLDE_INITIAL_EPARGNE = 50;

        private double _tauxInteret;
        private double _tauxFrais;
        private Timer _timer;

        public CompteEpargne() : base()
        {
            _solde = SOLDE_INITIAL_EPARGNE;
            _tauxInteret = 0.046;
            _tauxFrais = 0.0335;
            _timer = new Timer(60000);
            _timer.Elapsed += CalculerIntérêt;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void CalculerIntérêt(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Vérifier si la liste de transactions n'est pas vide
            if (_listeTransactions.Count <= 0)
            {
                return;
            }
            // Obtenir la dernière transaction
            Transaction derniereTransaction = _listeTransactions[_listeTransactions.Count - 1];

            TimeSpan difference = DateTime.Now - derniereTransaction.Date;

            if (difference.TotalMinutes < 1)
            {
                return;
            }
            // Calculer et ajouter les intérêts
            double interet = Math.Round(_solde * _tauxInteret, 2);
            _solde += interet;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n Des intérêts de {interet}€ ont été ajoutés à votre compte.");
            Console.ResetColor();

            // Mettre à jour la dernière transaction
            derniereTransaction = new Transaction("Intérêts", interet, DateTime.Now);
            _listeTransactions.Add(derniereTransaction);
        }

        public override void EffectuerRetrait(string? montant)
        {
            var montantDouble = Montant.ConvertirEnDouble(montant);

            _montantRetrait = montantDouble;

            Montant.VerifierSiNull(montantDouble);

            double frais = CalculFrais();

            double totalAmount = montantDouble + frais;
            
            if (_solde - totalAmount < 50)
            {
                throw new InvalidOperationException("Le solde après retrait et frais doit être supérieur ou égal à 50.");
            }

            Montant.VerifierDecimales(montantDouble);

            _solde -= totalAmount;

            Transaction retrait = new Transaction("Retrait", montantDouble, DateTime.Now);
            _listeTransactions.Add(retrait);

            Transaction transactionFrais = new Transaction("Frais de retrait", frais, DateTime.Now);
            _listeTransactions.Add(transactionFrais);

            Console.WriteLine($"Votre retrait a bien été pris en compte, votre solde est désormais de {_solde} €");
        }


        public override double CalculFrais()
        {
            var frais = Math.Round(_montantRetrait * _tauxFrais, 2);
            Console.WriteLine($"cette opération va engendrer des frais à hauteur de {frais}€");
            return frais;
        }

        public override void ObtenirPolitique()
        {
            Console.WriteLine($"Le taux d'intérêt est de {_tauxInteret * 100}%");
            Console.WriteLine($"En cas de retrait, les frais s'élèvent à {_tauxFrais * 100}% du montant du retrait.");
            Console.ReadLine();
        }
    }
}