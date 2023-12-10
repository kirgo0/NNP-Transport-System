using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests
{
    public class TestBusRepository : Repository<Bus>
    {
        public TestBusRepository(DbContext db) : base(db)
        {
        }
    }
}
