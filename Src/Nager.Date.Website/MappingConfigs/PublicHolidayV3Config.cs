using Mapster;
using Nager.Date.Model;
using Nager.Date.Website.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.Website.MappingConfigs
{
    public class PublicHolidayV3Config : IRegister
    {
        private PublicHolidayType[] EnumFlagToArray(PublicHolidayType publicHolidayTypes)
        {
            var items = new List<PublicHolidayType>();
            foreach (PublicHolidayType publicHolidayType in Enum.GetValues(typeof(PublicHolidayType)))
            {
                if (publicHolidayTypes.HasFlag(publicHolidayType))
                {
                    items.Add(publicHolidayType);
                }
            }

            return items.ToArray();
        }

        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig<PublicHoliday, PublicHolidayV3Dto>.NewConfig()
                .Map(dest => dest.Types, src => this.EnumFlagToArray(src.Type));
        }
    }
}
