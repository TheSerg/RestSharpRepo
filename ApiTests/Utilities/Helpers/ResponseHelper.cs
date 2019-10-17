namespace ApiTests.Utilities.Helpers
{
    using Newtonsoft.Json;

    public class ResponseHelper
    {
        public static T GetObjectFromResponse<T>(string responseJson)
        {
            // Json deserialization to own model
            T responseObject = JsonConvert.DeserializeObject<T>(responseJson);
            return responseObject;
        }
    }
}
