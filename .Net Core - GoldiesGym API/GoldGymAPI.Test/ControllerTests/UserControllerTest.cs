using GoldGymAPI.Test.InfraSetup;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserService.Models;

namespace GoldGymAPI.Test.ControllerTests
{
    public class UserControllerTest
    {
        private readonly HttpClient _client;

        private readonly UserWebApplicationFactory<UserService.Startup> factory;

        public UserControllerTest()
        {
            factory = new UserWebApplicationFactory<UserService.Startup>();

            _client = factory.CreateClient();

        }

        #region positive_test_cases

        [Test, Order(1)]
        public async Task TestRegisterSuccess()
        {
            //Arrange
            var user = new User
            {
                UserId = "sr-nandita",
                Password = "Password@123"
            };
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            //Act
            var httpResponse = await _client.PostAsync("/api/user/register", user, formatter);

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(stringResponse, Is.EqualTo(user.UserId));

        }

        [Test, Order(2)]
        public async Task TestLoginSuccess()
        {
            //Arrange
            var user = new User
            {
                UserId = "sr-nandita",
                Password = "Password@123"
            };
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            //Act
            var httpResponse = await _client.PostAsync("/api/user/login", user, formatter);

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(stringResponse, Does.Contain("token"));

        }

        #endregion


        #region negative_test_cases

        [Test, Order(3)]
        public async Task TestRegisterFailure()
        {
            //Arrange
            var user = new User
            {
                UserId = "sr-nandita",
                Password = "Password@123"
            };
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            //Act
            var httpResponse = await _client.PostAsync("/api/user/register", user, formatter);

            // Assert
            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
        }



        [Test, Order(4)]
        public async Task TestLoginFailure()
        {
            //Arrange
            var user = new User
            {
                UserId = "sr-nandita",
                Password = "Password@1234"
            };
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            //Act
            var httpResponse = await _client.PostAsync("/api/user/login", user, formatter);

            // Assert
            Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }


        #endregion


        #region logging_test_case

        [Test, Order(5)]
        public void TestLogging()
        {
            string folder = "GoldGymAPI.Test";
            var directory = Environment.CurrentDirectory;
            int position = directory.IndexOf(@"bin");
            string rootpath = directory.Substring(0, position - (folder.Length + 1));
            string filepath = Path.Combine(rootpath, @"UserService/UserLogFile.txt");
            Assert.That(File.Exists(filepath), Is.True);

            string contents = File.ReadAllText(filepath);
            Assert.That(contents.Length > 0, Is.True);

            Assert.That(Regex.IsMatch(contents, "Request Incoming Time"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Processing Time"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Host: localhost"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Port"), Is.True);
            Assert.That(Regex.IsMatch(contents, "URI: /api/user/register"), Is.True);
            Assert.That(Regex.IsMatch(contents, "URI: /api/user/login"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Method: POST"), Is.True);
            Assert.That(Regex.IsMatch(contents, "Status: 201"), Is.True);
        }
        #endregion

    }
}
