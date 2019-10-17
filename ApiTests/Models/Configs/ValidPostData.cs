using Newtonsoft.Json;

public partial class ValidPostData
{
    [JsonProperty("albumId", Required = Required.Always)]
    public string AlbumId { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("thumbnailUrl")]
    public string ThumbnailUrl { get; set; }
}