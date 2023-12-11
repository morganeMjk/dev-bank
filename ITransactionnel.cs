namespace DevBank
{
    public interface ITransactionnel
    {
        bool EffectuerRetrait();
        bool EffectuerVirement();
        bool EffectuerDepot();
    }
}