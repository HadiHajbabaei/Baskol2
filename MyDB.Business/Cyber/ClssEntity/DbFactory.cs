using MyDB.BusinessLayer.Cyber;
using MyDB.BusinessLayer.Cyber.Infrastructure;
using MyDB.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDB.BusinessLayer.Cyber.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
       DBEntity dbContext;

        public DBEntity Init()
        {
            // return dbContext ?? (dbContext = new MYDBEntity( ));
             return dbContext ?? (dbContext = new DBEntity());

        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
