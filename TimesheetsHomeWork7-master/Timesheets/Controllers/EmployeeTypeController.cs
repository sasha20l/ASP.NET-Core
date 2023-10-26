using EmployeeService.Dats;
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

namespace Timesheets.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly ILogger _logger; 
        private readonly IEmployeeTypeRepository _employeeTypeRepository; 
        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IValidator<EmployeeTypeRequest> _employeeTypeRequestValidator;

        public EmployeeTypeController(ILogger<EmployeeTypeController> logger, IOptions<LoggerOptions> loggerOptions, 
            IEmployeeTypeRepository employeeTypeRepository, IValidator<EmployeeTypeRequest> employeeTypeRequestValidator)
        {
            _logger = logger;
            _employeeTypeRepository = employeeTypeRepository;
            _loggerOptions = loggerOptions;
            _employeeTypeRequestValidator = employeeTypeRequestValidator;
        }

        public EmployeeTypeController(IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
        }

        [HttpDelete("employee-types/delete")]
        public ActionResult DeleteEmployeeType(int id)
        {
            //_logger.LogInformation("EmployeeType delete");
            //var log = _loggerOptions.Value.Path;

            _employeeTypeRepository.Delete(id);
            return Ok();
        }

        [HttpPost("employee-types/create")]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        public ActionResult<int> CreateEmployeeType(EmployeeTypeRequest employeeTypeRequest)
        {
            //ValidationResult validationResult = _employeeTypeRequestValidator.Validate(employeeTypeRequest);

            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.ToDictionary());

            //_logger.LogInformation("EmployeeType add");
            //var log = _loggerOptions.Value.Path;

            return Ok(_employeeTypeRepository.Create(new EmployeeType
            {
                Description = employeeTypeRequest.Description,
            }));
        }

        [HttpGet("employee-types/get/all")]
        public ActionResult<IList<EmployeeTypeDto>> GetAllEmployeeType()
        {
            //_logger.LogInformation("EmployeeType getall");
            //var log = _loggerOptions.Value.Path;

            return Ok(_employeeTypeRepository.GetAll().Select(employeeType => new EmployeeTypeDto
            {
                Id = employeeType.Id,
                Description = employeeType.Description,

            }).ToList());
        }

        [HttpGet("get/{id}")]
        public ActionResult<EmployeeTypeDto> GetByIdEmployeeType([FromRoute] int id)
        {
            //_logger.LogInformation("EmployeeType get");
            //var log = _loggerOptions.Value.Path;

            var employee = _employeeTypeRepository.GetById(id);

            return Ok(new EmployeeTypeDto
            {
                Id = employee.Id,
                Description = employee.Description,
            });
        }
    }
}
