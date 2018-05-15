using AutoMapper;
using Employees.Models.DatabaseModels;
using Employees.Models.DTOs;

namespace Employees.App
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeShortDto>();
            CreateMap<EmployeeShortDto, Employee>();

            CreateMap<Employee, EmployeeFullDto>();
            CreateMap<EmployeeFullDto, Employee>();

            CreateMap<Employee, ManagerDto>()
            .ForMember(dest => dest.EmployeesManagedCount, opt => opt.MapFrom(src => src.EmployeesManaged.Count));
            CreateMap<ManagerDto, Employee>();

            CreateMap<Employee, EmployeeWithManagerDto>()
                .ForMember(dest => dest.ManagerLastName, opt => opt.MapFrom(src => src.Manager.LastName));
        }
    }
}
