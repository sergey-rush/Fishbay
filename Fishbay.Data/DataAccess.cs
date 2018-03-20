using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Fishbay.Data
{
    public abstract class DataAccess
    {
        protected virtual string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["SqlServer"].ToString(); }
        }

        public static PriceItemManager PriceItems
        {
            get { return PriceItemManager.Instance; }
        }
        public static PartnerManager Partners
        {
            get { return PartnerManager.Instance; }
        }

        public static NewsManager NewsItems
        {
            get { return NewsManager.Instance; }
        }

        public static UserManager Users
        {
            get { return UserManager.Instance; }
        }

        protected int ExecuteNonQuery(DbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        protected IDataReader ExecuteReader(SqlCommand dbCommand)
        {
            return ExecuteReader(dbCommand, CommandBehavior.Default);
        }

        protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            return cmd.ExecuteReader(behavior);
        }

        protected object ExecuteScalar(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }
    }
}