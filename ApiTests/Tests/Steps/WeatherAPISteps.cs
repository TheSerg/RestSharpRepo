namespace ApiTests.Tests.Steps
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;
    using ApiTests.Actions;
    using ApiTests.Utilities.Enums;
    using ApiTests.Utilities.ScenarioSupport;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using RestSharp;
    using RestSharp.Authenticators;
    using RestSharp.Authenticators.OAuth;
    using RestSharp.Deserializers;
    using TechTalk.SpecFlow;

    [Binding]
    public class WeatherAPISteps
    {
        private readonly WeatherActions weatherActions;
        private object authenticator;

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

        [Then(@"I see city name ""(.*)""")]
        public void ThenISeeCityName(string cityName)
        {
            var client = new RestClient("https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "samples.openweathermap.org");
            request.AddHeader("Postman-Token", "9b192411-86c7-47ba-a3eb-f7da60c4e309,24a68d7e-47ef-4f3a-9735-ae5f7a83b995");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.19.0");
            request.AddHeader("Authorization", "Basic eHY2Nm84NWNqcDV3MHR3Yms2YzZlZzZraDhteHZ6eXRpMWgxNzUxeW5vODdjbmR5Omt5ZFVXNFtwdlY6MzZWdU87cmF0K2JfXURhOlo/MlFEU35MUztHOTxFPTArS0Q9Rg==");
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine(content);

            var jObject = JObject.Parse(response.Content);

            string actualCity = jObject.GetValue("name").ToString();

            Assert.AreEqual(actualCity, cityName, "Correct city name received in the response");
        }

        [Then(@"I see code response ""(.*)""")]
        public void ThenISeeCodeResponse(string code)
        {
            var client = new RestClient("https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "samples.openweathermap.org");
            request.AddHeader("Postman-Token", "9b192411-86c7-47ba-a3eb-f7da60c4e309,24a68d7e-47ef-4f3a-9735-ae5f7a83b995");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.19.0");
            request.AddHeader("Authorization", "Basic eHY2Nm84NWNqcDV3MHR3Yms2YzZlZzZraDhteHZ6eXRpMWgxNzUxeW5vODdjbmR5Omt5ZFVXNFtwdlY6MzZWdU87cmF0K2JfXURhOlo/MlFEU35MUztHOTxFPTArS0Q9Rg==");
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine(content);

            var jObject = JObject.Parse(response.Content);

            string actualCode = jObject.GetValue("cod").ToString();

            Assert.AreEqual(actualCode, code, "Correct city name received in the response");
        }

        [When(@"I register new user")]
        public void WhenIRegisterNewUser()
        {
            RestClient restClient = new RestClient("http://restapi.demoqa.com/customer");

            //Creating Json object
            JObject jObjectbody = new JObject();
            jObjectbody.Add("FirstName", "Narayn");
            jObjectbody.Add("LastName", "Kaluri");
            jObjectbody.Add("UserName", "NaraynKasdfsdfluri");
            jObjectbody.Add("Password", "Passwovasdfsdaf23");
            jObjectbody.Add("Email", "abcdafsad@hotmail.com");

            RestRequest restRequest = new RestRequest("/register", Method.POST);

            //Adding Json body as parameter to the post request
            restRequest.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            IRestResponse restResponse = restClient.Execute(restRequest);
            var content = restResponse.Content.ToString();

           // Assert.Contains("OPERATION_SUCCESS ", restRequest.Content, " Post failed ");
        }

        [When(@"Login user with username ""(.*)"" and password ""(.*)""")]
        public void WhenLoginUserWithUsernameAndPassword(string login, string password)
        {
            RestClient restClient = new RestClient();

            restClient.BaseUrl = new Uri("http://restapi.demoqa.com/authentication/CheckForAuthentication");

            RestRequest restRequest = new RestRequest(Method.GET);

            restClient.Authenticator = new HttpBasicAuthenticator(login, password);

            IRestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine("Status code: " + (int)restResponse.StatusCode);
            Console.WriteLine("Status message " + restResponse.Content);
        }

        [When(@"send empty request")]
        public void WhenSendEmptyRequest()
        {
            var request = new RestRequest("/resource");

            request.AddParameter("foo", "bar");

            var client = new RestClient(new Uri("http://example.com"));
            var expected = new Uri("http://example.com/resource?foo=bar");
            var output = client.BuildUri(request);

            Assert.AreEqual(expected, output);
        }

        [When(@"Get with multiple instance of some key")]
        public void WhenGetWithMultipleInstanceOfSomeKey()
        {
            var request = new RestRequest("v1/people/~/network/updates", Method.GET);

            request.AddParameter("type", "STAT");
            request.AddParameter("type", "PICT");
            request.AddParameter("count", "50");
            request.AddParameter("start", "50");

            var client = new RestClient("http://api.linkedin.com");
            var expected =
                new Uri("http://api.linkedin.com/v1/people/~/network/updates?type=STAT&type=PICT&count=50&start=50");
            var output = client.BuildUri(request);

            Assert.AreEqual(expected, output);
        }

        [When(@"Get with resource containing null token")]
        public void WhenGetWithResourceContainingNullToken()
        {
            var request = new RestRequest("/resource/{foo}", Method.GET);

            request.AddUrlSegment("foo", null);

            var client = new RestClient("http://example.com/api/1.0");
            var exception = Assert.Throws<ArgumentException>(() => client.BuildUri(request));

            Assert.IsNotNull(exception);
            Assert.False(string.IsNullOrEmpty(exception.Message));
            Assert.IsTrue(exception.Message.Contains("foo"));
        }

        [When(@"Get with resource contaning tokens")]
        public void WhenGetWithResourceContaningTokens()
        {
            var request = new RestRequest("resource/{foo}");

            request.AddUrlSegment("foo", "bar");

            var client = new RestClient(new Uri("http://example.com"));
            var expected = new Uri("http://example.com/resource/bar");
            var output = client.BuildUri(request);

            Assert.AreEqual(expected, output);
        }

        [When(@"I send POST with token")]
        public void WhenISendPOSTWithToken()
        {
            var request = new RestRequest("resource/{foo}", Method.POST);

            request.AddUrlSegment("foo", "bar");

            var client = new RestClient(new Uri("http://example.com"));
            var expected = new Uri("http://example.com/resource/bar");
            var output = client.BuildUri(request);

            Assert.AreEqual(expected, output);
        }

        [When(@"Build end encoding URI using ISO(.*)")]
        public void WhenBuildEndEncodingURIUsingISO(string p0)
        {
            var request = new RestRequest();
            // adding parameter with o-slash character which is encoded differently between
            // utf-8 and iso-8859-1
            request.AddOrUpdateParameter("town", "Hillerød");

            var client = new RestClient("http://example.com/resource");

            var expectedDefaultEncoding = new Uri("http://example.com/resource?town=Hiller%C3%B8d");
            var expectedIso89591Encoding = new Uri("http://example.com/resource?town=Hiller%F8d");
            Assert.AreEqual(expectedDefaultEncoding, client.BuildUri(request));
            // now changing encoding
            client.Encoding = Encoding.GetEncoding("ISO-8859-1");
            Assert.AreEqual(expectedIso89591Encoding, client.BuildUri(request));
        }

        [When(@"Get with resource containing slashes")]
        public void WhenGetWithResourceContainingSlashes()
        {
            var request = new RestRequest("resource/foo");
            var client = new RestClient(new Uri("http://example.com"));
            var expected = new Uri("http://example.com/resource/foo");
            var output = client.BuildUri(request);

            Assert.AreEqual(expected, output);
        }

        [When(@"get invalid url string throws exception")]
        public void WhenGetInvalidUrlStringThrowsException()
        {
            Assert.Throws<UriFormatException>(delegate { new RestClient("invalid url"); });
        }

        [When(@"User deserialize elements with namespace")]
        public void WhenUserDeserializeElementsWithNamespace()
        {
            const string @namespace = "http://restsharp.org";
            XNamespace ns = XNamespace.Get(@namespace);
            XDocument doc = new XDocument(
                new XElement(ns + "response",
                    new XAttribute(ns + "attribute-value", "711"),
                        "random value"));

            var expected = new NodeWithAttributeAndValue
            {
                AttributeValue = null
            };

            XmlDeserializer xml = new XmlDeserializer() { Namespace = @namespace };
            NodeWithAttributeAndValue output = xml.Deserialize<NodeWithAttributeAndValue>(new RestResponse { Content = doc.ToString() });

            Assert.AreEqual(expected.AttributeValue, output.AttributeValue);
        }

        [When(@"autenticate - HTTP autorization header")]
        public void WhenAutenticate_HTTPAutorizationHeader()
        {
            var client = new RestClient("http://example.com");
            client.Authenticator = new SimpleAuthenticator("username", "foo", "password", "bar");

            var request = new RestRequest("resource", Method.GET);
            client.Execute(request);
        }
    }
}
