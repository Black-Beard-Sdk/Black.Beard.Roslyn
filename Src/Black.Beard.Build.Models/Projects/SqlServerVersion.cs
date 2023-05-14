namespace Bb.Projects
{
    public class SqlServerVersion : PropertyKey
    {


        public SqlServerVersion(string value) : base("SqlServerVersion", value)
        {

        }

        public static SqlServerVersion SqlAzure { get; } = new SqlServerVersion("SqlAzure");

        /// <summary>
        /// By default
        /// </summary>
        public static SqlServerVersion Sql150 { get; } = new SqlServerVersion("Sql150");


    }

}
