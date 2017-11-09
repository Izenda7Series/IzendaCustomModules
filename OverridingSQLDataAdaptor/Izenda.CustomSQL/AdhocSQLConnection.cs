using Izenda.BI.Logging;
using Izenda.BI.Logging.Log4Net;
using Izenda.BI.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Izenda.CustomSQL
{
    /// <summary>
    /// This is the actual override of the connection string below
    /// </summary>
    public class AdhocSQLConnection : SQLConnection
    {
        private readonly ILog Logger = (new LogManager()).GetLogger(typeof(AdhocSQLConnection));

        public override IDbConnection OpenConnection(string connectionString)
        {
            Logger.Info($"Overriding the connection string {connectionString}");

            return base.OpenConnection(connectionString);
        }
    }
}
