using VMTranslator.Commands;

namespace VMTranslator
{
    public enum IType
    {
        PushCommand, PopCommand, Operation, 
        Label, Return, IfStatement, Goto, Function, Call
    }

    public class Parser
    {
        private List<Command> _commands;

        public Parser()
        {
            _commands = new List<Command>();
        }

        public List<Command> GetParsedLines()
        {
            return _commands;
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

            _preTranslationList(rawLines);
        }

        private List<string> _readFile(string filePath)
        {
            return new List<string>(File.ReadAllLines(filePath));
        }

        private void _preTranslationList(List<string> lines)
        {
            lines.ForEach(line =>
            {
                var commandType = _commandType(line);

                Command command;
                switch (commandType)
                {
                    case IType.PushCommand:
                        command = new PushCmd(line);
                        _commands.Add(command);
                        break;
                    case IType.PopCommand:
                        command = new PopCmd(line);
                        _commands.Add(command);
                        break;
                    case IType.Operation:
                        command = new OperatorCmd(line);
                        _commands.Add(command);
                        break;
                    case IType.Label:
                        command = new LabelCmd(line);
                        _commands.Add(command);
                        break;
                    case IType.IfStatement:
                        command = new IfCmd(line);
                        _commands.Add(command);
                        break;
                    case IType.Goto:
                        command = new GotoCmd(line);
                        _commands.Add(command);
                        break;
                    case IType.Function:
                        command = new FunctionCmd(line);
                        _commands.Add(command);
                        break;
                    case IType.Call:
                        command = new CallCmd(line);
                        _commands.Add(command);
                        break;
                    case IType.Return:
                        command = new ReturnCmd(line);
                        _commands.Add(command);
                        break;
                }
            });
        }

        private IType _commandType(string line)
        {
            if (line.Trim().StartsWith("push")) return IType.PushCommand;
            else if (line.Trim().StartsWith("pop")) return IType.PopCommand;
            else if (line.Trim().StartsWith("label")) return IType.Label;
            else if (line.Trim().StartsWith("if")) return IType.IfStatement;
            else if (line.Trim().StartsWith("goto")) return IType.Goto;
            else if (line.Trim().StartsWith("function")) return IType.Function;
            else if (line.Trim().StartsWith("call")) return IType.Call;
            else if (line.Trim().StartsWith("return")) return IType.Return;
            else return IType.Operation;
        }
    }
}
