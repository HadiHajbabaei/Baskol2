using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MyDB.BusinessLayer.Cyber.Models.Mapping;
using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Data.SqlClient;
using MyDB.BusinessLayer.Cyber.Models;

namespace MyDB.BusinessLayer.Cyber
{

    public partial class DBEntity : DbContext
    {
        static DBEntity()
        {
            Database.SetInitializer<DBEntity>(null);
        }


        public virtual void Commit()
        {
            base.SaveChanges();
        }
        public DBEntity()
            : base(nameOrConnectionString: ConnectionString.myConnection)
        {
            Z.EntityFramework.Extensions.LicenseManager.AddLicense("207;100-IRDEVELOPERS.COM", "30C305C-9073CE5-207CB78-183207C-B11D");

        }
        public void InsertIntoDataBaseBulk(DataTable dataTable, string TableName)
        {


            using (var connection = new SqlConnection(ConnectionString.myConnection + ";MultipleActiveResultSets=True;App=EntityFramework"))
            {
                SqlTransaction transaction = null;
                connection.Open();
                try
                {
                    transaction = connection.BeginTransaction();
                    using (var sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, transaction))
                    {
                        sqlBulkCopy.DestinationTableName = TableName;
                        foreach (DataColumn dc in dataTable.Columns)
                            sqlBulkCopy.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                        sqlBulkCopy.WriteToServer(dataTable);
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }

            }
        }

        public void UpdateDataBaseBulk(DataTable dt, string TableName)
        {


        }

        public string GetTableName(Type entityType)
        {
            var metadata = ((IObjectContextAdapter)this).ObjectContext.MetadataWorkspace;

            // Get the mapping between CLR types and metadata OSpace
            var objectItemCollection = ((ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace));

            // Get metadata for given CLR type
            var entityMetadata = metadata
                    .GetItems<EntityType>(DataSpace.OSpace)
                    .Single(e => objectItemCollection.GetClrType(e) == entityType);

            return entityMetadata.Name;
        }
        public string[] GetKeyNames(Type entityType)
        {
            var metadata = ((IObjectContextAdapter)this).ObjectContext.MetadataWorkspace;

            // Get the mapping between CLR types and metadata OSpace
            var objectItemCollection = ((ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace));

            // Get metadata for given CLR type
            var entityMetadata = metadata
                    .GetItems<EntityType>(DataSpace.OSpace)
                    .Single(e => objectItemCollection.GetClrType(e) == entityType);

            return entityMetadata.KeyProperties.Select(p => p.Name).ToArray();
        }
        public void ExecuteSql(string sql)
        {
            DbConnection conn = base.Database.Connection;
            ConnectionState initialState = conn.State;
            try
            {
                if (initialState != ConnectionState.Open)
                    conn.Open();  // open connection if not already open
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {

            }
            finally
            {
                if (initialState != ConnectionState.Open)
                    conn.Close(); // only close connection if not initially open
            }
        }
        public string ExecuteSqlString(string sql)
        {
            DbConnection conn = base.Database.Connection;
            ConnectionState initialState = conn.State;
            object ob = "0";
            double rt = 0;
            try
            {
                if (initialState != ConnectionState.Open)
                    conn.Open();  // open connection if not already open
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    ob = cmd.ExecuteScalar();

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (initialState != ConnectionState.Open)
                    conn.Close(); // only close connection if not initially open
            }

            return ob != null ? ob.ToString() : "";
        }
        public string ExecuteSqlStringRtString(string sql)
        {
            DbConnection conn = base.Database.Connection;
            ConnectionState initialState = conn.State;
            object ob = "0";
            string rt = "";
            try
            {
                if (initialState != ConnectionState.Open)
                    conn.Open();  // open connection if not already open
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    ob = cmd.ExecuteScalar();

                }
            }
            finally
            {
                if (initialState != ConnectionState.Open)
                    conn.Close(); // only close connection if not initially open
            }
            rt = ob != null ? ob.ToString() : "0";
            return rt;
        }
        public DataSet ExecuteSqlDataSet(string sql)
        {
            DbConnection conn = base.Database.Connection;

            ConnectionState initialState = conn.State;
            DataSet Ds = new DataSet();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    DbDataReader z = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(z);
                    Ds.Tables.Add(dt);
                }
            }
            finally
            {
                if (initialState != ConnectionState.Open)
                    conn.Close(); // only close connection if not initially open

            }
            return Ds;
        }
        public DbSet<AC_0602_N> AC_0602_N { get; set; }
        public DbSet<AC_3001_N> AC_3001_N { get; set; }
        public DbSet<AC_3601_N> AC_3601_N { get; set; }
        public DbSet<AC_UnitM> AC_UnitM { get; set; }
        public DbSet<AC_0101_N> AC_0101_N { get; set; }
        public DbSet<AC_4101_N> AC_4101_N { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AC_0602_NMap());
            modelBuilder.Configurations.Add(new AC_3001_NMap());
            modelBuilder.Configurations.Add(new AC_0101_NMap());
            modelBuilder.Configurations.Add(new AC_3601_NMap());
            modelBuilder.Configurations.Add(new AC_UnitMMap());
            modelBuilder.Configurations.Add(new AC_4101_NMap());
        }
    }
}

