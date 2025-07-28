using AutoMapper;
using CompanyApp.DTOs;
using CompanyApp.Model;

namespace CompanyApp.Helpers
{
    
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Employee, EmployeeReadDTO>();
                CreateMap<EmployeeCreateDTO, Employee>();
                CreateMap<EmployeeUpdateDTO, Employee>();
            }
        }
}
