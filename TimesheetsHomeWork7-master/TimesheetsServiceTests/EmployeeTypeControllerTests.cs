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
    public class EmployeeTypeControllerTests
    {
        private readonly EmployeeTypeController _employeeTypeController;
        private readonly Mock<IEmployeeTypeRepository> _mockEmployeeTypeRepository;

        private EmployeeTypeRequest employeeType;

        public EmployeeTypeControllerTests()
        {
            _mockEmployeeTypeRepository = new Mock<IEmployeeTypeRepository>();

            _employeeTypeController = new EmployeeTypeController(_mockEmployeeTypeRepository.Object);

        }

        [Fact]
        public void GetAllEmployeeTypesTest()
        {
            // [1] Подготовка данных
            _mockEmployeeTypeRepository.Setup(repository =>
                repository.GetAll()).Returns(new List<EmployeeType>());
            


            // [2] Исполнение тестируемого метода
            var result = _employeeTypeController.GetAllEmployeeType();

            _mockEmployeeTypeRepository.Verify(repository =>
            repository.GetAll(), Times.Once());

           // [3] Подготовка эталонного результата и проверка на валидность
           //Assert.IsAssignableFrom<ActionResult<IList<EmployeeTypeDto>>> (result);
        }

        [Theory]
        [InlineData("test1")]
        [InlineData("test2")]
        [InlineData("test3")]
        public void CreateEmployeeTypeTest(string description)
        {
            employeeType = new EmployeeTypeRequest
            {
                Description = description,
            };

            _mockEmployeeTypeRepository.Setup(repository =>
            repository.Create(It.IsAny<EmployeeType>())).Verifiable();

            var result = _employeeTypeController.CreateEmployeeType(employeeType);

            _mockEmployeeTypeRepository.Verify(repository =>
            repository.Create(It.IsAny<EmployeeType>()), Times.Once);

            //Assert.IsAssignableFrom<ActionResult<int>> (result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void DeleteEmployeeTypeTest(int id)
        {
            _mockEmployeeTypeRepository.Setup(repository =>
                repository.Delete(It.IsAny<int>())).Verifiable();

            var result = _employeeTypeController.DeleteEmployeeType(id);


            _mockEmployeeTypeRepository.Verify(repository =>
                repository.Delete(It.IsAny<int>()), Times.Once);

            //Assert.IsAssignableFrom<IActionResult>(result);
        }



    }
}
