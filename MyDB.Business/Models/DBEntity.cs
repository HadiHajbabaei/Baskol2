using MyDB.BusinessLayer.Models.Mapping;
using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace MyDB.BusinessLayer.Models
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
                    cmd.CommandTimeout = 9999999;
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
                    cmd.CommandTimeout = 9999999;
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
                    cmd.CommandTimeout = 9999999;
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
                    cmd.CommandTimeout = 99999999;
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

        public DbSet<Account> Account { get; set; }
        public DbSet<Activate> Activates { get; set; }
        public DbSet<App> Apps { get; set; }
        public DbSet<Crack> Cracks { get; set; } 
        public DbSet<View_AppCrack> View_AppCracks { get; set; }
        public DbSet<Car> SabtCar { get; set; }
        public DbSet<SabtDriver> SabtDriver { get; set; }
        public DbSet<SabtMahsol> SabtMahsol { get; set; }
        public DbSet<Port> ComPort { get; set; }
        public DbSet<Tozin1> Tozin1 { get; set; }
        public DbSet<Tozin2> Tozin2 { get; set; }
        public DbSet<Vahed> Vahed { get; set; }
        public DbSet<View_Tozin1> View_Tozin1 { get; set; }
        public DbSet<TakTozin> TakTozin { get; set; }
        public DbSet<View_SabtMahsol> View_SabtMahsol { get; set; }
        public DbSet<View_TakTozin> View_TakTozin { get; set; }
        public DbSet<SabtCustomer> SabtCustomer { get; set; }
        public DbSet<Camera> Camera { get; set; }

        public DbSet<Factor> Factor { get; set; }
        public DbSet<Cyber> Cyber { get; set; }
        public DbSet<View_Factor> View_Factor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new VahedMap());
            modelBuilder.Configurations.Add(new FactorMap());
            modelBuilder.Configurations.Add(new View_FactorMap());
            modelBuilder.Configurations.Add(new CyberMap());
            modelBuilder.Configurations.Add(new CameraMap());
            modelBuilder.Configurations.Add(new TakTozinMap());
            modelBuilder.Configurations.Add(new SabtCustomerMap());
            modelBuilder.Configurations.Add(new View_TakTozinMap());
            modelBuilder.Configurations.Add(new View_SabtMahsolMap());
            modelBuilder.Configurations.Add(new ActivateMap());
            modelBuilder.Configurations.Add(new View_Tozin1Map());
            modelBuilder.Configurations.Add(new Tozin1Map());
            modelBuilder.Configurations.Add(new Tozin2Map());
            modelBuilder.Configurations.Add(new AppMap());
            modelBuilder.Configurations.Add(new CrackMap()); 
            modelBuilder.Configurations.Add(new CarMap());
            modelBuilder.Configurations.Add(new View_AppCrackMap());
            modelBuilder.Configurations.Add(new SabtDriverMap());
            modelBuilder.Configurations.Add(new SabtMahsolMap());
            modelBuilder.Configurations.Add(new PortMap());


        }
    }
}