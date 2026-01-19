using Project;

namespace ProjectTests;

public class RodCutMaximiserTests
{
    private RodCostMaximiser _rodCostMaximiser;
    
    [SetUp]
    public void Setup()
    {
        _rodCostMaximiser = new RodCostMaximiser();
    }

    [Test]
    public void GivenValidInputs_WhenCompute_ThenReturnsMaxValue()
    {
        // Arrange
        int n = 4;
        int[] c = {1, 5, 7, 8};

        // Act
        int result = _rodCostMaximiser.Compute(n, c);
        
        // Assert
        Assert.That(result, Is.EqualTo(10)); // 2 cuts of length 2
    }

    [Test]
    public void GivenCostsFavoringNoCuts_WhenCompute_ThenReturnsMaxValue()
    {
        // Arrange
        int n = 5;  
        int[] c = {1, 1, 1, 1, 10};

        // Act
        int result = _rodCostMaximiser.Compute(n, c);
        
        // Assert
        Assert.That(result, Is.EqualTo(10)); 
    }

    [Test]
    public void GivenMismatchedLength_WhenCompute_ThenThrowsArgumentException()
    {
        // Arrange
        int n = 5;
        int[] c = {1, 5, 8, 9};
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => _rodCostMaximiser.Compute(n, c));
    }
}