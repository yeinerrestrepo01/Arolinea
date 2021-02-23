using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class Mappe<TSource, TDestination>
    {
        public Mappe()
        {
            this.ConfigurarMapper();
        }
        private MapperConfiguration ConfigurarMapper()
        {
            return new MapperConfiguration(cofg => cofg.CreateMap<TSource,TDestination>()); 
        }
        public TDestination MapperInformation(TSource ResourseObject)
        {
            var MapperInfo = new Mapper(this.ConfigurarMapper());
            var Destination = MapperInfo.Map<TSource, TDestination>(ResourseObject);
            return Destination;
        }
    }
}
