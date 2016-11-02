namespace HighwayToHell.GUI
{
    class Main
    {
        private static Version _version = Version.White;
        public Main(Version version)
        {
            _version = version;
        }

        public static Version GetVersion()
        {
            return _version;
        }
        internal enum Version
        {
            Black, White
        }
    }
}
