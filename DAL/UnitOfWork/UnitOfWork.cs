using DAL.Entity;
using DAL.Repository;
using DAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _db;
        private IBusRepository _busRepository;
        private ITripRepository _tripRepository;
        private bool _disposed = false;

        public UnitOfWork(DbContext db, IBusRepository busRepository, ITripRepository tripRepository)
        {
            _db = db;
            _busRepository = busRepository;
            _tripRepository = tripRepository;
        }

        public IBusRepository busRepository => _busRepository;

        public ITripRepository tripRepository => _tripRepository;

        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    await _db.DisposeAsync();
                }
                _disposed = true;
            }
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        public async void CompleteAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}
