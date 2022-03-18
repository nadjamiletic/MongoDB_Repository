using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MongoDB_Repository
{
    public class Pas
    {
        public ObjectId Id { get; set; }

        public String ime { get; set; }

        public String pol { get; set; }

        public String rasa { get; set; }

        public String slika { get; set; }
        
        public List<String> kategorije { get; set; }

        public float tezina { get; set; }

        public int starost { get; set; }

        public MongoDBRef vlasnik { get; set; }

        public List<MongoDBRef> dostignuca { get; set; }

        public List<MongoDBRef> izlozbe { get; set; }

        public Pas()
        {
            kategorije = new List<string>();
            dostignuca = new List<MongoDBRef>();
            izlozbe = new List<MongoDBRef>();
        }
    }

   
}
