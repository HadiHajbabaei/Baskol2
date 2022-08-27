
using MyDB.BusinessLayer.Cyber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDB.BusinessLayer.Cyber.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DBEntity Init();

    }
}
