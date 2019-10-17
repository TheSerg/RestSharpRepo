namespace ApiTests.Utilities.Configurations
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using ApiTests.Models.Configs;
    using ApiTests.Models.Configs.ServicesConfiguration;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TestConfiguration
    {
        [JsonProperty("testDataCollection")]
        public TestDataCollection TestDataCollection { get; set; }

        [JsonProperty("serviceConfiguration")]
        public ServiceConfiguration ServiceConfiguration { get; set; }
    }

    public partial class TestConfiguration
    {
        private static string JsonConfigFile => File.ReadAllText("specflow.json");

        public static TestConfiguration GetConfiguration() => JsonConvert.DeserializeObject<TestConfiguration>(JsonConfigFile, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class PurpleParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(bool) || t == typeof(bool?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) { return null; }
            var value = serializer.Deserialize<string>(reader);
            bool b;
            if (bool.TryParse(value, out b))
            {
                return b;
            }

            throw new Exception("Cannot unmarshal type bool");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var value = (bool)untypedValue;
            var boolString = value ? "true" : "false";
            serializer.Serialize(writer, boolString);
            return;
        }

        public static readonly PurpleParseStringConverter Singleton = new PurpleParseStringConverter();
    }

    internal class FluffyParseStringConverter : JsonConverter
    {
        public static readonly FluffyParseStringConverter Singleton = new FluffyParseStringConverter();

        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) { return null; }
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }

            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }
    }
}
