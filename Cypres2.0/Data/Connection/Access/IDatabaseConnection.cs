using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cypres2._0.Data.Connection.Access
{
    public interface IDatabaseConnection
    {
        OleDbConnection GetOpenConnection();
    }
}
