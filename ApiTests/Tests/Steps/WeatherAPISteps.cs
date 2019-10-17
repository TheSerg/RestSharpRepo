namespace ApiTests.Tests.Steps
{
    using System.Net;
    using ApiTests.Actions;
    using ApiTests.Utilities.Enums;
    using ApiTests.Utilities.ScenarioSupport;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class WeatherAPISteps
    {
        private readonly WeatherActions weatherActions;

        public WeatherAPISteps(WeatherActions weatherActions)
        {
            this.weatherActions = weatherActions;
        }

        [When(@"Weather for city with id (.*) is requested")]
        public void GivenWeatherForCityWithIdIsRequested(string cityId)
        {
            var httpResponseCode = this.weatherActions.GetResponseStatusCodeId(cityId);
            Context<HttpStatusCode>.Add(ContextKeys.ResponsCode, httpResponseCode);
        }

        [When(@"Weather for city with name (.*) is requested")]
        public void GivenWeatherForCityWithNameIsRequested(string cityName)
        {
            var httpResponseCode = this.weatherActions.GetResponseStatusCodeName(cityName);
            Context<HttpStatusCode>.Add(ContextKeys.ResponsCode, httpResponseCode);
        }

        [When(@"Weather for city with wrong id (.*) is requested")]
        public void GivenWeatherForCityWithWrongIdIsRequested(string cityId)
        {
            var httpResponseCode = this.weatherActions.GetBadResponseStatusCodeName(cityId);
            Context<HttpStatusCode>.Add(ContextKeys.ResponsCode, httpResponseCode);
        }
    }
}
