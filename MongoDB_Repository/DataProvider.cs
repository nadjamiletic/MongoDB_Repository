using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MongoDB_Repository
{
    public class DataProvider
    {
        public string path="";

        public string getPath()
        {
            return path;
        }

        public void setPath(string p)
        {
            path = p;
        }

        #region Izlozba
        public List<Izlozba> vratiIzlozbe()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var collection = db.GetCollection<Izlozba>("izlozbe");

            List<Izlozba> lista = new List<Izlozba>();

            foreach (Izlozba r in collection.FindAll())
            {
                lista.Add(r);
            }
            return lista;
        }
        //novo
        public Izlozba VratiIzlozbu(string ime)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var izlozbaCollection = db.GetCollection("izlozbe");

            var query1 = (from izlozba in izlozbaCollection.AsQueryable<Izlozba>()
                          where izlozba.naziv == ime
                          select izlozba).FirstOrDefault();

            return query1;
        }
        #endregion

        #region Pas
        public List<Pas> vratiPse()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var collection = db.GetCollection<Pas>("psi");

            List<Pas> lista=new List<Pas>();
 
            foreach (Pas r in collection.FindAll())
            {
                lista.Add(r);
            }
            return lista;
        }

        public Pas vratiPsa(string kategorija,string izlozba,string ime)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var pasCollection = db.GetCollection("psi");

            Izlozba i = VratiIzlozbu(izlozba);

            MongoDBRef mref = new MongoDBRef("izlozbe",i.Id);
            var query1 = (from pas in pasCollection.AsQueryable<Pas>()
             where pas.ime == ime && pas.izlozbe.Contains(mref) && pas.kategorije.Contains(kategorija)
             select pas).FirstOrDefault();

            return query1;
        }
        
        public List<Pas> vratiPseKategorija(string kategorija)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var pasCollection = db.GetCollection("psi");

            List<Pas> lista = new List<Pas>();
            var query1 = from pas in pasCollection.AsQueryable<Pas>()
                         where pas.kategorije.Contains(kategorija)
                         select pas;

            foreach (Pas r in query1)
            {
                lista.Add(r);
            }
            return lista;
        }


        public Pas vratiPsa1(ObjectId id)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var pasCollection = db.GetCollection("psi");

           
            var query1 =( from pas in pasCollection.AsQueryable<Pas>()
                         where pas.Id==id
                         select pas).FirstOrDefault();

          
            return query1;
        }

        //novo
        public List<Pas> vratiPseKI(string kategorija,string izlozba)
        {
            
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var pasCollection = db.GetCollection("psi");
           
            Izlozba m = VratiIzlozbu(izlozba);
            MongoDBRef m1 = new MongoDBRef("izlozbe", m.Id);
            List<Pas> lista = new List<Pas>();
            var query1 = from pas in pasCollection.AsQueryable<Pas>()
                         where pas.kategorije.Contains(kategorija) && pas.izlozbe.Contains(m1)
                         select pas;

            foreach (Pas r in query1)
            {
                lista.Add(r);
            }
            return lista;
        }

        //novo
        public List<Pas> vratiPseI(string izlozba)
        {

            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var pasCollection = db.GetCollection("psi");

            Izlozba m = VratiIzlozbu(izlozba);
           
            MongoDBRef m1 = new MongoDBRef("izlozbe", m.Id);
            List<Pas> lista = new List<Pas>();
            var query1 = from pas in pasCollection.AsQueryable<Pas>()
                         where pas.izlozbe.Contains(m1)
                         select pas;

          foreach (Pas r in query1)
            {
                lista.Add(r);
            }
            
            return lista;
        }


        public void DodajPsa(string ime,string pol,string rasa, float tezina,Vlasnik vlasnik, List<String> kategorije,String slika,int starost,Izlozba i)
        {
            DataProvider d = new DataProvider();
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");
            MongoDBRef m = new MongoDBRef("vlasnici",vlasnik.Id);
            MongoDBRef i1 = new MongoDBRef("izlozbe", i.Id);

            var collection = db.GetCollection<Pas>("psi");

            Pas pas1 = new Pas
            {
          
                ime = ime,
                pol = pol,
                rasa = rasa,
                tezina = tezina,
                vlasnik = m,
                kategorije = kategorije,
                slika = slika,
                starost=starost,
                
            };
            pas1.izlozbe.Add(i1);
            
            collection.Insert(pas1);
            
            var vcollection = db.GetCollection<Vlasnik>("vlasnici");
            var izcollection = db.GetCollection<Izlozba>("izlozbe");
            
            vlasnik.psi.Add(new MongoDBRef("psi", pas1.Id));
            i.psi.Add(new MongoDBRef("psi", pas1.Id));

            vcollection.Save(vlasnik);
            izcollection.Save(i);
            
        }

        public void ObrisiPsa(string ime,MongoDBRef vlasnik)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var collection = db.GetCollection<Pas>("psi");

            var query1 = from p in collection.AsQueryable<Pas>()
                         where p.ime == ime && p.vlasnik == vlasnik
                         select p;
            collection.Remove((IMongoQuery)query1);
        }

        public void ObrisiPsaOdVlasnika( MongoDBRef vlasnik)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var collection = db.GetCollection<Pas>("psi");

            var query1 = from p in collection.AsQueryable<Pas>()
                         where p.vlasnik == vlasnik
                         select p;
            collection.Remove((IMongoQuery)query1);

            ObrisiDostignucePsa((MongoDBRef)query1);
        }
        #endregion

        #region Vlasnik

        public List<MongoDBRef> vratiPseVlasnika(string ime)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var vlasnikCollection = db.GetCollection("vlasnici");

            List<MongoDBRef> lista = new List<MongoDBRef>();
            var query1 = from vlasnik in vlasnikCollection.AsQueryable<Vlasnik>()
                         where vlasnik.ime==ime
                         select vlasnik;

            Vlasnik v = (Vlasnik)query1;

            foreach (MongoDBRef p in v.psi)
            {
                lista.Add(p);
            }
            return lista;
        }

        public Vlasnik VratiVlasnika(string ime)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var vlasnikCollection = db.GetCollection("vlasnici");

             var query1 = ( from vlasnik in vlasnikCollection.AsQueryable<Vlasnik>()
                          where vlasnik.ime == ime
                          select vlasnik).FirstOrDefault();
         
            return query1;
        }

        public Vlasnik VratiVlasnikaU(string username,string password)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var vlasnikCollection = db.GetCollection("vlasnici");

            var query1 = (from vlasnik in vlasnikCollection.AsQueryable<Vlasnik>()
                          where vlasnik.username == username && vlasnik.password==password
                          select vlasnik).FirstOrDefault();

            return query1;
        }

        public void DodajVlasnika(string ime,string prezime,string kontakt, string username,string password, List<MongoDBRef> psi)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            

            var collection = db.GetCollection<Vlasnik>("vlasnici");

            Vlasnik v1 = new Vlasnik
            {
                ime = ime,
                prezime = prezime,
                kontakt = kontakt,
                username = username,
                password=password,
                psi=psi
            };

            collection.Insert(v1);
        }

        public void DodajVlasnika1(string ime, string prezime, string kontakt, string username, string password)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");



            var collection = db.GetCollection<Vlasnik>("vlasnici");

            Vlasnik v1 = new Vlasnik
            {
                ime = ime,
                prezime = prezime,
                kontakt = kontakt,
                username=username,
                password=password
            };

            collection.Insert(v1);
        }

        public void UpdateVlasnika(Pas pas,string ime)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var collection = db.GetCollection<Vlasnik>("vlasnici");

            var query = from d in collection.AsQueryable<Vlasnik>()
                        where d.ime == ime
                        select d;
           
            MongoDBRef ref1 = new MongoDBRef("psi",pas.Id); 
            var update = MongoDB.Driver.Builders.Update.Set("psi", BsonValue.Create(new List<MongoDBRef> { ref1 }));

            collection.Update((IMongoQuery)query, update);
        }

        public void ObrisiVlasnika(string ime, string prezime)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var collection = db.GetCollection<Vlasnik>("vlasnici");

            var query1 = from vlasnik in collection.AsQueryable<Vlasnik>()
                         where vlasnik.ime==ime && vlasnik.prezime==prezime
                         select vlasnik;
            collection.Remove((IMongoQuery)query1);

            //brisanje pasa tog vlasnika
            ObrisiPsaOdVlasnika((MongoDBRef)query1);
        }
        #endregion

        #region Dostignuce

        public void CreateDostignuce(Pas pas, Izlozba izlozba, String kategorija,int ocena)
        {
            DataProvider d = new DataProvider();
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");
            MongoDBRef m = new MongoDBRef("psi", pas.Id);
            MongoDBRef i1 = new MongoDBRef("izlozbe", izlozba.Id);
            
            var collection = db.GetCollection<Dostignuce>("dostignuca");
            List<int> o = new List<int>();
            o.Add(ocena);
            Dostignuce dostignuce = new Dostignuce
            {

               pas=m,
               izlozba=i1,
               kategorija=kategorija,
               ocene=o,
               titula=""

            };
            collection.Insert(dostignuce);
            var psicollection = db.GetCollection<Pas>("psi");
            pas.dostignuca.Add(new MongoDBRef("dostignuca", dostignuce.Id));
            
            psicollection.Save(pas);
            
        }


        public void CreateDostignuce1(Pas pas, Izlozba izlozba, String kategorija)
        {
            DataProvider d = new DataProvider();
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");
            MongoDBRef m = new MongoDBRef("psi", pas.Id);
            MongoDBRef i1 = new MongoDBRef("izlozbe", izlozba.Id);
           
            var collection = db.GetCollection<Dostignuce>("dostignuca");

            Dostignuce dostignuce = new Dostignuce
            {

                pas = m,
                izlozba = i1,
                kategorija = kategorija,
                titula = ""

            };
            collection.Insert(dostignuce);

        }


        public List<MongoDBRef> vratiPseSaDostignucima()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var dostignuceCollection = db.GetCollection("dostignuca");

            List<MongoDBRef> lista = new List<MongoDBRef>();
            var query1 = from dostignuca in dostignuceCollection.AsQueryable<Dostignuce>()
                         where dostignuca.titula=="1"|| dostignuca.titula == "2" || dostignuca.titula == "3"
                         select dostignuca;

            

            foreach (Dostignuce d in query1)
            {
                lista.Add(d.pas);
            }
            return lista;
        }

        public List<Dostignuce> Uporedi(string izlozba,string kategorije)
        {
            List<Pas> psi = new List<Pas>();
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");
            Izlozba i1 = VratiIzlozbu(izlozba);
            MongoDBRef m1 = new MongoDBRef("izlozbe", i1.Id);
            var dostignuceCollection = db.GetCollection("dostignuca");

            List<Dostignuce> dostignuca = vratiDostignuca(izlozba, kategorije);
            List<Dostignuce> dos = dostignuca.OrderByDescending(dostignuce => dostignuce.prosecnaOcena()).ToList();
          
            int i = 0;
            foreach(Dostignuce d in dos)
            {
               d.titula = (i + 1).ToString();
                var query = Query.EQ("Id", d.Id);
                var up = MongoDB.Driver.Builders.Update.Set("titula", d.titula);
                dostignuceCollection.Update(query, up);
                dostignuceCollection.Save(d);
                i++;
            }
  
            return dos;
        }


          public List<Dostignuce> vratiDostignuca(string izlozba,string kategorija)
          {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");
            Izlozba i = VratiIzlozbu(izlozba); 
            MongoDBRef m1 = new MongoDBRef("izlozbe", i.Id);
          

            var dostignuceCollection = db.GetCollection("dostignuca");



            List<Dostignuce> d=new List<Dostignuce>();
            var query1 = from dostignuce in dostignuceCollection.AsQueryable<Dostignuce>()
                          where  dostignuce.izlozba == m1 && dostignuce.kategorija == kategorija
                          select dostignuce;

            foreach (Dostignuce dos in query1)
            {
                d.Add(dos);
            }
            return d;

        }

        public List<Dostignuce> vratiDostignucaI(string izlozba)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            Izlozba i = VratiIzlozbu(izlozba);

            MongoDBRef m1 = new MongoDBRef("izlozbe", i.Id);


            var dostignuceCollection = db.GetCollection("dostignuca");



            List<Dostignuce> d = new List<Dostignuce>();
            var query1 = from dostignuce in dostignuceCollection.AsQueryable<Dostignuce>()
                         where dostignuce.izlozba == m1
                         select dostignuce;

            foreach (Dostignuce dos in query1)
            {
                d.Add(dos);
            }
            return d;

        }




        public Dostignuce vratiDostignuce(Pas pas, Izlozba izlozba, string kategorija)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");
            
            MongoDBRef m1 = new MongoDBRef("izlozbe", izlozba.Id);
            MongoDBRef m2 = new MongoDBRef("psi", pas.Id);

            var dostignuceCollection = db.GetCollection("dostignuca");

           

            Dostignuce d;
            var query1 = (from dostignuce in dostignuceCollection.AsQueryable<Dostignuce>()
                          where dostignuce.pas == m2 && dostignuce.izlozba == m1 && dostignuce.kategorija == kategorija
                          select dostignuce).FirstOrDefault();
           
            return query1;
        }

        public void ObrisiDostignucePsa(MongoDBRef pas)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var collection = db.GetCollection<Dostignuce>("dostignuca");

            var query1 = from d in collection.AsQueryable<Dostignuce>()
                         where d.pas==pas
                         select d;
            collection.Remove((IMongoQuery)query1);
            
        }


        public void UpdateDostignuca(Pas pas, Izlozba izlozba, string kategorija, int ocena)
        {
           
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("dbIzlozba");

            var collection = db.GetCollection<Dostignuce>("dostignuca");
            MongoDBRef m1 = new MongoDBRef("izlozbe", izlozba.Id);
            MongoDBRef m2 = new MongoDBRef("psi", pas.Id);
         
           
            Dostignuce dd = vratiDostignuce(pas,izlozba,kategorija);

            if (dd == null)
            {
                CreateDostignuce(pas, izlozba, kategorija,ocena);
            }
            else
            {
                var query = Query.EQ("Id", dd.Id);
               
                dd.ocene.Add(ocena);
               
               var up = MongoDB.Driver.Builders.Update.Push("ocene", ocena);
               
                collection.Update(query, up);
                collection.Save(dd);   
            }
           
        }

        #endregion
    }
}
