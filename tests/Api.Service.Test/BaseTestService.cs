using AutoMapper;

namespace Api.Service.Test
{
    public abstract class BaseTestService
    {
        public IMapper mapper {get; set;}

        public BaseTestService()
        {
            mapper = new AutoMaperFixture().GetMapper();
        }
    }
}