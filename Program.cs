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
        var depot = monCompteBancaire.EffectuerDepot();
        Console.WriteLine("Quel est le montant de votre retrait ?");
        var monRetrait = Console.ReadLine();
        var retrait = monCompteBancaire.EffectuerRetrait(monRetrait);
        var depot2 = monCompteBancaire.EffectuerDepot();
        monCompteBancaire.AfficherHistorique();
    }
}