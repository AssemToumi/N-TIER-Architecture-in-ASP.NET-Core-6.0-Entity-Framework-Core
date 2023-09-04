using Helper;
using WholesBrew.DataAccess.Enums;

namespace WholesBrew.DataAccess.Configuration;

public class DatabaseSettings
{
    public Providers Provider { get; set; }

    public OracleSettings? OracleOptions { get; set; }
}
