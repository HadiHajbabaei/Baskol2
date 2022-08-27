
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MyDB.BusinessLayer;
using MyDB.BusinessLayer.Models;

namespace MyDB.BusinessLayer.Infrastructure
{
    public class RepositoryBase<T> where T : class
    {
        #region Properties
        private DBEntity dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {

            get;
            private set;

        }

        protected DBEntity DbContext;
        //{

        //    get
        //    {
        //        return dataContext ?? (dataContext = DbFactory.Init());
        //        //return new MYDBEntity();
        //    }

        //}
        #endregion

        public RepositoryBase()
        {
            DbContext = new DBEntity();
            DbFactory = ClsDBEntity.dbFactory;
            if (DbContext.Database.Connection.State == ConnectionState.Closed)
                DbContext.Database.Connection.Open();

            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual string ExecuteSqlString(string S)
        {
            return DbContext.ExecuteSqlString(S);
        }
        public virtual void ExecuteQuery(string S)
        {
            DbContext.ExecuteSql(S);
        }
        public virtual string RetTableName()
        {
            return DbContext.GetTableName(typeof(T));
        }
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public virtual void AddBulk(List<T> entity)
        {
            DbContext.BulkInsert<T>(entity);
        }
        public virtual void UpdateBulk(List<T> entity)
        {
            DbContext.BulkUpdate<T>(entity);
        }
        public virtual int SaveChanges()
        {
            
            var q = DbContext.ChangeTracker.Entries<T>()
        .Where(e => e.State == System.Data.Entity.EntityState.Added
        || e.State == System.Data.Entity.EntityState.Modified
        || e.State == System.Data.Entity.EntityState.Deleted).ToList();
            if (q.Count() != 0)
                DbContext.SaveChanges();
            return q.Count();
        }
        public virtual void Update(T entity)
        {
            var key = DbContext.GetKeyNames(typeof(T));
            List<T> q = dbSet.ToList();
            foreach (var i in key)
            {
                var x = entity.GetType().GetProperty(i).GetValue(entity);
                q = (from j in q
                     where j.GetType().GetProperty(i).GetValue(j).Equals(x)
                     select j).ToList();
            }
            if (q.Count() != 0)
            {
                T v = q.First();
                foreach (var i in entity.GetType().GetProperties())
                    if (!i.PropertyType.FullName.Contains("Entity")) if (!i.PropertyType.FullName.Contains("Entity")) v.GetType().GetProperty(i.Name).SetValue(v, i.GetValue(entity, null), null);
                DbContext.Entry(v).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                dbSet.Attach(entity);
                DbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public virtual void Delete(T entity)
        {

            dbSet.Remove(entity);
        }

        public virtual void Delete(List<T> where)
        {
            DbContext.BulkDelete(where);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            string x = DbContext.GetTableName(typeof(T));
            //return DbContext.Database.SqlQuery<T>($"select * from {x}");
            return dbSet.AsNoTracking<T>().ToList();

        }

        public virtual IEnumerable<T> GetAllQuery(string Query)
        {
            return DbContext.Database.SqlQuery<T>(Query).ToList();
        }

        public virtual DataTable GetAllDataTable(string Query)
        {
            return DbContext.ExecuteSqlDataSet(Query).Tables[0];
        }
        public virtual DateTime ServerDate(string Query)
        {
            return DateTime.Parse(Query);
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }


        #endregion

    }
}
