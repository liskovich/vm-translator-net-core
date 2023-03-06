using VMTranslator;

class Program {
    static void Main(string[] args) {
        Parser parser = new Parser();
        parser.Parse(args[0]);

        var lines = parser.GetParsedLines();
        lines.ForEach(line =>
        {
            if (lines.IndexOf(line) % 1000 == 0) Console.WriteLine("Loading...");
        });

        var codeGenerator = new AsmGenerator(lines);
        Helper.RefreshJumpIndex();

        Task.Run(async () =>
        {
            await codeGenerator.GenerateAsmFile($"{args[1]}.asm");
            Console.WriteLine("File loaded");
        }).Wait();
    }
}