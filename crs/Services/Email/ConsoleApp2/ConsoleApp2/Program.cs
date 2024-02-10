using System.Text;


Console.OutputEncoding = Encoding.Unicode;
var text = File.ReadAllText("text.txt");
var textSplit = text.Split(".").Zip((a, b) => a + b);


foreach (var item in textSplit)
{
    Console.WriteLine(item);
}





