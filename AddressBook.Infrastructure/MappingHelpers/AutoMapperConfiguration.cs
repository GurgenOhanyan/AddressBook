using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AddressBook.Infrastructure.MappingHelpers
{
    public static partial class AutoMapperConfiguration
    {
        private static Mapper _mapper;
        public static Mapper CreateInstance()
        {
            if (_mapper == null)
            {
                Register();
            }
            return _mapper;
        }
        private static void Register()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Application.ApplicationModels.Contact, Domain.Entities.Contact>();
                config.CreateMap<Domain.Entities.Contact, Application.ApplicationModels.Contact>();
            });
            _mapper = new Mapper(config);
        }
    }
}
