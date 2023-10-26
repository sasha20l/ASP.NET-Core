using EmployeeService.Dats;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Controllers;
using Timesheets.Models.Options;
using Timesheets.Models.Request;
using Timesheets.Models.Validators;
using Timesheets.Services;
using Timesheets.Services.lmpl;
using Xunit;
using TheoryAttribute = Xunit.TheoryAttribute;

namespace TimesheetsServiceTests
{
    public class DepartmentControllerTests
    {
        private readonly DepartmentController _departmentController;
        private readonly Mock<IDepartmentRepository> _mockDepartmentRepository;

        private DepartmentRequest department;

        public DepartmentControllerTests()
        {
            _mockDepartmentRepository = new Mock<IDepartmentRepository>();
            _departmentController = new DepartmentController(_mockDepartmentRepository.Object);
        }

        [Fact]
        public void GetAllDepartmentTest()
        {
            // [1] Подготовка данных
            _mockDepartmentRepository.Setup(repository =>
                repository.GetAll()).Returns(new List<Department>());
            


            // [2] Исполнение тестируемого метода
            var result = _departmentController.GetAllDepartment();

            _mockDepartmentRepository.Verify(repository =>
            repository.GetAll(), Times.Once());

           // [3] Подготовка эталонного результата и проверка на валидность
           //Assert.IsAssignableFrom<ActionResult<IList<EmployeeTypeDto>>> (result);
        }

        [Theory]
        [InlineData("test1")]
        [InlineData("test2")]
        [InlineData("test3")]
        public void CreateDepartmentTest(string description)
        {
            department = new DepartmentRequest
            {
                Description = description,
            };

            _mockDepartmentRepository.Setup(repository =>
            repository.Create(It.IsAny<Department>())).Verifiable();

            var result = _departmentController.CreateDepartment(department);

            _mockDepartmentRepository.Verify(repository =>
            repository.Create(It.IsAny<Department>()), Times.Once);

            //Assert.IsAssignableFrom<ActionResult<int>> (result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void DeleteDepartmentTest(int id)
        {
            _mockDepartmentRepository.Setup(repository =>
                repository.Delete(It.IsAny<int>())).Verifiable();

            var result = _departmentController.DeleteDepartment(id);


            _mockDepartmentRepository.Verify(repository =>
                repository.Delete(It.IsAny<int>()), Times.Once);

            //Assert.IsAssignableFrom<IActionResult>(result);
        }



    }
}
