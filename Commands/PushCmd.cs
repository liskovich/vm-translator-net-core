namespace VMTranslator.Commands
{
    class PushCmd : Command
    {
        private string _commandText;

        private string _asmCommandText;

        public string CommandText 
        {
            get { return _asmCommandText; }
        }

        public PushCmd(string vmCommand) 
        {
            _commandText = vmCommand;
            _asmCommandText = "//" + _commandText + "\n";
        }

        public void ConvertToAsm()
        {
            var segments = _commandText.Split(' ').ToList();
            var location = segments[1].Trim();
            var idx = int.Parse(segments[2].Trim());
            
            switch (location)
            {
                case "constant":
                    _asmCommandText += "@" + idx + "\nD=A\n@SP\nA=M\nM=D\n@SP\nM=M+1\n";
                    break;
                case "local":
                    _asmCommandText += _template(idx, "LCL", false);
                    break;
                case "argument":
                    _asmCommandText += _template(idx, "ARG", false);
                    break;
                case "this":
                    _asmCommandText += _template(idx, "THIS", false);
                    break;
                case "that":
                    _asmCommandText += _template(idx, "THAT", false);
                    break;
                case "temp":
                    _asmCommandText += _template(idx + 5, "R5", false);
                    break;
                case "pointer":
                    if (idx == 0) _asmCommandText += _template(idx, "THIS", true);
                    if (idx == 1) _asmCommandText += _template(idx, "THAT", true);
                    break;
                case "static":
                    _asmCommandText += _template(idx, (idx + 16).ToString(), true);
                    break;
                default:
                    break;
            }
        }

        private string _template(int idx, string location, bool isPointer)
        {
            string code = (isPointer)? "" : "@" + idx + "\nA=D+A\nD=M\n";

            return "@" + location + "\nD=M\n"+ code + "@SP\nA=M\nM=D\n@SP\nM=M+1\n";
        }
    }
}