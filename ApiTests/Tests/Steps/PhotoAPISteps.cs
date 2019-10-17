namespace ApiTests.Tests.Steps
{
    using System.Net;
    using ApiTests.Actions;
    using ApiTests.Models;
    using ApiTests.Models.Configs;
    using ApiTests.Utilities.Configurations;
    using ApiTests.Utilities.Enums;
    using ApiTests.Utilities.ScenarioSupport;
    using Newtonsoft.Json;
    using TechTalk.SpecFlow;

    [Binding]
    public class PhotoAPISteps
    {
        private readonly PhotoActions photoActions;
        private readonly Photo photoModel;
        private readonly PlaceholderService placeholderService;

        public PhotoAPISteps(PhotoActions photoActions, Photo photoModel, PlaceholderService placeholderService)
        {
            this.photoActions = photoActions;
            this.photoModel = photoModel;
            this.placeholderService = TestConfiguration.GetConfiguration().TestDataCollection.PlaceholderService;
        }

        [When(@"I request for photo data using valid photo id (.*)")]
        [When(@"I request for photo data using unexisting photo id (.*)")]
        public void WhenIRequestForPhotoUsingValidPhotoId(string id)
        {
            var httpResponseCode = this.photoActions.GetResponseStatusCode(id);
            Context<HttpStatusCode>.Add(ContextKeys.ResponsCode, httpResponseCode);
        }

        [When(@"I post valid data to the photo service")]
        public void WhenIPostValidDataToThePhotoService()
        {
            var photoModel = this.photoModel.BuildValidPostPhotoModel(this.placeholderService.ValidPostData);
            var requestBody = JsonConvert.SerializeObject(photoModel);
            var httpResponseCode = this.photoActions.GetPostedStatusCode(requestBody);
            Context<HttpStatusCode>.Add(ContextKeys.ResponsCode, httpResponseCode);
        }

        [When(@"I delete photo data using Id (.*) from the photo service")]
        public void WhenIDeletePhotoDataUsingIdFromThePhotoService(string id)
        {
            var httpResponseCode = this.photoActions.GetDeletedStatusCode(id);
            Context<HttpStatusCode>.Add(ContextKeys.ResponsCode, httpResponseCode);
        }

        [When(@"I request for post data using id (.*)")]
        public void WhenIRequestForPostDataUsingId(string id)
        {
            var httpResponseCode = this.photoActions.GetPostsStatusCode(id);
            Context<HttpStatusCode>.Add(ContextKeys.ResponsCode, httpResponseCode);
        }

        [When(@"I request for comment using id (.*)")]
        public void WhenIRequestForCommentUsingId(string id)
        {
            var httpResponseCode = this.photoActions.GetCommentAction(id);
            Context<HttpStatusCode>.Add(ContextKeys.ResponsCode, httpResponseCode);
        }
    }
}
