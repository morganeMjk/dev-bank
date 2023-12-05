using System;
using DevBank;

namespace Quizz;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Bienvenue ! ");

        var monCompteBancaire = new CompteBancaire();
        monCompteBancaire.ConsulterSolde();
        Console.WriteLine("Quel est le montant de votre dépot ?");
        var monDepot = Console.ReadLine();
        var depot = monCompteBancaire.EffectuerDepot(monDepot);
        Console.WriteLine("Quel est le montant de votre retrait ?");
        var monRetrait = Console.ReadLine();
        var retrait = monCompteBancaire.EffectuerRetrait(monRetrait);
        Console.WriteLine("Quel est le montant de votre dépot ?");
        var monDepot2 = Console.ReadLine();
        var depot2 = monCompteBancaire.EffectuerDepot(monDepot2);
        monCompteBancaire.AfficherHistorique();
    }
}