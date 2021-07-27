using EnquiryService.Models;
using GoldGymAPI.Test.InfraSetup;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserService.Models;

namespace GoldGymAPI.Test.ControllerTests
{
    public class EnquiryControllerTest
    {
        private readonly HttpClient _client, _managerClient, _anonymousClient;

        public EnquiryControllerTest()
        {
            User user = new User { UserId = "sr-sagar", Password = "Sagar@123" };
            _client = SetClient(user);

            User manager = new User { UserId = "sr-bharathi", Password = "Bharathi@123" };
            _managerClient = SetClient(manager);

            _anonymousClient = new EnquiryWebApplicationFactory<EnquiryService.Startup>().CreateClient();

        }
        HttpClient SetClient(User login)
        {
            UserWebApplicationFactory<UserService.Startup> userFactory = new UserWebApplicationFactory<UserService.Startup>();
            HttpClient userClient = userFactory.CreateClient();
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            // The endpoint or route of the authentication controller action.
            var httpResponse = userClient.PostAsync<User>("/api/user/login", login, formatter);
            httpResponse.Wait();
            // Deserialize and examine results.
            var stringResponse = httpResponse.Result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TokenModel>(stringResponse.Result);

            EnquiryWebApplicationFactory<EnquiryService.Startup> factory = new EnquiryWebApplicationFactory<EnquiryService.Startup>();

            HttpClient client = factory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {response.Token}");
            return client;
        }

        #region positive_test_cases

        [Test, Order(1)]
        public async Task TestPostSuccess()
        {
            //Arrange
            var enquiry = new Enquiry
            {
                EnquiryId = 1002,
                Name = "nandita",
                Query = "Next Yoga Batch with date and timings ??",
                Email = "nandita@sro.in",
                Mobile = "9988778899",
                Status = "Open"
            };
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            //Act
            var httpResponse = await _client.PostAsync("/api/enquiry", enquiry, formatter);

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(Convert.ToInt32(stringResponse), Is.EqualTo(1002));

        }

        [Test, Order(2)]
        public async Task TestGetEnquiriesSuccess()
        {
            //Action
            var httpResponse = await _managerClient.GetAsync("/api/enquiry");

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var response = await httpResponse.Content.ReadAsStringAsync();

            var enquiries = JsonConvert.DeserializeObject<List<Enquiry>>(response);

            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(enquiries.Count(), Is.EqualTo(2));

        }

        [TestCase(1002), Order(3)]
        public async Task TestGetEnquiryByIdSuccess(int id)
        {
            //Act
            var httpResponse = await _managerClient.GetAsync($"/api/enquiry/{id}");

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var response = await httpResponse.Content.ReadAsStringAsync();

            var enquiry = JsonConvert.DeserializeObject<Enquiry>(response);

            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(enquiry.EnquiryId, Is.EqualTo(1002));
            Assert.That(enquiry.Name, Is.EqualTo("nandita"));
            Assert.That(enquiry.Query, Is.EqualTo("Next Yoga Batch with date and timings ??"));

        }

        [TestCase(1002), Order(4)]
        public async Task TestPutSuccess(int id)
        {
            //Act
            var enquiry = new Enquiry
            {
                EnquiryId = 1002,
                Name = "nandita",
                Query = "Next Yoga Batch with date and timings ??",
                Email = "nandita@sro.in",
                Mobile = "9988778899",
                CseRemarks = "Last week of June 2020 ",
                Status = "Closed"
            };
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();


            var httpResponse = await _managerClient.PutAsync($"/api/enquiry/{id}", enquiry, formatter);

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var response = await httpResponse.Content.ReadAsStringAsync();

            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(Convert.ToBoolean(response), Is.True);
        }

        #endregion


        #region negative_test_cases

