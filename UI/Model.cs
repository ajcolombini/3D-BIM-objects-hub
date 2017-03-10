using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI
{

    public class Doc
    {
        public string id { get; set; }
        public string name { get; set; }
        public string format { get; set; }
        public string sizeKb { get; set; }
        public string docObject { get; set; }
    }

    public class Product
    {
        public string id { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string subType { get; set; }
        public string title { get; set; }
        public string dimensions { get; set; }
        public string voltage { get; set; }
        public string energyConsumpsionClass { get; set; }
        public string price { get; set; }
        public string status { get; set; }
        public string image { get; set; }
        public List<Doc> docs { get; set; }

        Product()
        {
            this.docs = new List<Doc>();
        }
    }

    public class Manufacturer
    {
        public string id { get; set; }
        public string name { get; set; }
        public string formalName { get; set; }
        public string logo { get; set; }
        public string eMail { get; set; }
        public string webSite { get; set; }
        public List<Product> products { get; set; }
    }

    public class ModelObject
    {
        public Manufacturer manufacturer { get; set; }
        ModelObject()
        {
            this.manufacturer.products = new List<Product>();
        }
    }

}