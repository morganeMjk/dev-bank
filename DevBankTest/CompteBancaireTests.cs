using DevBank;

namespace DevBankTest;

[TestFixture]
public class CompteBancaireTests
{
    private CompteCourant _compteCourant;
    private CompteEpargne _compteEpargne;

    [SetUp]
    public void SetUp()
    {
        _compteCourant = new CompteCourant(0);
        _compteEpargne = new CompteEpargne();
    }

    [Test]
    public void EffectuerDepot_Input100_GetSoldeReturn100()
    {
        // Act
        _compteCourant.EffectuerDepot("100");

        // Assert
        Assert.That(_compteCourant.GetSolde(), Is.EqualTo(100));
    }

    [Test]
    public void EffectuerDepot_Input100Twice_GetSoldeReturn200()
    {
        // Act
        _compteCourant.EffectuerDepot("100");
        _compteCourant.EffectuerDepot("100");

        // Assert
        Assert.That(_compteCourant.GetSolde(), Is.EqualTo(200));
    }

    [Test]
    public void EffectuerDepot_InputString_ThrowException()
    {
        // Act and Assert
        Assert.Throws<FormatException>(() => _compteCourant.EffectuerDepot("Laurent"));
    }

    [Test]
    public void EffectuerRetrait_Input3Decimales_ThrowException()
    {
        // Act and Assert
        Assert.Throws<FormatException>(() => _compteCourant.EffectuerRetrait("2,201"));
    }


    [Test]

    public void EffectuerVirement_depuisCompteCourant_Input_CompteEpargne_and_100_GetSoldeCompteCourantReturn_minus102_GetSoldeCompteEpargne_Return_100()
    {
        // Act
        _compteCourant.EffectuerVirement(_compteCourant,"100");

        // Assert
        Assert.That(_compteCourant.GetSolde(), Is.EqualTo(-102));
        Assert.That(_compteEpargne.GetSolde(), Is.EqualTo(150));
    }

    // Ajoutez d'autres m�thodes de test pour chaque fonctionnalit� que vous souhaitez tester.
}
