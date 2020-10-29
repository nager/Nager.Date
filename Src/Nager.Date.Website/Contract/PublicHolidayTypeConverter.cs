using Nager.Date.Model;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nager.Date.WebsiteCore.Contract
{
    public class PublicHolidayTypeConverter : JsonConverter<PublicHolidayType>
    {
        public override PublicHolidayType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return PublicHolidayType.Authorities;
        }

        public override void Write(Utf8JsonWriter writer, PublicHolidayType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
