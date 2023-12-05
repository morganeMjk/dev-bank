using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBank
{
    public class Transaction
    {
      public string Type { get; set; }
        public double Montant { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string type, double montant, DateTime date)
        {
            Type = type;
            Montant = montant;
            Date = date;
        }
    }
}