using CaesarCipher.Lib;
using Shouldly;

namespace CaesarCipher.Tests;

public class Tests
{
    private const string TEST_ALPHABET = "abcdef";
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("abc", "cde", 2)]
    [TestCase("abc", "def", 3)]
    [TestCase("face", "bcea", 2)]
    public void Should_encode_correctly(string input, string output, int amount_to_rotate)
    {
        var cipher = new Caesar(amount_to_rotate, TEST_ALPHABET);
        var result = cipher.Encode(input);
        result.ShouldBe(output);
    }

    [TestCase("cde", "abc", 2)]
    [TestCase("def", "abc", 3)]
    [TestCase("bcea", "face", 2)]
    public void Should_decode_correctly(string input, string output, int amount_to_rotate)
    {
        var cipher = new Caesar(amount_to_rotate, TEST_ALPHABET);
        var result = cipher.Decode(input);
        result.ShouldBe(output);
    }

    [Test]
    public void Should_handle_zero_rotation()
    {
        var text = "bcd";
        var cipher = new Caesar(0, TEST_ALPHABET);
        var result = cipher.Decode(text);
        result.ShouldBe(text);
    }

    [TestCase("abc!d")]
    [TestCase("!#¤%&")]
    public void Should_not_replace_unknown_characters(string input)
    {
        var cipher = new Caesar(0, TEST_ALPHABET);
        var result = cipher.Encode(input);
        result.ShouldBe(input);
    }
}
