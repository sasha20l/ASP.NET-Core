using EmployeeService.Dats;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Controllers;
using Timesheets.Models.Request;
using Timesheets.Services;
using Xunit;
using TheoryAttribute = Xunit.TheoryAttribute;

namespace TimesheetsServiceTests
{
    public class EmployeeControllerTests
    {
        private readonly EmployeeController _employeeController;
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;

        private EmployeeRequest employee;

        public EmployeeControllerTests()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();

            _employeeController = new EmployeeController(_mockEmployeeRepository.Object);

        }

        [Fact]
        public void GetAllEmployeeTest()
        {
            // [1] Подготовка данных
            _mockEmployeeRepository.Setup(repository =>
                repository.GetAll()).Returns(new List<Employee>());
            


            // [2] Исполнение тестируемого метода
            var result = _employeeController.GetAllEmployee();

            _mockEmployeeRepository.Verify(repository =>
            repository.GetAll(), Times.Once());

           // [3] Подготовка эталонного результата и проверка на валидность
           //Assert.IsAssignableFrom<ActionResult<IList<EmployeeTypeDto>>> (result);
        }

        [Theory]
        [InlineData(1, 1, "1", "2", "3", "4", 1000)]
        [InlineData(2, 2, "5", "6", "7", "8", 2000)]
        [InlineData(3, 3, "9", "10", "11", "12", 3000)]
        public void CreateEmployeeTest(int departmentId, int employeeTypeId, string firstNamestring,
            string firstName, string surname, string patronymic, int salary)
        {
            employee = new EmployeeRequest
            {
                DepartmentId = departmentId,
                EmployeeTypeId = employeeTypeId,
                FirstName = firstName,
                Surname = surname,
                Patronymic = patronymic,
                Salary = salary
            };

            _mockEmployeeRepository.Setup(repository =>
            repository.Create(It.IsAny<Employee>())).Verifiable();

            var result = _employeeController.CreateEmployee(employee);

            _mockEmployeeRepository.Verify(repository =>
            repository.Create(It.IsAny<Employee>()), Times.Once);

            //Assert.IsAssignableFrom<ActionResult<int>> (result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void DeleteEmployeeTest(int id)
        {
            _mockEmployeeRepository.Setup(repository =>
                repository.Delete(It.IsAny<int>())).Verifiable();

            var result = _employeeController.DeleteEmployee(id);


            _mockEmployeeRepository.Verify(repository =>
                repository.Delete(It.IsAny<int>()), Times.Once);

            //Assert.IsAssignableFrom<IActionResult>(result);
        }



    }
}
