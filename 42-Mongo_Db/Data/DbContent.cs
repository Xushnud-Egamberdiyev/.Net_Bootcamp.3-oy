using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _42_Mongo_Db.Data
{
    public class DbContent
    {
        private readonly MongoClient mongoclient;
        public DbContent()
        {
            this.mongoclient = new MongoClient(
                connectionString: "mongodb://localhost:27017");

            //foreach (var item in _client.ListDatabases().ToList())
            //{
            //    Console.WriteLine(item);
            //}

            var a = mongoclient.GetDatabase("CountyDB");
        }

        public IMongoDatabase GetDatabase(string name)
        {
            return mongoclient.GetDatabase(name);
        }

    }
}
