namespace ApiTests.Actions
{
    using System.Net;
    using ApiTests.Clients;
    using ApiTests.Controllers;
    using RestSharp;

    public class PhotoActions
    {
        private readonly PhotoController controller;
        private readonly IClient client;

        public PhotoActions(PhotoController controller, IClient client)
        {
            this.controller = controller;
            this.client = client;
        }

        public HttpStatusCode GetResponseStatusCode(string id)
        {
            var resource = this.controller.PhotoResourceById(id);
            var rowResponse = this.client.ExecuteRequest(Method.GET, resource);
            var result = rowResponse.StatusCode;

            return result;
        }

        public HttpStatusCode GetPostsStatusCode(string id)
        {
            var resource = this.controller.GetPostResource(id);
            var rowResponse = this.client.ExecuteRequest(Method.GET, resource);
            var result = rowResponse.StatusCode;

            return result;
        }

        public HttpStatusCode GetCommentAction(string id)
        {
            var resource = this.controller.GetCommentByIDPath(id);
            var rowResponse = this.client.ExecuteRequest(Method.GET, resource);
            var result = rowResponse.StatusCode;

            return result;
        }

        public HttpStatusCode GetUserByIdAction(string id)
        {
            var resource = this.controller.GetUserByIDPath(id);
            var rowResponse = this.client.ExecuteRequest(Method.GET, resource);
            var result = rowResponse.StatusCode;

            return result;
        }

        public HttpStatusCode GetAlbumByIdAction(string id)
        {
            var resource = this.controller.GetAlbumByIDPath(id);
            var rowResponse = this.client.ExecuteRequest(Method.GET, resource);
            var result = rowResponse.StatusCode;

            return result;
        }

        public HttpStatusCode GetTodosByIdAction(string id)
        {
            var resource = this.controller.GetTodosByIDPath(id);
            var rowResponse = this.client.ExecuteRequest(Method.GET, resource);
            var result = rowResponse.StatusCode;

            return result;
        }

        public HttpStatusCode GetPostedStatusCode(string requestBody)
        {
            var resource = this.controller.PostPhotoResource();
            var rowResponse = this.client.ExecuteRequest(Method.POST, resource, requestBody);
            var result = rowResponse.StatusCode;

            return result;
        }

        public HttpStatusCode GetDeletedStatusCode(string id)
        {
            var resource = this.controller.DeletePhotoResource(id);
            var rowResponse = this.client.ExecuteRequest(Method.DELETE, resource);
            var result = rowResponse.StatusCode;

            return result;
        }
    }
}
