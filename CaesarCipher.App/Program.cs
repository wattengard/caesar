// See https://aka.ms/new-console-template for more information
using System.CommandLine;
using System.Text;
using CaesarCipher.Lib;

Option<FileInfo> fileOption = new("--file")
{
    Description = "The file to encode/decode"
};

Option<bool> decodeOption = new("--decode") { Description = "Decode, the default is encode" };

Option<int> rotateCountOption = new("--count") { Description = "How many steps to rotate the cipher", DefaultValueFactory = _ => 13 };

var rootCommand = new RootCommand("Caesar cipher demo");
rootCommand.Options.Add(fileOption);
rootCommand.Options.Add(decodeOption);
rootCommand.Options.Add(rotateCountOption);

var parseResult = rootCommand.Parse(args);
var file = parseResult.GetValue(fileOption);
var shouldDecode = parseResult.GetValue(decodeOption);
var rotateCount = parseResult.GetValue(rotateCountOption);

var contents = File.ReadAllLines(file!.FullName);

var cipher = new Caesar(rotateCount);
var resultBuilder = new StringBuilder();
foreach (var line in contents)
{
    resultBuilder.AppendLine(shouldDecode ? cipher.Decode(line) : cipher.Encode(line));
}
var result = resultBuilder.ToString();

Console.WriteLine($"Result:\n{result}");

