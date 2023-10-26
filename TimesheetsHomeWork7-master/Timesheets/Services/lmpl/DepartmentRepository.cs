using EmployeeService.Dats;
using Timesheets.Services.Impl;

namespace Timesheets.Services.lmpl
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeServiceDbContext _context;

        public DepartmentRepository(EmployeeServiceDbContext context)
        {
            _context = _context;
        }

        public int Create(Department data)
        {
            _context.Departments.Add(data);
            _context.SaveChanges();
            return data.Id;
        }

        public void Delete(int id)
        {
            Department department = GetById(id);
            if (department == null)
                throw new Exception("Department not found");

            _context.Departments.Remove(GetById(id));
            _context.SaveChanges(true);
        }

        public IList<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.FirstOrDefault(et => et.Id == id);
        }

        public void Update(Department data)
        {
            if (data == null)
                throw new Exception("Department is null.");
            Department department = GetById(data.Id);
            department.Description = data.Description;
            _context.SaveChanges(true);
        }
    }
}
