using System.Text;

namespace CaesarCipher.Lib;

public class Caesar(int rotation, string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅabcdefghijklmnopqrstuvwxyzæøå0123456789.-_ !")
{
    private char EncodeChar(int position) => alphabet[(position + rotation) % alphabet.Length];

    private char DecodeChar(int position)
    {
        var selector = position - rotation;
        if (selector < 0) selector = alphabet.Length + selector;
        return alphabet[selector];
    }

    public string Encode(string text)
    {
        var returnable = new StringBuilder();

        foreach (var character in text)
        {
            if (alphabet.Contains(character))
            {
                returnable.Append(EncodeChar(alphabet.IndexOf(character)));
            }
            else
            {
                returnable.Append("#");
            }
        }

        return returnable.ToString();
    }

    public string Decode(string text)
    {
        var returnable = new StringBuilder();

        foreach (var character in text)
        {
            if (alphabet.Contains(character))
            {
                returnable.Append(DecodeChar(alphabet.IndexOf(character)));
            }
            else
            {
                returnable.Append("#");
            }
        }

        return returnable.ToString();
    }
}
