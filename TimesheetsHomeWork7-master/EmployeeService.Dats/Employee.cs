using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeService.Dats
{
    [Table("Employees")]
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(EmployeeType))]
        public int EmployeeTypeId { get; set; }

        [Column]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Column]
        [StringLength(255)]
        public string Surname { get; set; }

        [Column]
        [StringLength(255)]
        public string Patronymic { get; set; }

        [Column(TypeName = "money")]
        public int Salary { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }

        public virtual Department Department { get; set; }
    }
}
