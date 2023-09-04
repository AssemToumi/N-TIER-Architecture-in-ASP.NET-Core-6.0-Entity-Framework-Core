using System;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore.Infrastructure;

namespace Helper
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder UseOracleProvider(this DbContextOptionsBuilder optionsBuilder, string connectionString, OracleVersion? version = null)
        {
            EnsureConnectionStringIsValid(connectionString);
            Action<OracleDbContextOptionsBuilder> oracleOptionsAction = null;
            if (version.HasValue)
            {
                oracleOptionsAction = delegate (OracleDbContextOptionsBuilder opts)
                {
                    opts.UseOracleSQLCompatibility(version.Value.ToString());
                };
            }

            optionsBuilder.UseOracle(connectionString, oracleOptionsAction);
            return optionsBuilder;
        }

        public static DbContextOptionsBuilder UseMsSqlServerProvider(this DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            EnsureConnectionStringIsValid(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            return optionsBuilder;
        }

        private static void EnsureConnectionStringIsValid(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("Missing connection string!", "connectionString");
            }
        }
    }
}
