namespace ApiTests.ClientsConfigurations
{
    using System;
    using ApiTests.Clients;
    using ApiTests.Utilities;
    using log4net;
    using RestSharp;

    public class Client : IClient
    {
        public RestClient RestClient { get; set; }

        public Client()
        {
            this.RestClient = this.SetRestClient();
        }

        public virtual IRestResponse ExecuteRequest(Method method, string resource, string requestBody = null)
        {
            ILog logger = Logger.Initialize();
            logger.Info($"\nREQUEST DATETIME: {DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss")} \nREQUEST METHOD: {method} \nREQUEST RESOURCE: {resource}\n");

            IRestResponse response = null;
            IRestRequest request = string.IsNullOrEmpty(requestBody) ? new RestRequest(resource, method) : new RestRequest(resource, method).AddJsonBody(requestBody);

            try
            {
                response = this.RestClient.Execute(request);
            }
            catch (Exception e)
            {
                logger.Error("ERROR MESSAGE - " + e.Message);
            }

            return response;
        }

        private RestClient SetRestClient()
        {
            this.RestClient = this.RestClient is null ? new RestClient() : this.RestClient = null;
            return this.RestClient;
        }
    }
}
