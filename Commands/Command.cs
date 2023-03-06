namespace VMTranslator.Commands
{
    public interface Command
    {
        public string CommandText { get; }

        public void ConvertToAsm();
    }
}
