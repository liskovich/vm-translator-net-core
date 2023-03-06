using VMTranslator.Commands;

namespace VMTranslator
{
    public class AsmGenerator
    {
        private List<Command> _commands;

        public AsmGenerator(List<Command> command)
        {
            _commands = command;
        }

        private List<string> _generateFileContent()
        {
            var asmInstructions = new List<string>();
            _commands.ForEach(command =>
            {
                command.ConvertToAsm();
                var asmInstruction = command.CommandText;
                asmInstructions.Add(asmInstruction);
            });
            return asmInstructions;
        }

        public async Task GenerateAsmFile(string filePath = "prog.asm")
        {
            var lines = _generateFileContent();
            await File.WriteAllLinesAsync(filePath, lines);
        }
    }
}