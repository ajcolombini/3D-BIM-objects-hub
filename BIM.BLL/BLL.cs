using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIM.Model;
using BIM.DAL;

namespace BIM.BLL
{
    public class ManufacturerBLO
    {
        public static List<Manufacturer> FindAll()
        {
            return ManufacturerDAO.FindAll();
        }

        public static List<Manufacturer> FindAny(Manufacturer oManufacturer)
        {
            return ManufacturerDAO.FindAny(oManufacturer);
        }

        public static Manufacturer FindId(Guid Id)
        {
            return ManufacturerDAO.FindId(Id);
        }

        public static Guid Insert(Manufacturer oManufacturer)
        {
           return ManufacturerDAO.Insert(oManufacturer);
        }

        public static void Delete(Manufacturer oManufacturer)
        {
            ManufacturerDAO.Delete(oManufacturer);
        }

        public static void Update(Manufacturer oManufacturer)
        {
            ManufacturerDAO.Update(oManufacturer);
        }
    }

    public static class ProductBLO {
        public static List<Product> FindAll()
        {
            return ProductDAO.FindAll();
        }

        public static List<Product> FindAny(Product oProduct)
        {
            return ProductDAO.FindAny(oProduct);
        }

        public static Product FindId(Guid Id)
        {
            return ProductDAO.FindId(Id);
        }

        public static Guid Insert(Product oProduct)
        {
            return ProductDAO.Insert(oProduct);
        }

        public static void Delete(Product oProduct)
        {
            ProductDAO.Delete(oProduct);
        }

        public static void Update(Product oProduct)
        {
            ProductDAO.Update(oProduct);
        }

    }

    public static class DocumentBLO {

        public static List<Document> FindAll()
        {
            return DocumentDAO.FindAll();
        }

        public static List<Document> FindAny(Document oDocument)
        {
            return DocumentDAO.FindAny(oDocument);
        }

        public static Document FindId(Guid Id)
        {
            return DocumentDAO.FindId(Id);
        }

        //public static Guid Insert(Document oDocument)
        //{
        //    return DocumentDAO.Insert(oDocument);
        //}

        //public static void Delete(Document oDocument)
        //{
        //    DocumentDAO.Delete(oDocument);
        //}

        //public static void Update(Document oDocument)
        //{
        //    DocumentDAO.Update(oDocument);
        //}
    }

}
