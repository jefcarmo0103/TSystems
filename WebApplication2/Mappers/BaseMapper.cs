using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Mappers
{
    public abstract class BaseMapper<T, U>
    {

        MapperConfiguration _mapperConfig;
        

        public U execER(T first, U second)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<T, U>();
            });

            _mapperConfig = config;

            IMapper mapper = _mapperConfig.CreateMapper();
            var result = mapper.Map<T, U>(first);

            return result;
        }

        public T execRE(T first, U second)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<U, T>();
            });

            _mapperConfig = config;

            IMapper mapper = _mapperConfig.CreateMapper();
            var result = mapper.Map<U, T>(second);

            return result;
        }

    }
}