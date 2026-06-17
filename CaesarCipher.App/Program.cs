// See https://aka.ms/new-console-template for more information
using System.CommandLine;
using System.Drawing;
using System.Text;
using CaesarCipher.Lib;

Option<FileInfo> fileOption = new("--file")
{
    Description = "The file to encode/decode"
};

Option<bool> decodeOption = new("--decode") { Description = "Decode, the default is encode" };

Option<int> rotateCountOption = new("--count") { Description = "How many steps to rotate the cipher", DefaultValueFactory = _ => 13 };

Option<bool> sillyOption = new("--silly") { Description = "Be silly with the output" };

var rootCommand = new RootCommand("Caesar cipher demo");
rootCommand.Options.Add(fileOption);
rootCommand.Options.Add(decodeOption);
rootCommand.Options.Add(rotateCountOption);
rootCommand.Options.Add(sillyOption);

var parseResult = rootCommand.Parse(args);
var file = parseResult.GetValue(fileOption);
var shouldDecode = parseResult.GetValue(decodeOption);
var rotateCount = parseResult.GetValue(rotateCountOption);
var beSilly = parseResult.GetValue(sillyOption);

var contents = File.ReadAllLines(file!.FullName);

var cipher = new Caesar(rotateCount);
var resultBuilder = new StringBuilder();
foreach (var line in contents)
{
    if (beSilly)
    {
        var currentColor = Console.ForegroundColor;
        var consoleWidth = Console.WindowWidth;    
        var handledLine = shouldDecode ? cipher.Decode(line) : cipher.Encode(line);
        var rowsForLine = (int)Math.Ceiling((decimal)handledLine.Length / consoleWidth);

        Console.WriteLine($"{consoleWidth} - {rowsForLine}");

        for (int i = 0; i < line.Length; i++)
        {
            var currentPosition = Console.GetCursorPosition();
            var decodedPart = new string(handledLine.Take(i + 1).ToArray());
            var rowsForDecodedPart = (int)Math.Ceiling((decimal)decodedPart.Length / consoleWidth);
            var jibberish = GetJibberish(line);
            Console.ForegroundColor = GetRandomConsoleColor();
            Console.WriteLine(shouldDecode ? jibberish : line);
            Console.SetCursorPosition(0, Console.CursorTop - rowsForLine);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(decodedPart);
            Console.SetCursorPosition(0, Console.CursorTop - rowsForDecodedPart);
            Thread.Sleep(25);
        }
    }

    Console.WriteLine(shouldDecode ? cipher.Decode(line) : cipher.Encode(line));
}

string GetJibberish(string text)
{
    var returnable = new StringBuilder();

    foreach (var character in text)
    {
        if (char.IsWhiteSpace(character))
        {
            returnable.Append(character);
        }
        else
        {
            returnable.Append((char)('a' + new Random().Next(0, 26)));
        }
    }

    return returnable.ToString();
}

ConsoleColor GetRandomConsoleColor()
{
    return (ConsoleColor)new Random().Next(0, 16);
}