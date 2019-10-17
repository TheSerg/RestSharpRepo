namespace ApiTests.Models
{
    public class Photo
    {
        public string AlbumId { get; set; }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }

        public Photo BuildValidPostPhotoModel(ValidPostData validPostData)
        {
            return new Photo()
            {
                AlbumId = validPostData.AlbumId,
                Id = validPostData.Id,
                Title = validPostData.Title,
                Url = validPostData.Url,
                ThumbnailUrl = validPostData.ThumbnailUrl
            };
        }
    }
}