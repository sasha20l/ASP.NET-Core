namespace Timesheets.Models
{ 
    public class EmployeeDto { 
        public int Id { get; set; } 
        public int DepartmentId { get; set; } 
        public int EmployeeTypeId { get; set; } 
        public string FirstName { get; set; } 
        public string Surname { get; set; } 
        public string Patronymic { get; set; } 
        public int Salary { get; set; } 
    } 
}
