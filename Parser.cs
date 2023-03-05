using AssemblerCore.Commands;

namespace AssemblerCore
{
    public enum IType
    {
        PushCommand, PopCommand, Operation
    }

    public class Parser
    {
        private List<Command> _instructions;

        public Parser()
        {
            _instructions = new List<Command>();
        }

        public List<Command> GetParsedLines()
        {
            return _instructions;
        }

        public void Parse(string filePath)
        {
            var rawLines = _readFile(filePath);
            var cleanedLines = new List<string>();
            rawLines.ForEach(line =>
            {
                line.Trim();
                if (!line.StartsWith("//") && !String.IsNullOrEmpty(line))
                {
                    if (line.Contains("//"))
                    {
                        line = line.Split("//")[0].Trim();
                    }
                    cleanedLines.Add(line.Trim());
                }
            });

            // pretranslate lines
            // lines ready for translation
        }

        private List<string> _readFile(string filePath)
        {
            return new List<string>(File.ReadAllLines(filePath));
        }

        private string _writePushCommand(string line)
        {
            return "";
        }

        private string _writePopCommand(string line)
        {
            return "";
        }

        private string _writeOperation(string line)
        {
            return "";
        }

        private IType _instructionType(string line)
        {
            return IType.PushCommand;
        }
    }
}
