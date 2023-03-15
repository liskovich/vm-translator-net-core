namespace VMTranslator
{
    public static class Helper
    {
        private static int _jumpIndex;
        private static int _labels;

        static Helper()
        {
            _jumpIndex = 0;
            _labels = 0;
        }

        // JMP index
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

        // Available label
        public static int GetLabel()
        {
            return _labels;
        }

        public static void IncreaseLabel()
        {
            _labels++;
        }

        public static void RefreshLabel()
        {
            _labels = 0;
        }
    }
}