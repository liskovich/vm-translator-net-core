using AssemblerCore;

class Program {
    static void Main(string[] args) {
        Parser parser = new Parser();
        parser.Parse(args[0]);

        var lines = parser.GetParsedLines();
        lines.ForEach(line =>
        {
            if (lines.IndexOf(line) % 1000 == 0) Console.WriteLine("Loading...");
        });

        // generate .asm files
    }
}