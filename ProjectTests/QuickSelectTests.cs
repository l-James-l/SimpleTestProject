using Project;

namespace ProjectTests;

public class QuickSelectTests
{
	private QuickSelect _quickSelect;

	[SetUp]
	public void Setup()
	{
		_quickSelect = new QuickSelect();
	}

	[Test]
	public void GivenUnsortedArray_WhenSelectKthZero_ThenReturnsMinimum()
	{
		// Arrange
		int[] array = new[] {5,3,8,1,4 };
		int k =0;
		int expected = array.OrderBy(x => x).ElementAt(k);

		// Act
		var result = _quickSelect.Select(array, k);

		// Assert
		Assert.That(result, Is.EqualTo(expected));
	}

	[Test]
	public void GivenUnsortedArray_WhenSelectKthMiddle_ThenReturnsCorrectElement()
	{
		// Arrange
		int[] array = new[] {10,7,2,9,1,5 };
		int k =3; // zero-based
		int expected = array.OrderBy(x => x).ElementAt(k);

		// Act
		var result = _quickSelect.Select(array, k);

		// Assert
		Assert.That(result, Is.EqualTo(expected));
	}

	[Test]
	public void GivenArrayWithDuplicates_WhenSelect_ThenReturnsCorrectElement()
	{
		// Arrange
		int[] array = new[] {4,1,2,2,4,3 };
		int k =2;
		int expected = array.OrderBy(x => x).ElementAt(k);

		// Act
		var result = _quickSelect.Select(array, k);

		// Assert
		Assert.That(result, Is.EqualTo(expected));
	}

	[Test]
	public void GivenSingleElementArray_WhenSelectZero_ThenReturnsThatElement()
	{
		// Arrange
		int[] array = new[] {42 };
		int k =0;

		// Act
		var result = _quickSelect.Select(array, k);

		// Assert
		Assert.That(result, Is.EqualTo(42));
	}

	[Test]
	public void GivenNegativeK_WhenSelect_ThenThrowsArgumentOutOfRangeException()
	{
		// Arrange
		int[] array = new[] {1,2,3 };
		int k = -1;

		// Act & Assert
		Assert.Throws<ArgumentOutOfRangeException>(() => _quickSelect.Select(array, k));
	}

	[Test]
	public void GivenKGreaterThanLength_WhenSelect_ThenThrowsArgumentOutOfRangeException()
	{
		// Arrange
		int[] array = new[] {1,2,3 };
		int k = array.Length +1;

		// Act & Assert
		Assert.Throws<ArgumentOutOfRangeException>(() => _quickSelect.Select(array, k));
	}

	[Test]
	public void GivenArray_WhenQuickSelectWithMedianOfMedians_ThenReturnsSameAsSelect()
	{
		// Arrange
		int[] array = Enumerable.Range(1,50).Reverse().ToArray();
		int[] ks = new[] {0,10,25,49 };

		// Act & Assert
		foreach (var k in ks)
		{
			int expected = _quickSelect.Select(array, k);
			int result = _quickSelect.QuickSelectWithMedianOfMedians(array, k);
			Assert.That(result, Is.EqualTo(expected));
		
		}
	}

	[Test]
	public void GivenRandomArray_WhenSelect_ThenMatchesSortedElement()
	{
		// Arrange
		var rnd = new Random(123);
		int[] array = Enumerable.Range(0,100).Select(_ => rnd.Next(0,1000)).ToArray();
		int k =37;
		int expected = array.OrderBy(x => x).ElementAt(k);

		// Act
		var result = _quickSelect.Select(array, k);

		// Assert
		Assert.That(result, Is.EqualTo(expected));
	}
}
