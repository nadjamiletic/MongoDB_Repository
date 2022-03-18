using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB_Repository
{
    public class Dostignuce
    {
        public ObjectId Id { get; set; }

        public MongoDBRef pas { get; set; }

        public MongoDBRef izlozba { get; set; }

        public String kategorija { get; set; }

        public String titula { get; set; }

        public List<int> ocene { get; set; }

        public float prosecnaOcena()
        {
            float prosecna = 0;
            int suma = 0;
            for(int i=0;i<ocene.Count(); i++)
            {
                suma += ocene[i];
                prosecna = suma / ocene.Count();
            }
            return prosecna;
        }

        public Dostignuce()
        {
            ocene = new List<int>();
        }
    }
}
