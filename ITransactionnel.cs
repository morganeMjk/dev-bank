namespace DevBank;

public interface ITransactionnel
{
    void EffectuerRetrait(string? montant);
    bool EffectuerVirement(CompteBancaire compteDestination);
    void EffectuerDepot(string? montant);
}