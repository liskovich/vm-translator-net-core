namespace VMTranslator.Commands
{
    class PopCmd : Command
    {
        private string _commandText;

        private string _asmCommandText;

        public string CommandText 
        {
            get { return _asmCommandText; }
        }

        public PopCmd(string vmCommand) 
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
            string code = (isPointer)? "D=A\n" : "D=M\n@" + idx + "\nD=D+A\n";

            return "@" + location + "\n" + code + "@R13\nM=D\n@SP\nAM=M-1\nD=M\n@R13\nA=M\nM=D\n";
        }
    }
}