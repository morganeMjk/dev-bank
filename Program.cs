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

    }
}