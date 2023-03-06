namespace VMTranslator
{
    public static class Helper
    {
        private static int _jumpIndex;

        static Helper()
        {
            _jumpIndex = 0;
        }

        public static int GetJumpIndex()
        {
            return _jumpIndex;
        }

        public static void IncreaseJumpIndex()
        {
            _jumpIndex++;
        }

        public static void RefreshJumpIndex()
        {
            _jumpIndex = 0;
        }
    }
}