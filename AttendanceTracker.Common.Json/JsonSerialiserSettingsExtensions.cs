using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using NodaTime.Text;

namespace AttendanceTracker.Common.Json
{
    public static class JsonSerialiserSettingsExtensions
    {
        public static void AddCustomSerialisationSettings(this JsonSerializerSettings jsonSerializerSettings)
        {
            var nodaTimeLocalDatePatternConverter = LocalDatePattern.CreateWithInvariantCulture("dd-MM-yyyy");
            jsonSerializerSettings.Converters.Add(new NodaPatternConverter<LocalDate>(nodaTimeLocalDatePatternConverter));
            jsonSerializerSettings.DateParseHandling = DateParseHandling.None;
        }
    }
}