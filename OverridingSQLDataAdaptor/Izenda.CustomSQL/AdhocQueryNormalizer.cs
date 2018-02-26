using System.Linq;
using Izenda.BI.QueryNormalizer.SQL;
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
            if (context.Query.Contains(" IN (") && context.Query.Contains("'[' + c.Name + '].[' + qsc.Name + '].[' + qs.Name + '].[' + qsf.Name + ']'"))
            {
                var lastIndex = context.Query.LastIndexOf("IN");
                var fields = context.Query.Substring(lastIndex + 4).Split(',');

                var count = fields.Count();
                fields[count - 1] = fields[count - 1].Replace(")", "");

                if (count > 10000)                {
                    Logger.Info($"Overriding the query: {context.Query}");

                    var query = $@"DECLARE @fields AS FieldIds
                                INSERT INTO @fields
                                    SELECT Id FROM 
                                    (
                                        VALUES 
                                        ({string.Join("),(", fields)})
                                    )  X (Id)
                                EXEC sp_getFieldUniqueNamesByIds @fields";

                    context.Query = query;
                }
            }
        }
    }
}

