namespace ApiTests.Models.Configs
{
    using Newtonsoft.Json;

    public partial class WeatherService
    {
        [JsonProperty("baseUri")]
        public string BaseUri { get; set; }

        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
    }
}
