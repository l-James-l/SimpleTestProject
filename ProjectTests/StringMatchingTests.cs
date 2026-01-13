using Project;

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
}

