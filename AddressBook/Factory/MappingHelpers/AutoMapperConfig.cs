using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Factory.MappingHelpers
{
    public class AutoMapperConfig
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
                config.CreateMap<Models.Contact,Application.ApplicationModels.Contact>();
                config.CreateMap<Application.ApplicationModels.Contact,Models.Contact>();
            });
            _mapper = new Mapper(config);
        }

    }
}
