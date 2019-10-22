namespace ApiTests.Controllers
{
    using ApiTests.Clients;
    using ApiTests.Models.Configs;
    using ApiTests.Models.Configs.ServicesConfiguration;

    public class PhotoController : Controller
    {
        private readonly PlaceholderService placeholderService;

        public PhotoController(IClient client, ServiceConfiguration serviceConfiguration)
           : base(client, serviceConfiguration)
        {
            this.placeholderService = this.ServiceConfiguration.PlaceholderService;
        }

        public string PhotoResourceById(string id) => $"{this.placeholderService.BaseUri}photos/{id}";

        public string PostPhotoResource() => $"{this.placeholderService.BaseUri}photos/";

        public string DeletePhotoResource(string id) => $"{this.placeholderService.BaseUri}photos/{id}";

        public string GetPostResource(string id) => $"{this.placeholderService.BaseUri}posts/{id}";

        public string GetCommentByIDPath(string id) => $"{this.placeholderService.BaseUri}comments/{id}";

        public string GetUserByIDPath(string id) => $"{this.placeholderService.BaseUri}users/{id}";

        public string GetAlbumByIDPath(string id) => $"{this.placeholderService.BaseUri}albums/{id}";

        public string GetTodosByIDPath(string id) => $"{this.placeholderService.BaseUri}todos/{id}";
    }
}
