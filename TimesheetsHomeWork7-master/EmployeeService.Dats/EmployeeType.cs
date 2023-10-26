using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeService.Dats
{
    [Table("EmployeeTypes")]
    public class EmployeeType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Column]
        [StringLength(128)]
        public string Description { get; set; }

        [InverseProperty(nameof(Employee.EmployeeType))]
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

    }
}
