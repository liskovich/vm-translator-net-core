namespace VMTranslator.Commands
{
    class OperatorCmd : Command
    {
        private string _commandText;

        private string _asmCommandText;

        public string CommandText 
        {
            get { return _asmCommandText; }
        }

        public OperatorCmd(string vmCommand) 
        {
            _commandText = vmCommand;
            _asmCommandText = "//" + _commandText + "\n";
        }

        public void ConvertToAsm()
        {            
            switch (_commandText.Trim())
            {
                case "add":
                    _asmCommandText += _template() + "M=M+D\n";
                    break;
                case "sub":
                    _asmCommandText += _template() + "M=M-D\n";
                    break;
                case "and":
                    _asmCommandText += _template() + "M=M&D\n";
                    break;
                case "or":
                    _asmCommandText += _template() + "M=M|D\n";
                    break;
                case "gt":
                    _asmCommandText += _operatorTemplate("JLE");
                    Helper.IncreaseJumpIndex();
                    break;
                case "lt":
                    _asmCommandText += _operatorTemplate("JGE");
                    Helper.IncreaseJumpIndex();
                    break;
                case "eq":
                    _asmCommandText += _operatorTemplate("JNE");
                    Helper.IncreaseJumpIndex();
                    break;
                case "not":
                    _asmCommandText += "@SP\nA=M-1\nM=!M\n";
                    break;
                case "neg":
                    _asmCommandText += "D=0\n@SP\nA=M-1\nM=D-M\n";
                    break;
                default:
                    break;
            }
        }

        private string _template()
        {
            return "@SP\nAM=M-1\nD=M\nA=A-1\n";
        }

        private string _operatorTemplate(string operation)
        {
            var jumpIndex = Helper.GetJumpIndex();
            return "@SP\nAM=M-1\nD=M\nA=A-1\nD=M-D\n@FALSE" + jumpIndex + "\n" +
                "D;" + operation + "\n@SP\nA=M-1\nM=-1\n" +
                "@CONTINUE" + jumpIndex + "\n0;JMP\n" +
                "(FALSE" + jumpIndex + ")\n@SP\nA=M-1\nM=0\n" +
                "(CONTINUE" + jumpIndex + ")\n";
        }
    }
}