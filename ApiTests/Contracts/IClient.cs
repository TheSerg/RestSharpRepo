namespace ApiTests.Clients
{
    using RestSharp;

    public interface IClient
    {
        RestClient RestClient { get; set; }

        IRestResponse ExecuteRequest(Method method, string resource, string requestBody = null);
    }
}
