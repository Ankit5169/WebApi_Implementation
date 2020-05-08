using AutoMapper;
using DBRepository.Model;
using Employees.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1057180_WebAPI201.Tests
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeViewModel, EmployeeModel>().ReverseMap();

            });

            return config.CreateMapper();
        }

    }
}
