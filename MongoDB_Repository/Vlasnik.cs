using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB_Repository
{
    public class Vlasnik
    {
        public ObjectId Id { get; set; }

        public String ime { get; set; }

        public String prezime { get; set; }

        public String kontakt { get; set; }

        public String username { get; set; }

        public String password { get; set; }

        public List<MongoDBRef> psi { get; set; }

        public Vlasnik()
        {
            psi = new List<MongoDBRef>();
        }
    }
}
