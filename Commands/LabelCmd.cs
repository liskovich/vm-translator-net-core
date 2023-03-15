namespace VMTranslator.Commands
{
    class LabelCmd : Command
    {
        private string _commandText;

        private string _asmCommandText;

        public string CommandText 
        {
            get { return _asmCommandText; }
        }

        public LabelCmd(string vmCommand) 
        {
            _commandText = vmCommand;
            _asmCommandText = "//" + _commandText + "\n";
        }

        public void ConvertToAsm()
        {            
            var segments = _commandText.Split(' ').ToList();
            var label = segments[1].Trim();
            _asmCommandText += "(" + label + ")\n";   
        }
    }
}