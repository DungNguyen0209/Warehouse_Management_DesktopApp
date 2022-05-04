using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SqliteDB.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangeAsync();
        void DetachChange();
        //void Dispose();
    }
}
