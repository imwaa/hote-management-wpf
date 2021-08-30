using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Hotel.Helpers
{
    class Mapping
    {
        public Mapping()
        {

        }
        public static TU Map<T, TU>(T source, TU destination)
        {
            // configure le mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T, TU>());

            var mapper = config.CreateMapper(); // crée le mapper
            return mapper.Map<TU>(source); // map et retourne le résultat
        }
    }
}
