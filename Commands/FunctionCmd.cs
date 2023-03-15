namespace VMTranslator.Commands
{
    class FunctionCmd : Command
    {
        private string _commandText;

        private string _asmCommandText;

        public string CommandText 
        {
            get { return _asmCommandText; }
        }

        public FunctionCmd(string vmCommand) 
        {
            _commandText = vmCommand;
            _asmCommandText = "//" + _commandText + "\n";
        }

        public void ConvertToAsm()
        {
            var segments = _commandText.Split(' ').ToList();
            var name = segments[1].Trim();
            var idx = int.Parse(segments[2].Trim());

            _asmCommandText += "(" + name + ")\n";
            for (int i = 0; i < idx; i++) {
                _asmCommandText += "@" + i + "\nD=A\n@SP\nA=M\nM=D\n@SP\nM=M+1\n";
            }
        }
    }
}