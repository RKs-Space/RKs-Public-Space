using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace UserService.Models

{
    /*
     * Application speaks to MongoDb through this class for User registeration and login operations
     * The connection details should be read from Environment variables for connecting to cloud database
     * Local connection should be established by hard-coding connectionstring database name 
     */

    public class UserDbContext
    {


        MongoClient mongoclient;
        IMongoDatabase database;
        public UserDbContext()
        {
            string server = "mongodb://localhost:27017";
            string db = "gymuser_testdb";
            mongoclient = new MongoClient(server);
            database = mongoclient.GetDatabase(db);
        }

        public IMongoCollection<User> Users => database.GetCollection<User>("Users");

    }
}
