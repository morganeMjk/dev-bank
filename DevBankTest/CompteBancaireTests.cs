using DevBank;

namespace DevBankTest;

[TestFixture]
public class CompteBancaireTests
{
    private CompteCourant _compte;
    private CompteEpargne _compteEpargne;

    [SetUp]
    public void SetUp()
    {
        _compte = new CompteCourant(0);
        _compteEpargne = new CompteEpargne();
    }

    [Test]
    public void EffectuerDepot_Input100_GetSoldeReturn100()
    {
        // Act
        _compte.EffectuerDepot("100");

        // Assert
        Assert.That(_compte.GetSolde(), Is.EqualTo(100));
    }

    [Test]
    public void EffectuerDepot_Input100Twice_GetSoldeReturn200()
    {
        // Act
        _compte.EffectuerDepot("100");
        _compte.EffectuerDepot("100");

        // Assert
        Assert.That(_compte.GetSolde(), Is.EqualTo(200));
    }

    [Test]
    public void EffectuerDepot_InputString_ThrowException()
    {
        // Act and Assert
        Assert.Throws<FormatException>(() => _compte.EffectuerDepot("Laurent"));
    }

    [Test]
    public void EffectuerRetrait_Input3Decimales_ThrowException()
    {
        // Act and Assert
        Assert.Throws<FormatException>(() => _compte.EffectuerRetrait("2,201"));
    }


    [Test]

    public void EffectuerVirement_Input100_ThrowException()
    {
        // Act and Assert
        Assert.Throws<FormatException>(() => _compte.EffectuerVirement(new CompteEpargne(), "100"));
    }

    // Ajoutez d'autres m�thodes de test pour chaque fonctionnalit� que vous souhaitez tester.
}
