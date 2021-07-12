using System;
using Api.Infra.CrossCutting.Mappings;
using AutoMapper;

namespace Api.Service.Test
{
   public class AutoMaperFixture : IDisposable
   {
      public IMapper Mapper {get; set;}

      public IMapper GetMapper()
      {
         var config = new MapperConfiguration(cfg => {
            cfg.AddProfile(new DtoToModelProfile());
         });

         return config.CreateMapper();
      }

      public void Dispose()
      {
      }
   }
}
