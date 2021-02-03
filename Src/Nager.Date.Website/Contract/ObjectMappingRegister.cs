using Mapster;
using Nager.Date.Model;
using Nager.Date.Website.Models;

namespace Nager.Date.Website.Contract
{
    public class ObjectMappingRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LongWeekend, LongWeekendDto>()
                .Map(dest => dest.NeedBridgeDay, src => src.Bridge);

            //config.NewConfig<PublicHoliday, PublicHolidayDto>()
            //    .Map(dest => dest.Date.ToString("yyyy-MM-dd"), src => src.Date);
        }
    }
}
