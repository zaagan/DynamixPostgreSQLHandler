
/// <summary>
/// References: https://github.com/SageFrame/SageFrameV3.6/tree/master/SageFrame.Common/Shared
/// </summary>

namespace DynamixPostgreSQLHandler
{
    public partial class SQLHandler
    {

        public SQLHandler() { }

        public SQLHandler(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }

    }
}
