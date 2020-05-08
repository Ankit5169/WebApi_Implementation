using AutoMapper;
using DBRepository.Model;
using Employees.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Common
{

    public static class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeModel>().ReverseMap();
                cfg.CreateMap<EmployeeModel, EmployeeViewModel>().ReverseMap();

            });

            return config.CreateMapper();
        }

    }
}

