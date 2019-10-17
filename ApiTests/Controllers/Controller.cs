namespace ApiTests.Controllers
{
    using ApiTests.Clients;
    using ApiTests.Models.Configs.ServicesConfiguration;
    using ApiTests.Utilities.Configurations;

    public class Controller : IController
    {
        public string FullRequestUrl { get; set; }

        public ServiceConfiguration ServiceConfiguration { get; set; }

        private readonly IClient client;

        public Controller(IClient client, ServiceConfiguration serviceConfiguration)
        {
            this.client = client;
            this.ServiceConfiguration = TestConfiguration.GetConfiguration().ServiceConfiguration;
        }
    }
}
