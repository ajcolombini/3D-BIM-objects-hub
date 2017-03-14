using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIM.Model
{
    //[Serializable]
    //public class Model : IDisposable
    //{
    //    //public Manufacturer manufacturer { get; set; }
    //    //public Model() { this.manufacturer = new Manufacturer(); }
    //    //~Model() { }

    //    //public void Dispose()
    //    //{
    //    //    this.manufacturer = null;
    //    //}

       
    //}

    [Serializable]
    public class Manufacturer : IDisposable
    {
        public string id { get; set; }
        public string name { get; set; }
        public string formalName { get; set; }
        public string phone { get; set; }
        public string eMail { get; set; }
        public string webSite { get; set; }
        public byte[] logo { get; set; }
        public List<Product> products { get; set; }

        public Manufacturer() { this.products = new List<Product>(); }

        public void Dispose()
        {
            this.products = null;
        }
    }

    [Serializable]
    public class Product : IDisposable
    {
        public string id { get; set; }
        public string code { get; set; }
        public int subTypeId { get; set; }
        public int categoryId { get; set; }
        public int manufacturerId { get; set; }
        public int familyId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string dimensions { get; set; }
        public string voltage { get; set; }
        public string energyConsumpsionClass { get; set; }
        public string price { get; set; }
        public string status { get; set; }
        public byte[] image { get; set; }
        public List<Document> docs { get; set; }
        public Product() { this.docs = new List<Document>(); }

        public void Dispose()
        {
            this.docs = null;
        }
    }

    [Serializable]
    public class Document : IDisposable
    {
        public string id { get; set; }
        public string name { get; set; }
        public string format { get; set; }
        public string sizeKb { get; set; }
        public byte[] docObject { get; set; }

        public void Dispose()
        {
        }
    }

   

}