using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Timesheets.Models.Options;
using Timesheets.Models;
using Timesheets.Services;
using FluentValidation;
using Timesheets.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Timesheets.Models.Requels;
using Timesheets.Models.Validators;
using FluentValidation.Results;
using EmployeeService.Dats;

namespace Timesheets.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger _logger; 
        private readonly IEmployeeRepository _employeeRepository; 
        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IValidator<EmployeeRequest> _employeeRequestValidator;

        public EmployeeController(ILogger<EmployeeController> logger, IOptions<LoggerOptions> loggerOptions, 
            IEmployeeRepository employeeRepository, IValidator<EmployeeRequest> employeeRequestValidator)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _loggerOptions = loggerOptions;
            _employeeRequestValidator = employeeRequestValidator;
        }

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpDelete("employee/delete")]
        public ActionResult DeleteEmployee(int id)
        {
            //_logger.LogInformation("Employee delete");
            //var log = _loggerOptions.Value.Path;

            _employeeRepository.Delete(id);
            return Ok();
        }

        [HttpPost("employee/create")]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        public ActionResult<int> CreateEmployee(EmployeeRequest employeeRequest)
        {
            //ValidationResult validationResult = _employeeRequestValidator.Validate(employeeRequest);

            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.ToDictionary());

            //_logger.LogInformation("Employee add");
            //var log = _loggerOptions.Value.Path;


            return Ok(_employeeRepository.Create(new EmployeeService.Dats.Employee
            {
                DepartmentId = employeeRequest.DepartmentId,
                EmployeeTypeId = employeeRequest.EmployeeTypeId,
                FirstName = employeeRequest.FirstName,
                Surname = employeeRequest.Surname,
                Patronymic = employeeRequest.Patronymic,
                Salary = employeeRequest.Salary
            }));
        }

        [HttpPost("employee/update")]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        public ActionResult<int> UpdateEmployee(int _Id, EmployeeRequest employeeRequest)
        {

            ValidationResult validationResult = _employeeRequestValidator.Validate(employeeRequest);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToDictionary());

            //_logger.LogInformation("Employee update");
            //var log = _loggerOptions.Value.Path;

            var employee = _employeeRepository.GetById(_Id);

            _employeeRepository.Update(new EmployeeService.Dats.Employee
            {
                DepartmentId = employeeRequest.DepartmentId,
                EmployeeTypeId = employeeRequest.EmployeeTypeId,
                FirstName = employeeRequest.FirstName,
                Surname = employeeRequest.Surname,
                Patronymic = employeeRequest.Patronymic,
                Salary = employeeRequest.Salary,
            });
            return Ok();
        }

        [HttpGet("employee/get/all")]
        public ActionResult<IList<EmployeeDto>> GetAllEmployee()
        {
            //_logger.LogInformation("Employee getall");
            //var log = _loggerOptions.Value.Path;

            return Ok(_employeeRepository.GetAll().Select(employee => new EmployeeDto
            {
                Id = employee.Id,
                DepartmentId = employee.DepartmentId,
                EmployeeTypeId = employee.EmployeeTypeId,
                FirstName = employee.FirstName,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Salary = employee.Salary

            }).ToList());
        }

        [HttpGet("get/{id}")]
        public ActionResult<EmployeeDto> GetByIdEmployee([FromRoute] int id)
        {
            //_logger.LogInformation("Employee get");
            //var log = _loggerOptions.Value.Path;

            var employee = _employeeRepository.GetById(id);

            return Ok(new EmployeeDto
            {
                Id = employee.Id,
                DepartmentId = employee.DepartmentId,
                EmployeeTypeId = employee.EmployeeTypeId,
                FirstName = employee.FirstName,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Salary = employee.Salary
            });
        }
    }
}