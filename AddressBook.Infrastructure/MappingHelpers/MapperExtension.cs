using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.MappingHelpers
{
    public static class MapperExtension
    {
        public static TDestination MapTo<TDestination>(object mappable)
        {
            TDestination value = AutoMapperConfiguration.CreateInstance().Map<TDestination>(mappable);
            return value;
        }
    }
}
