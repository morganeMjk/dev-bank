using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBank
{
    public interface ITransactionnel
    {
        void EffectuerRetrait();
        void EffectuerVirement();
        bool EffectuerDepot(string montant);
    }
}