using EmployeeService.Dats;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Timesheets.Models.Options;
using Timesheets.Models;
using Timesheets.Services;
using FluentValidation;
using Timesheets.Models.Requels;
using Timesheets.Models.Request;
using EmployeeService.Models.Validators;
using Microsoft.AspNetCore.Authorization;
using Timesheets.Models.Validators;
using FluentValidation.Results;

namespace Timesheets.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger _logger; 
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IValidator<DepartmentRequest> _departmentRequestValidator;

        public DepartmentController(ILogger<DepartmentController> logger, 
            IOptions<LoggerOptions> loggerOptions, IDepartmentRepository departmentRepository, IValidator<DepartmentRequest> departmentRequestValidator)
        {
            _logger = logger;
            _departmentRepository = departmentRepository;
            _loggerOptions = loggerOptions;
            _departmentRequestValidator = departmentRequestValidator;
        }

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpDelete("department-types/delete")]
        public ActionResult DeleteDepartment(int id)
        {
            //_logger.LogInformation("Department delete");
            //var log = _loggerOptions.Value.Path;

            _departmentRepository.Delete(id);
            return Ok();
        }

        [HttpPost("department-types/create")]
        [ProducesResponseType(typeof(SessionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IDictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        public ActionResult<int> CreateDepartment([FromBody] DepartmentRequest departmentRequest)
        {
            //ValidationResult validationResult = _departmentRequestValidator.Validate(departmentRequest);

            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.ToDictionary());


            //_logger.LogInformation("Department add");
            //var log = _loggerOptions.Value.Path;

            return Ok(_departmentRepository.Create(new Department
            {
                Description = departmentRequest.Description,
            }));
        }

        [HttpGet("department-types/get/all")]
        public ActionResult<IList<DepartmentDto>> GetAllDepartment()
        {
           // _logger.LogInformation("department getall");
            //var log = _loggerOptions.Value.Path;

            return Ok(_departmentRepository.GetAll().Select(department => new DepartmentDto
            {
                Id = department.Id,
                Description = department.Description,

            }).ToList());
        }

        [HttpGet("get/{id}")]
        public ActionResult<DepartmentDto> GetByIdDepartment([FromRoute] int id)
        {
            //_logger.LogInformation("Department get");
           //var log = _loggerOptions.Value.Path;

            var department = _departmentRepository.GetById(id);

            return Ok(new DepartmentDto
            {
                Id = department.Id,
                Description = department.Description,
            });
        }
    }
}
