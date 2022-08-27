using MyDB.BusinessLayer.Cyber.Infrastructure;
using PRDataEntity.Cyber.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MyDB.BusinessLayer.Cyber
{
    public  static class ClsDBEntity
    {
        public readonly static DbFactory dbFactory = new DbFactory();
       // public readonly static MYDBEntity MyDB = new MYDBEntity();
    }
}
