namespace ApiTests.Tests.Steps
{
    using System.Net;
    using ApiTests.Utilities.Enums;
    using ApiTests.Utilities.ScenarioSupport;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class GenericSteps
    {
        [Then(@"Http response code is (.*)")]
        public void ThenServiceResponseCodeIsCorrect(HttpStatusCode httpsResponseCode)
            => Context<HttpStatusCode>.GetValue(ContextKeys.ResponsCode).Should().Be(httpsResponseCode);
    }
}
