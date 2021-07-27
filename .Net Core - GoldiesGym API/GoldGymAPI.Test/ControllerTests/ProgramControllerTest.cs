using GoldGymAPI.Test.InfraSetup;
using GymService.Models;
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
    public class ProgramControllerTest
    {
        private readonly HttpClient _client, _userClient, _anonymousClient;

        private readonly UserWebApplicationFactory<UserService.Startup> userFactory;
        private readonly GymWebApplicationFactory<GymService.Startup> factory;

        public ProgramControllerTest()
        {

            userFactory = new UserWebApplicationFactory<UserService.Startup>();
            factory = new GymWebApplicationFactory<GymService.Startup>();

            //calling Auth API to get JWT
            User user = new User { UserId = "sr-anthony", Password = "Anthony@123" };
            _userClient = userFactory.CreateClient();
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            // The endpoint or route of the authentication controller action.
            var httpResponse = _userClient.PostAsync<User>("/api/user/login", user, formatter);
            httpResponse.Wait();
            // Deserialize and examine results.
            var stringResponse = httpResponse.Result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TokenModel>(stringResponse.Result);

            _client = factory.CreateClient();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {response.Token}");

            _anonymousClient = new GymWebApplicationFactory<GymService.Startup>().CreateClient();

        }

        #region positive_test_cases

        [Test, Order(1)]
        public async Task TestPostSuccess()
        {
            //Arrange
            var program = new Program
            {
                ProgramId = 102,
                ProgramName = "Zoomba",
                DurationInMonths = 8,
                Price = 6600,
                DiscountRate = 0,
                CurrentPrice = 6600,
                Description = "For fitness"
            };
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            //Act
            var httpResponse = await _client.PostAsync("/api/program", program, formatter);

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(Convert.ToInt32(stringResponse), Is.EqualTo(102));

        }

        [Test, Order(2)]
        public async Task TestGetProgramsSuccess()
        {
            //Action
            var httpResponse = await _client.GetAsync("/api/program");

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var response = await httpResponse.Content.ReadAsStringAsync();

            var programs = JsonConvert.DeserializeObject<List<Program>>(response);

            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(programs.Count(), Is.EqualTo(2));

        }

        [TestCase(102), Order(3)]
        public async Task TestGetProgramByIdSuccess(int id)
        {
            //Act
            var httpResponse = await _client.GetAsync($"/api/program/{id}");

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var response = await httpResponse.Content.ReadAsStringAsync();

            var program = JsonConvert.DeserializeObject<Program>(response);

            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(program.ProgramName, Is.EqualTo("Zoomba"));

        }

        [TestCase(102), Order(4)]
        public async Task TestPutSuccess(int id)
        {
            //Act
            var program = new Program
            {
                ProgramId = 102,
                ProgramName = "Zoomba",
                DurationInMonths = 7,
                Price = 7600,
                DiscountRate = 10,
                CurrentPrice = 6840,
                Description = "For fitness"
            };
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();


            var httpResponse = await _client.PutAsync($"/api/program/{id}", program, formatter);

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
            var program = new Program
            {
                ProgramId = 102,
                ProgramName = "Zoomba",
                DurationInMonths = 8,
                Price = 6600,
                DiscountRate = 0,
                CurrentPrice = 6600,
                Description = "For fitness"
            };
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            //Act
            var httpResponse = await _client.PostAsync("/api/program", program, formatter);

            // Assert
            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
        }

        [TestCase(103), Order(6)]
        public async Task TestGetProgramByIdFailure(int id)
        {
            //Act
            var httpResponse = await _client.GetAsync($"/api/program/{id}");

            // Assert
            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        }

        [TestCase(103), Order(7)]
        public async Task TestPutFailure(int id)
        {
            //Act
            var program = new Program();
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            var httpResponse = await _client.PutAsync($"/api/program/{id}", program, formatter);

            // Assert
            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test, Order(11)]
        public async Task TestPostReturnsUnauthorized()
        {
            //Arrange
            var program = new Program
            {
                ProgramId = 102,
                ProgramName = "Zoomba",
                DurationInMonths = 8,
                Price = 6600,
                DiscountRate = 0,
                CurrentPrice = 6600,
                Description = "For fitness"
            };
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            //Act
            var httpResponse = await _anonymousClient.PostAsync("/api/program", program, formatter);

            // Assert
            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [TestCase(103), Order(12)]
        public async Task TestPutReturnsUnauthorized(int id)
        {
            //Act
            var program = new Program();
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            var httpResponse = await _anonymousClient.PutAsync($"/api/program/{id}", program, formatter);

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
            string filepath = Path.Combine(rootpath, @"GymService/GymLogFile.txt");
            Assert.That(File.Exists(filepath), Is.True);

            string contents = File.ReadAllText(filepath);
            Assert.That(contents.Length > 0, Is.True);

            Assert.That(Regex.IsMatch(contents, "Request Incoming Time"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Processing Time"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Host: localhost"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Port"), Is.True);
            Assert.That(Regex.IsMatch(contents, "URI: /api/program"), Is.True);
            Assert.That(Regex.IsMatch(contents, "URI: /api/program/102"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Method: POST"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Method: PUT"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Method: GET"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Status: 201"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Status: 200"), Is.True);
        }
        #endregion
    }
}
