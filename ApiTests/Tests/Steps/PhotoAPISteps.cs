namespace ApiTests.Tests.Steps
{
    using System.Net;
    using ApiTests.Actions;
    using ApiTests.Models;
    using ApiTests.Models.Configs;
    using ApiTests.Utilities.Configurations;
    using ApiTests.Utilities.Enums;
    using ApiTests.Utilities.ScenarioSupport;
    using FluentAssertions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using RestSharp;
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

        [When(@"I request for user using id (.*)")]
        public void WhenIRequestForUserUsingId(string id)
        {
            var httpResponseCode = this.photoActions.GetCommentAction(id);
            Context<HttpStatusCode>.Add(ContextKeys.ResponsCode, httpResponseCode);
        }

        [When(@"I request for album using id (.*)")]
        public void WhenIRequestForAlbumUsingId(string id)
        {
            var httpResponseCode = this.photoActions.GetAlbumByIdAction(id);
            Context<HttpStatusCode>.Add(ContextKeys.ResponsCode, httpResponseCode);
        }

        [When(@"I request for todos using id (.*)")]
        public void WhenIRequestForTodosUsingId(string id)
        {
            var httpResponseCode = this.photoActions.GetAlbumByIdAction(id);
            Context<HttpStatusCode>.Add(ContextKeys.ResponsCode, httpResponseCode);
        }

        [Given(@"I request for album using id (.*)")]
        public void GivenIRequestForAlbumUsingId(string id)
        {   
            var httpResponseCode = this.photoActions.GetAlbumByIdAction(id);
            Context<HttpStatusCode>.Add(ContextKeys.ResponsCode, httpResponseCode);
        }

        [Then(@"Album should have a title ""(.*)""")]
        public void ThenAlbumShouldHaveATitle(string expectedTitle)
        {
            var photoModel = this.photoModel.BuildValidPostPhotoModel(this.placeholderService.ValidPostData);
            var actualTitle = JsonConvert.SerializeObject(photoModel.Title);
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [Then(@"Title is ""(.*)""")]
        public void ThenTitleIs(string expectedTitle)
        {
            var photoModel = this.photoModel.BuildValidPostPhotoModel(this.placeholderService.ValidPostData);
            var actualTitle = JsonConvert.SerializeObject(photoModel.Title);
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [Then(@"user id should be (.*)")]
        public void ThenUserIdShouldBe(string expectedUserId)
        {
            var photoModel = this.photoModel.BuildValidPostPhotoModel(this.placeholderService.ValidPostData);
            var actualUserId = JsonConvert.SerializeObject(photoModel.AlbumId);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [Then(@"url should be ""(.*)""")]
        public void ThenUrlShouldBe(string url)
        {
            var photoModel = this.photoModel.BuildValidPostPhotoModel(this.placeholderService.ValidPostData);
            var actualUrl = JsonConvert.SerializeObject(photoModel.Url);
            Assert.AreEqual(url, actualUrl);
        }

        [Then(@"thumbneil url should be ""(.*)""")]
        public void ThenThumbneilUrlShouldBe(string expectedThumbnailUrl)
        {
            var photoModel = this.photoModel.BuildValidPostPhotoModel(this.placeholderService.ValidPostData);
            var actualThambnailUrl = JsonConvert.SerializeObject(photoModel.Url);
            Assert.AreEqual(actualThambnailUrl, expectedThumbnailUrl);
        }

        [Given(@"Http response code is OK")]
        public void ThenServiceResponseCodeIsCorrect(HttpStatusCode httpsResponseCode)
            => Context<HttpStatusCode>.GetValue(ContextKeys.ResponsCode).Should().Be(httpsResponseCode);
    }
}
