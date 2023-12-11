namespace DevBank;

public interface ITransactionnel
{
    void EffectuerRetrait(string? montant);
    void EffectuerVirement(CompteBancaire compteDestination, string? montant);
    void EffectuerDepot(string? montant);
}