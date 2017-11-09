using Izenda.BI.DataAdaptor;
using Izenda.BI.DataAdaptor.RDBMS.SQL;
using Izenda.BI.Framework;
using Izenda.BI.Framework.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Izenda.CustomSQL
{
    /// <summary>
    /// Microsoft SQL Data source adaptor
    /// This example below will add a new data server type in the reporting connection string dropdown
    /// You can set any items you would like to alter to this data server type then you have full control to modify it when used
    /// One note here we normally show the data server type in the connection string list but this is not showing with the custom type currently which we have reported
    /// </summary>
    [Export(typeof(IDataSourceAdaptor))]
    [ExportMetadata("ServerType", "2510341B-AE1D-4D7C-98C2-2D6E0BB2E3E9|MSSQL1|[MSSQL1] Adhoc SQLServer")]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AdhocSQLDataSourceAdaptor : SQLDataSourceAdaptor
    {
        public override IConnection Connection
        {
            get
            {
                return new AdhocSQLConnection();
            }
        }
    }
}
