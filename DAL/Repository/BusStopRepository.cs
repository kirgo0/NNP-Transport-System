using DAL.Entity;
using DAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BusStopRepository : Repository<BusStop>, IBusStopRepository
    {
        public BusStopRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
