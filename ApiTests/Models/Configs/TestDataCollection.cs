namespace ApiTests.Models.Configs
{
    using Newtonsoft.Json;

    public partial class TestDataCollection
    {
        [JsonProperty("placeholderService")]
        public PlaceholderService PlaceholderService { get; set; }
    }
}
