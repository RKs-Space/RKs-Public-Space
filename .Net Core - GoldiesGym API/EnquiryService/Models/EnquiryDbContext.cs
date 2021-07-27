using MongoDB.Driver;

namespace EnquiryService.Models
{
    /*
     * Application speaks to MongoDb through this class for Enquiry operations
     * The connection details should be read from Environment variables for connecting to cloud database
     * Local connection should be established by hard-coding connectionstring and database name 
     */

    public class EnquiryDbContext
    {
        MongoClient mongoclient;
        IMongoDatabase database;
        public EnquiryDbContext()
        {
            string server = "mongodb://localhost:27017";
            string db = "gymenquiry_testdb";
            mongoclient = new MongoClient(server);
            database = mongoclient.GetDatabase(db);
        }

        public IMongoCollection<Enquiry> Enquiries => database.GetCollection<Enquiry>("Enquiries");
    }
}
