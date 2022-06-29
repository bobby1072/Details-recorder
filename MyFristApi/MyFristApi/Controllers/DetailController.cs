using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MyFristApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetailController : Controller
    {
        private readonly ILogger<DetailController> _logger;

        public DetailController(ILogger<DetailController> logger)
        {
            _logger = logger;
        }
        [HttpGet("ShowDetails")]
        
        public List<ReadDetails> ShowDetails()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://dbuser:dbuser@cluster0.sssd1.mongodb.net/?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("testdb");
            var collection = database.GetCollection<BsonDocument>("peopleReg");
            var documents = collection.Find(new BsonDocument()).ToList();
            List<ReadDetails> jsonStringList = new List<ReadDetails>(); 
            foreach (BsonDocument doc in documents)
            {
                ReadDetails recordObject = new ReadDetails(doc);
                jsonStringList.Add(recordObject);
            }
            return jsonStringList;
        }
        [HttpPost("SubmitDetails")]
        public string Post(string name, string dOB)
        {
            string result;
            try
            {
                var DOB = DateTime.Parse(dOB);
                var record = new SubmitDetails(name, DOB);
                record.Submit();
                result = "Submitted Correctly";
            }
            catch
            {
                result = "Error";
            }
            return result;
        }
    }
}
