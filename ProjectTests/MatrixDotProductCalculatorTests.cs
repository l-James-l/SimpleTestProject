using Project;

namespace ProjectTests;

public class MatrixDotProductCalculatorTests
{
    private MatrixDotProductCalculator _dotProductCalculator; //SUT

    [SetUp]
    public void Setup()
    {
        _dotProductCalculator = new MatrixDotProductCalculator();
    }

    private static int[,] CreateFilledMatrix(int rows, int cols, int value)
    {
        var m = new int[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                m[i, j] = value;
        return m;
    }


    private static void AssertMatrixEquals(int[,] expected, int[,] actual)
    {
        Assert.That(actual.GetLength(0), Is.EqualTo(expected.GetLength(0)), "Row count mismatch");
        Assert.That(actual.GetLength(1), Is.EqualTo(expected.GetLength(1)), "Column count mismatch");

        for (int i = 0; i < expected.GetLength(0); i++)
            for (int j = 0; j < expected.GetLength(1); j++)
                Assert.That(actual[i, j], Is.EqualTo(expected[i, j]), $"Value mismatch at [{i},{j}]");
    }

    [Test]
    public void GivenTwoCompatibleMatrices_WhenCalculateDotProduct_TwoMatrixProductIsCorrectAndCountsMultiplications()
    {
        // Arrange
        var a = CreateFilledMatrix(30, 1, 1); // 30x1
        var b = CreateFilledMatrix(1, 40, 1); // 1x40
        int expectedMultiplications = 30 * 40 * 1; // p * q * r

        // Act
        var result = _dotProductCalculator.CalculateDotProduct(a, b);

        // Assert
        Assert.That(result.GetLength(0), Is.EqualTo(30));
        Assert.That(result.GetLength(1), Is.EqualTo(40));
        // since both matrices are filled with ones, each cell is 1
        for (int i = 0; i < 30; i++)
            for (int j = 0; j < 40; j++)
                Assert.That(result[i, j], Is.EqualTo(1), $"Unexpected value at [{i},{j}]");

        Assert.That(_dotProductCalculator.MatrixMultiplicationCount, Is.EqualTo(expectedMultiplications));
    }

    [Test]
    public void GivenChainOfMatrices30x1_1x40_40x10_10x25_WhenCalculateDotProduct_ThenReturnsExpected30x25ResultAndUsesOptimalMultiplications()
    {
        // Arrange
        // Matrices: A (30x1), B (1x40), C (40x10), D (10x25)
        var a = CreateFilledMatrix(30, 1, 1);
        var b = CreateFilledMatrix(1, 40, 1);
        var c = CreateFilledMatrix(40, 10, 1);
        var d = CreateFilledMatrix(10, 25, 1);

        var matrices = new List<int[,]> { a, b, c, d };

        // For these dimensions the optimal scalar multiplication count is 1400 (precomputed):
        // optimal parenthesization M1*((M2*M3)*M4) produces total = 1400 - Robart Mercas approved :)
        int expectedOptimalMultiplications = 1400;

        // Act
        var result = _dotProductCalculator.CalculateDotProduct(matrices);

        // Assert final shape
        Assert.That(result.GetLength(0), Is.EqualTo(30));
        Assert.That(result.GetLength(1), Is.EqualTo(25));

        // For all-ones inputs the expected final matrix entries are 400:
        // Explanation: A*B -> 30x40 all ones
        // (A*B)*C -> 30x10 all entries 40
        // ((A*B)*C)*D -> 30x25 all entries 40 * 10 = 400
        for (int i = 0; i < 30; i++)
            for (int j = 0; j < 25; j++)
                Assert.That(result[i, j], Is.EqualTo(400), $"Unexpected value at [{i},{j}]");

        // Assert that the calculator used the expected minimal number of scalar multiplications
        Assert.That(_dotProductCalculator.MatrixMultiplicationCount, Is.EqualTo(expectedOptimalMultiplications));
    }

    [Test]
    public void GivenChainOfMatricesWithNonUnityValues_WhenCalculateDotProduct_ThenReturnsExpectedScaledValuesAndCountsMultiplications()
    {
        // Arrange
        // Matrices: A (30x1) filled with 2, B (1x40) filled with 3, C (40x10) filled with 4, D (10x25) filled with 5
        var a = CreateFilledMatrix(30, 1, 2);
        var b = CreateFilledMatrix(1, 40, 3);
        var c = CreateFilledMatrix(40, 10, 4);
        var d = CreateFilledMatrix(10, 25, 5);

        var matrices = new List<int[,]> { a, b, c, d };

        // The arithmetic for constant-filled matrices:
        // A*B entries = (1 term) 2 * 3 = 6
        // (A*B)*C entries = sum over 40 of 6 * 4 = 40 * 24 = 960
        // ((A*B)*C)*D entries = sum over 10 of 960 * 5 = 10 * 4800 = 48000
        int expectedEntryValue = 48000;
        int expectedOptimalMultiplications = 1400; // same optimal count as the equivalent-dimension case

        // Act
        var result = _dotProductCalculator.CalculateDotProduct(matrices);

        // Assert final shape
        Assert.That(result.GetLength(0), Is.EqualTo(30));
        Assert.That(result.GetLength(1), Is.EqualTo(25));

        // Assert values
        for (int i = 0; i < 30; i++)
            for (int j = 0; j < 25; j++)
                Assert.That(result[i, j], Is.EqualTo(expectedEntryValue), $"Unexpected value at [{i},{j}]");

        // Assert multiplication count
        Assert.That(_dotProductCalculator.MatrixMultiplicationCount, Is.EqualTo(expectedOptimalMultiplications));
    }

    [Test]
    public void GivenIncompatibleConsecutiveMatrices_WhenCalculateDotProductList_ThenThrowsArgumentException()
    {
        // Arrange
        var a = CreateFilledMatrix(2, 3, 1);
        var b = CreateFilledMatrix(4, 2, 1); // rows != previous cols -> incompatible with a
        var list = new List<int[,]> { a, b };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _dotProductCalculator.CalculateDotProduct(list));
    }

    [Test]
    public void GivenSingleMatrixInList_WhenCalculateDotProductList_ThenReturnsTheSameMatrixAndNoMultiplicationsOccur()
    {
        // Arrange
        var a = CreateFilledMatrix(3, 3, 2);
        var list = new List<int[,]> { a };

        // Act
        var result = _dotProductCalculator.CalculateDotProduct(list);

        // Assert
        AssertMatrixEquals(a, result);
        Assert.That(_dotProductCalculator.MatrixMultiplicationCount, Is.EqualTo(0));
    }
}