// See https://aka.ms/new-console-template for more information

using ReadText;
using TextReader = ReadText.TextReader;

Console.WriteLine("Hello, World!");

var textReader = new TextReader("Velg kategori", "forrett", "middag", "dessert");
var category = textReader.ReadText();

Console.WriteLine($"Du valgte {category}.");