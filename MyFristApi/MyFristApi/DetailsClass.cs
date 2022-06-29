using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
namespace MyFristApi.Controllers
{
    public abstract class Details
    {
        public string Name;
        public DateTime DOB;
    }
    public class ReadDetails : Details
    {
        public string Name { get; }
        public DateTime DOB { get; }
        public ReadDetails(BsonDocument bsonDoc)
        {
            this.Name = bsonDoc.GetValue("Name").ToString();
            this.DOB = Convert.ToDateTime(bsonDoc.GetValue("DateOfBirth"));
        }
    }
    public class SubmitDetails : Details
    {
        public string Name { get; }
        public DateTime DOB { get; }
        public BsonDocument record { get; }
        public SubmitDetails(string Name, DateTime DOB)
        {
            this.Name = Name;
            this.DOB = DOB;
            this.record = new BsonDocument { { "Name", this.Name }, { "DateOfBirth", this.DOB } };
        }
        public void Submit()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://dbuser:dbuser@cluster0.sssd1.mongodb.net/?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("testdb");
            var collection = database.GetCollection<BsonDocument>("peopleReg");
            collection.InsertOne(record);
        }
    }
}
