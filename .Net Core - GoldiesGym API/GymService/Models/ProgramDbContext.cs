using MongoDB.Driver;

namespace GymService.Models
{
    /*
     * Application speaks to MongoDb through this class for gym Program operations
     * The connection details should be read from Environment variables for connecting to cloud database
     * Local connection should be established by hard-coding connectionstring database name 
     */

    public class ProgramDbContext
    {
        MongoClient mongoclient;
        IMongoDatabase database;
        public ProgramDbContext()
        {
            string server = "mongodb://localhost:27017";
            string db = "gymprogram_testdb";
            mongoclient = new MongoClient(server);
            database = mongoclient.GetDatabase(db);
        }

        public IMongoCollection<Program> Programs => database.GetCollection<Program>("Programs");
    }
}
