using ReactSPA6_ALL.Debugging;

namespace ReactSPA6_ALL
{
    public class ReactSPA6_ALLConsts
    {
        public const string LocalizationSourceName = "ReactSPA6_ALL";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "11d3e847c5cd47589131909d23fcb5ff";
    }
}
