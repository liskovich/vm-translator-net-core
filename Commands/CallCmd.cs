namespace VMTranslator.Commands
{
    class CallCmd : Command
    {
        private string _commandText;

        private string _asmCommandText;

        public string CommandText 
        {
            get { return _asmCommandText; }
        }

        public CallCmd(string vmCommand) 
        {
            _commandText = vmCommand;
            _asmCommandText = "//" + _commandText + "\n";
        }

        public void ConvertToAsm()
        {        
            var segments = _commandText.Split(' ').ToList();
            var name = segments[1].Trim();
            var idx = int.Parse(segments[2].Trim());

            var lbl = "RETURN_LABEL" + Helper.GetLabel();
            Helper.IncreaseLabel();
            
            _asmCommandText += "@" + lbl + "\nD=A\n@SP\nA=M\nM=D\n@SP\nM=M+1\n";
            _asmCommandText += _template(0, "LCL", true);
            _asmCommandText += _template(0, "ARG", true);
            _asmCommandText += _template(0, "THIS", true);
            _asmCommandText += _template(0, "THAT", true);

            _asmCommandText += "@SP\nD=M\n@5\nD=D-A\n" +
                "@" + idx + "\nD=D-A\n@ARG\nM=D\n@SP\nD=M\n@LCL\nM=D\n" +
                "@" + name + "\n0;JMP\n(" + lbl + ")\n";
        }

        private string _template(int idx, string location, bool isPointer)
        {
            string code = (isPointer)? "" : "@" + idx + "\nA=D+A\nD=M\n";

            return "@" + location + "\nD=M\n"+ code + "@SP\nA=M\nM=D\n@SP\nM=M+1\n";
        }
    }
}