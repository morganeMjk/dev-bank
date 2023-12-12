using DevBank;

namespace DevBankTest;

[TestFixture]
public class CompteBancaireTests
{
    private CompteCourant _compte;

    [SetUp]
    public void SetUp()
    {
        _compte = new CompteCourant(0);
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

    // Ajoutez d'autres méthodes de test pour chaque fonctionnalité que vous souhaitez tester.
}
