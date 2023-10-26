using EmployeeService.Dats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Services 
{ 
    public interface IEmployeeRepository : IRepository<Employee, int> 
    { 
    } 
}
