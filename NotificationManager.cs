namespace DevBank
{
    public class NotificationManager
    {
        // Méthode pour envoyer une notification
        public static void SendNotification(string message)
        {
            string fichierHistorique = "historique.txt";
            if (!File.Exists(fichierHistorique))
            {
                File.Create(fichierHistorique).Close();
                Console.WriteLine($"Le fichier {fichierHistorique} a été créé.");
            }

            Console.WriteLine($"Notification: {message}");

            // Enregistrer la notification dans un fichier
            File.AppendAllText(fichierHistorique, $"{DateTime.Now}: {message}\n");
        }
    }
}