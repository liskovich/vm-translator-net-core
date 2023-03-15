namespace VMTranslator.Commands
{
    class ReturnCmd : Command
    {
        private string _commandText;

        private string _asmCommandText;

        public string CommandText 
        {
            get { return _asmCommandText; }
        }

        public ReturnCmd(string vmCommand) 
        {
            _commandText = vmCommand;
            _asmCommandText = "//" + _commandText + "\n";
        }

        public void ConvertToAsm()
        {            
            _asmCommandText += "@LCL\nD=M\n@R11\nM=D\n@5\nA=D-A\nD=M\n@R12\nM=D\n" +
                _popTemplate(0, "ARG", false) + "@ARG\nD=M\n@SP\nM=D+1\n" +
                _template("THAT") + _template("THIS") + _template("ARG") + _template("LCL") + "@R12\nA=M\n0;JMP\n";
        }

        private string _template(string location){
            return "@R11\nD=M-1\nAM=D\nD=M\n@" + location + "\nM=D\n";
        }

        private string _popTemplate(int idx, string location, bool isPointer)
        {
            string code = (isPointer)? "D=A\n" : "D=M\n@" + idx + "\nD=D+A\n";

            return "@" + location + "\n" + code + "@R13\nM=D\n@SP\nAM=M-1\nD=M\n@R13\nA=M\nM=D\n";
        }
    }
}