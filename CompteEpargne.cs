using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBank
{
    public class CompteEpargne : CompteBancaire
    {
        public int TauxIntérêt
        {
            get => default;
            set
            {
            }
        }

        public void CalculIntérêt()
        {
            throw new System.NotImplementedException();
        }

        public void CalculFrais()
        {
            throw new System.NotImplementedException();
        }

        public void ObtenirPolitique()
        {
            throw new System.NotImplementedException();
        }
    }
}