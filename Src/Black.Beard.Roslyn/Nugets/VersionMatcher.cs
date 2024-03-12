
using Bb.Nugets.Versions;

namespace Bb.Nugets
{

    public class VersionMatcher
    {

        /// <summary>
        /// Parse the package nuget version constraint
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static ConstraintVersion Parse(string version)
        {
            var _lexer = new VersionLexer(version);
            return _lexer.Parse() ?? new ConstraintVersion();
        }

    }

}
