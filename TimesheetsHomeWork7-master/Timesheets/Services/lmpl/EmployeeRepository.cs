using EmployeeService.Dats;

namespace Timesheets.Services.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeServiceDbContext _context;

        public EmployeeRepository(EmployeeServiceDbContext context)
        {
            _context = _context;
        }

        public int Create(Employee data)
        {
            _context.Employees.Add(data);
            _context.SaveChanges();
            return data.Id;
        }

        public void Delete(int id)
        {
            Employee employee = GetById(id);
            if (employee == null)
                throw new Exception("Employee not found");

            _context.Employees.Remove(GetById(id));
            _context.SaveChanges(true);
        }

        public IList<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(et => et.Id == id);
        }

        public void Update(Employee data)
        {
            if (data == null)
                throw new Exception("Employee is null.");
            Employee employee = GetById(data.Id);
            employee.DepartmentId = data.DepartmentId;
            employee.EmployeeTypeId = data.EmployeeTypeId;
            employee.FirstName = data.FirstName;
            employee.Surname = data.Surname;
            employee.Patronymic = data.Patronymic;
            employee.Salary = data.Salary;
            _context.SaveChanges(true);
        }
    }
}
