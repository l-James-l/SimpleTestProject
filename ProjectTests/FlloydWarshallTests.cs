using Project;

namespace ProjectTests;

public class FlloydWarshallTests
{
	private FlloydWarshall _flloydWarshal;

	private const int INF = 1000000;


    [SetUp]
	public void Setup()
	{
		_flloydWarshal = new FlloydWarshall();
	}

	private static void AssertMatrixEquals(int[,] expected, int[,] actual)
	{
		Assert.That(actual.GetLength(0), Is.EqualTo(expected.GetLength(0)), "Row count mismatch");
		Assert.That(actual.GetLength(1), Is.EqualTo(expected.GetLength(1)), "Column count mismatch");

		for (int i =0; i < expected.GetLength(0); i++)
		{
			for (int j =0; j < expected.GetLength(1); j++)
			{
				Assert.That(actual[i, j], Is.EqualTo(expected[i, j]), $"Value mismatch at [{i},{j}]");
			}
		}
	}

	[Test]
	public void GivenSingleVertexMatrix_WhenFindShortestPaths_ThenReturnsSameMatrix()
	{
		// Arrange
		int[,] matrix = new int[,] { { 0 } };

		// Act
		var result = _flloydWarshal.FindShortestPaths(matrix);

		// Assert
		AssertMatrixEquals(matrix, result);
	}

	[Test]
	public void GivenAdjacencyMatrix_WhenFindShortestPaths_ThenReturnsExpectedShortestDistances()
	{
		// Arrange
		int[,] adjacency = new int[,]
		{
			{ 0, 5, INF, 10},
			{ INF, 0, 3, INF},
			{ INF, INF, 0, 1},
			{ INF, INF, INF, 0}
		};

		int[,] expected = new int[,]
		{
            { 0, 5, 8, 9 },
			{ INF, 0, 3, 4 },
			{ INF, INF, 0, 1 },
			{ INF, INF, INF, 0 }
		};

		// Act
		var result = _flloydWarshal.FindShortestPaths(adjacency);

		// Assert
		AssertMatrixEquals(expected, result);
	}

	[Test]
	public void GivenAlreadyShortestPaths_WhenFindShortestPaths_ThenMatrixRemainsUnchanged()
	{
		// Arrange
		int[,] adjacency = new int[,]
		{
			{ 0, 2, 5 },
			{ INF, 0, 3 },
			{ INF, INF, 0 }
		};

		int[,] expected = (int[,])adjacency.Clone();

		// Act
		var result = _flloydWarshal.FindShortestPaths(adjacency);

		// Assert
		AssertMatrixEquals(expected, result);
	}
}
