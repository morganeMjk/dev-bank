using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBank
{
    public interface ITransactionnel
    {
        bool EffectuerRetrait();
        bool EffectuerVirement();
        bool EffectuerDepot();
    }
}