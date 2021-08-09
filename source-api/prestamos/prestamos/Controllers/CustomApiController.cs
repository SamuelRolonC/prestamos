using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace prestamos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomApiController : ControllerBase
    {
        public IMapper Mapper { get; set; }


        public CustomApiController()
        {

        }

        public IActionResult Json(object value)
        {
            JsonResult jsonResult = new JsonResult(value);
            return jsonResult;
        }

        public TDestination MapTo<TSource, TDestination>(TSource source)
        {
            Mapper = GetMapperConfiguration<TSource, TDestination>();
            return Mapper.Map<TSource, TDestination>(source);
        }

        public List<TDestination> MapListTo<TSource, TDestination>(List<TSource> source)
        {
            Mapper = GetMapperConfiguration<TSource, TDestination>();
            return Mapper.Map<List<TSource>, List<TDestination>>(source);
        }

        /// <summary>
        /// Get the Mapper was injected if we have one and it's has the mapping. If 
        /// don't have a Mapper or don't have the mapping, we create a new one with this 
        /// mapping and return it.
        /// </summary>
        private IMapper GetMapperConfiguration<TSource, TDestination>()
        {
            if (Mapper == null || Mapper.ConfigurationProvider.FindTypeMapFor<TSource, TDestination>() == null)
            {
                var configurationExpression = new MapperConfigurationExpression();

                configurationExpression.CreateMap<TSource, TDestination>();
                configurationExpression.AddMaps(GetType().Assembly);

                var config = new MapperConfiguration(configurationExpression);
                return config.CreateMapper();
            }

            return Mapper;
        }
    }
}
