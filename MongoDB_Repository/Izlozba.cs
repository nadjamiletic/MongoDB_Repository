using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB_Repository
{
    public class Izlozba
    {
        public ObjectId Id { get; set; }

        public String naziv { get; set; }

        public String grad { get; set; }

        public DateTime datum { get; set; }

        public List<MongoDBRef> psi { get; set; }

       

        public Izlozba()
        {
            psi = new List<MongoDBRef>();
        }

        
    }
}
