namespace ApiTests.Models.Configs.ServicesConfiguration
{
    using Newtonsoft.Json;

    public partial class ServiceConfiguration
    {
        [JsonProperty("placeholderService")]
        public PlaceholderService PlaceholderService { get; set; }

        [JsonProperty("weatherService")]
        public WeatherService WeatherService { get; set; }
    }
}
