﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Employee : User
    {
        public Employee(int id, string name) : base(id, name, nameof(Employee))
        {
        }
    }
}
