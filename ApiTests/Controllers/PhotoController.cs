namespace ApiTests.Controllers
{
    using System;
    using System.Net;
    using ApiTests.Clients;
    using ApiTests.Models.Configs;
    using ApiTests.Models.Configs.ServicesConfiguration;
    using Newtonsoft.Json;
    using RestSharp;

    public class PhotoController : Controller
    {
        private readonly PlaceholderService placeholderService;

        public PhotoController(IClient client, ServiceConfiguration serviceConfiguration)
           : base(client, serviceConfiguration)
        {
            this.placeholderService = this.ServiceConfiguration.PlaceholderService;
        }

        //public IRestResponse<TModel> ExecutePostRequest<TModel, TSchema>(string path, TModel model, bool authenticated, HttpStatusCode statusCode = HttpStatusCode.Created) where TSchema : ISchema, new() where TModel : new()
        //{
        //    var request = new RestRequest(path, Method.GET);
        //    request.AddParameter("text/json", JsonConvert.SerializeObject(model), ParameterType.RequestBody);
        //    var response = GetDefaultClientConfiguration().Execute<TModel>(request);
        //    return response;
        //}

        public string PhotoResourceById(string id) => $"{this.placeholderService.BaseUri}photos/{id}";

        public string PostPhotoResource() => $"{this.placeholderService.BaseUri}photos/";

        public string DeletePhotoResource(string id) => $"{this.placeholderService.BaseUri}photos/{id}";

        public string GetPostResource(string id) => $"{this.placeholderService.BaseUri}posts/{id}";

        public string GetCommentByIDPath(string id) => $"{this.placeholderService.BaseUri}comments/{id}";

        public string GetUserByIDPath(string id) => $"{this.placeholderService.BaseUri}users/{id}";

        public string GetTodosByIDPath(string id) => $"{this.placeholderService.BaseUri}todos/{id}";

        public string GetAlbumByIDPath(string id) => $"{this.placeholderService.BaseUri}albums/{id}";
    }
}
