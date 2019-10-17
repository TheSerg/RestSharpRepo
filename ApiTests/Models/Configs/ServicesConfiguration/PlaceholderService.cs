namespace ApiTests.Models.Configs
{
    using Newtonsoft.Json;

    public partial class PlaceholderService
    {
        [JsonProperty("validPostData")]
        public ValidPostData ValidPostData { get; set; }

        [JsonProperty("baseUri")]
        public string BaseUri { get; set; }
    }
}
