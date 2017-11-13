using Izenda.BI.QueryNormalizer.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Izenda.BI.Framework.Models.Contexts;
using Izenda.BI.Logging.Log4Net;
using Izenda.BI.Logging;

namespace Izenda.CustomSQL
{
    /// <summary>
    /// This example will allow you to alter the query to add something like nocount or execute as
    /// This will effect all queries (both to the Izenda config db and your reporting db)
    /// If you do not add the reporting users to the Izenda database you will need to use something like the table name prefixed by Izenda to not wrap these
    /// </summary>
    public class AdhocQueryNormalizer : SQLQueryNormalizerActivity
    {
        private readonly ILog Logger = (new LogManager()).GetLogger(typeof(AdhocQueryNormalizer));
        public override int Order => 100;

        public override void Execute(QueryNormalizerContext context)
        {
            Logger.Info($"Overriding the query: {context.Query}");

            //add your code here to modify the Izenda query as needed example below
            //context.Query = $"SET NOCOUNT ON; {context.Query} SET NOCOUNT OFF;";
        }
    }
}
