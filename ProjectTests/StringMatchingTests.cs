using Project.StringMatching;

namespace ProjectTests;

public class StringMatchingTests
{
    [Test]
    public void TestSimpleStringMatcher()
    {
        Assert.That("abcdefghijk".SimpleStringMatcher("cde"), Is.EqualTo(2));
        Assert.That("abcdefghijk".SimpleStringMatcher("not in"), Is.EqualTo(-1));
        Assert.That("abcdefghijk".SimpleStringMatcher("ijk"), Is.EqualTo(8));
        Assert.That("abcdefghijk".SimpleStringMatcher("abcdef"), Is.EqualTo(0));
    }

    [Test]
    public void TestMpMatching()
    {
        Assert.That("ababcabccababcababccabab".MpMatching("abccabab"), Is.EqualTo(5));
        Assert.That("abcdefghijk".MpMatching("not in"), Is.EqualTo(-1));
        Assert.That("abcdefghijk".MpMatching("ijk"), Is.EqualTo(8));
        Assert.That("abcdefghijk".MpMatching("ijkl"), Is.EqualTo(-1));
        Assert.That("abcdefghijk".MpMatching("abcdef"), Is.EqualTo(0));
    }

    [Test]
    public void TestKmpMatching()
    {
        Assert.That("ababcabccababcababccabab".KmpMatching("abccabab"), Is.EqualTo(5));
        Assert.That("abcdefghijk".KmpMatching("not in"), Is.EqualTo(-1));
        Assert.That("abcdefghijk".KmpMatching("ijk"), Is.EqualTo(8));
        Assert.That("abcdefghijk".KmpMatching("ijkl"), Is.EqualTo(-1));
        Assert.That("abcdefghijk".KmpMatching("abcdef"), Is.EqualTo(0));
    }

    [Test]
    public void ApproxKMatchTests()
    {
        //Assert.That("Have a happe birthday".FirstKMatch("happy", 1), Is.EqualTo(6));
        //Assert.That("Have a happy birthday".FirstKMatch("happy", 0), Is.EqualTo(7));
        //Assert.That("Have a hapy birthday".FirstKMatch("happy", 1), Is.EqualTo(7));
    }

    [Test]
    public void LongestCommonSubsequenceTests()
    {
        Assert.That("AGGTAB".LCS("GXTXAYB"), Is.EqualTo(4));
    }
}

