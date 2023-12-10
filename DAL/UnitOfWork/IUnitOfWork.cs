using DAL.Entity;
using DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IBusRepository busRepository { get; }
        ITripRepository tripRepository { get; }
        void CompleteAsync();
    }
}
