using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airlanes.Model
{
    public static class ConnectionHelper
    {
        public const string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=local_db.mdb";
    }
}
