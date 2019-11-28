namespace ApiTests.Actions
{
    using System.Net;
    using ApiTests.Clients;
    using ApiTests.Controllers;
    using RestSharp;

    public class WeatherActions
    {
        private readonly WeatherController controller;
        private readonly IClient client;

        public WeatherActions(WeatherController controller, IClient client)
        {
            this.controller = controller;
            this.client = client;
        }

        public HttpStatusCode GetResponseStatusCodeId(string id)
        {
            var resource = this.controller.WeatherResourceByCityId(id);
            var rowResponse = this.client.ExecuteRequest(Method.GET, resource);
            var result = rowResponse.StatusCode;

            return result;
        }

        public HttpStatusCode GetResponseStatusCodeName(string name)
        {
            var resource = this.controller.WeatherResourceByCityName(name);
            var rowResponse = this.client.ExecuteRequest(Method.GET, resource);
            var result = rowResponse.StatusCode;

            return result;
        }

        public HttpStatusCode GetResponseExperimentName(string name)
        {
            var resource = this.controller.WeatherResourceByCityName(name);
            var rowResponse = this.client.ExecuteRequest(Method.GET, resource);
            var result = rowResponse.StatusCode;

            return result;
        }

        public HttpStatusCode GetBadResponseStatusCodeName(string name)
        {
            var resource = this.controller.WeatherResourceByCityId(name);
            var rowResponse = this.client.ExecuteRequest(Method.GET, resource);
            var result = rowResponse.StatusCode;

            return result;
        }
}
}
