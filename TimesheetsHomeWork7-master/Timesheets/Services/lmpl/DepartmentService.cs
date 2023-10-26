

using DepartmentServiceProto;
using Grpc.Core;
using static DepartmentServiceProto.DepartmentService;

namespace Timesheets.Services.Impl
{
    public class DepartmentService : DepartmentServiceBase
   {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public override Task<CreateDepartmentResponse> CreateDepartment(CreateDepartmentRequest request, ServerCallContext context)
        {
            var id = _departmentRepository.Create(new EmployeeService.Dats.Department
            {
                Description = request.Description
            });
            CreateDepartmentResponse response = new CreateDepartmentResponse();
            response.Id = id;
            return Task.FromResult(response);
        }

        public override Task<DeleteDepartmentResponse> DeleteDepartment(DeleteDepartmentRequest request, ServerCallContext context)
        {
            _departmentRepository.Delete(request.Id);
            return Task.FromResult(new DeleteDepartmentResponse());
        }

        public override Task<GetAllDepartmentsResponse> GetAllDepartments(GetAllDepartmentsRequest request, ServerCallContext context)
        {
            GetAllDepartmentsResponse response = new GetAllDepartmentsResponse();
            response.DepartmentTypes.AddRange(_departmentRepository.GetAll().Select(et =>
                new DepartmentServiceProto.Department
                {
                    Id = et.Id,
                    Description = et.Description,
                }).ToList());
            return Task.FromResult(response);
        }

    }
}
