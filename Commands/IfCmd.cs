namespace VMTranslator.Commands
{
    class IfCmd : Command
    {
        private string _commandText;

        private string _asmCommandText;

        public string CommandText 
        {
            get { return _asmCommandText; }
        }

        public IfCmd(string vmCommand) 
        {
            _commandText = vmCommand;
            _asmCommandText = "//" + _commandText + "\n";
        }

        public void ConvertToAsm()
        {            
            var segments = _commandText.Split(' ').ToList();
            var label = segments[1].Trim();
            _asmCommandText += _template() + "@" + label + "\nD;JNE\n"; 
        }

        private string _template()
        {
            return "@SP\nAM=M-1\nD=M\nA=A-1\n";
        }
    }
}