        [Test, Order(5)]
        public async Task TestPostFailure()
        {
            //Arrange
            var enquiry = new Enquiry
            {
                EnquiryId = 1002,
                Name = "nandita",
                Query = "Next Yoga Batch with date and timings ??",
                Email = "nandita@sro.in",
                Mobile = "9988778899",
                Status = "Open"
            };
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            //Act
            var httpResponse = await _managerClient.PostAsync("/api/enquiry", enquiry, formatter);

            // Assert
            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));
        }

        [Test, Order(6)]
        public async Task TestGetEnquiriesFailure()
        {
            //Action
            var httpResponse = await _client.GetAsync("/api/enquiri");

            // Assert
            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        }

        [TestCase(1003), Order(7)]//varuna
        public async Task TestGetEnquiryByIdFailure(int id)
        {
            //Act
            var httpResponse = await _client.GetAsync($"/api/enquiry/{id}");

            // Assert
            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));
        }

        [TestCase(1003), Order(8)]
        public async Task TestPutFailure(int id)
        {
            //Act
            var enquiry = new Enquiry
            {
                EnquiryId = 1002,
                Name = "nandita",
                Query = "Next Yoga Batch with date and timings ??",
                Email = "nandita@sro.in",
                Mobile = "9988778899",
                CseRemarks = "Last week of June 2020 ",
                Status = "Closed"
            };
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            var httpResponse = await _client.PutAsync($"/api/enquiry/{id}", enquiry, formatter);

            // Assert
            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }


        [TestCase(1003), Order(9)]
        public async Task TestGetEnquiryByIdFailureReturnsNotFound(int id)
        {
            //Act
            var httpResponse = await _managerClient.GetAsync($"/api/enquiry/{id}");

            // Assert
            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));

        }

        [TestCase(1004), Order(10)]
        public async Task TestPutFailureReturnsNotFound(int id)
        {
            //Act
            var enquiry = new Enquiry();
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            var httpResponse = await _managerClient.PutAsync($"/api/enquiry/{id}", enquiry, formatter);

            // Assert

            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test, Order(11)]
        public async Task TestPostReturnsUnauthorized()
        {
            //Arrange
            var enquiry = new Enquiry
            {
                Name = "nandita",
                Query = "Next Yoga Batch with date and timings ??",
                Email = "nandita@sro.in",
                Mobile = "9988778899",
                Status = "Open"
            };
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            //Act
            var httpResponse = await _anonymousClient.PostAsync("/api/enquiry", enquiry, formatter);

            // Assert
            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [TestCase(1002), Order(12)]
        public async Task TestGetEnquiryByIdReturnsUnauthorized(int id)
        {
            //Act
            var httpResponse = await _anonymousClient.GetAsync($"/api/enquiry/{id}");

            // Assert
            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [TestCase(1004), Order(13)]
        public async Task TestPutReturnsUnauthorized(int id)
        {
            //Act
            var enquiry = new Enquiry();
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            var httpResponse = await _anonymousClient.PutAsync($"/api/enquiry/{id}", enquiry, formatter);

            // Assert

            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }


        #endregion

        #region logging_test_case

        [Test, Order(8)]
        public void TestLogging()
        {
            string folder = "GoldGymAPI.Test";
            var directory = Environment.CurrentDirectory;
            int position = directory.IndexOf(@"bin");
            string rootpath = directory.Substring(0, position - (folder.Length + 1));
            string filepath = Path.Combine(rootpath, @"EnquiryService/EnquiryLogFile.txt");
            Assert.That(File.Exists(filepath), Is.True);

            string contents = File.ReadAllText(filepath);
            Assert.That(contents.Length > 0, Is.True);

            Assert.That(Regex.IsMatch(contents, "Request Incoming Time"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Processing Time"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Host: localhost"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Port"), Is.True);
            Assert.That(Regex.IsMatch(contents, "URI: /api/enquiry"), Is.True);
            Assert.That(Regex.IsMatch(contents, "URI: /api/enquiry/1002"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Method: POST"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Method: PUT"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Method: GET"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Status: 201"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Status: 200"), Is.True);
        }
        #endregion
    }
}
