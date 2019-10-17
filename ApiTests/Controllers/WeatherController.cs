namespace ApiTests.Controllers
{
    using ApiTests.Clients;
    using ApiTests.Models.Configs;
    using ApiTests.Models.Configs.ServicesConfiguration;

    public class WeatherController : Controller
    {
        private readonly WeatherService weatherService;

        public WeatherController(IClient client, ServiceConfiguration serviceConfiguration)
            : base(client, serviceConfiguration)
        {
            this.weatherService = this.ServiceConfiguration.WeatherService;
        }

        public string WeatherResourceByCityId(string id) => $"{this.weatherService.BaseUri}?id={id}&appid={this.weatherService.ApiKey}";

        public string WeatherResourceByCityName(string name) => $"{this.weatherService.BaseUri}?q={name}&appid={this.weatherService.ApiKey}";
    }
}