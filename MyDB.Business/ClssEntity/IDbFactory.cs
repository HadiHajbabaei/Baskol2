
using MyDB.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDB.BusinessLayer.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DBEntity Init();

    }
}
