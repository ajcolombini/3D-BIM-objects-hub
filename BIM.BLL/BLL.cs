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
        public static List<Fabricante> FindAll()
        {
            return ManufacturerDAO.FindAll();
        }

        public static List<Fabricante> FindAny(Fabricante oManufacturer)
        {
            return ManufacturerDAO.FindAny(oManufacturer);
        }

        public static Fabricante FindId(Guid Id)
        {
            return ManufacturerDAO.FindId(Id);
        }

        public static Guid Insert(Fabricante oManufacturer)
        {
           return ManufacturerDAO.Insert(oManufacturer);
        }

        public static void Delete(Fabricante oManufacturer)
        {
            ManufacturerDAO.Delete(oManufacturer);
        }

        public static void Update(Fabricante oManufacturer)
        {
            ManufacturerDAO.Update(oManufacturer);
        }
    }

    public static class ProductBLO {
        public static List<Produto> FindAll()
        {
            return ProductDAO.FindAll();
        }

        public static List<Produto> FindAny(Produto oProduct)
        {
            return ProductDAO.FindAny(oProduct);
        }

        public static Produto FindId(Guid Id)
        {
            return ProductDAO.FindId(Id);
        }

        public static Guid Insert(Produto oProduct)
        {
            return ProductDAO.Insert(oProduct);
        }

        public static void Delete(Produto oProduct)
        {
            ProductDAO.Delete(oProduct);
        }

        public static void Update(Produto oProduct)
        {
            ProductDAO.Update(oProduct);
        }

    }

    public static class DocumentBLO {

        public static List<Documento> FindAll()
        {
            return DocumentDAO.FindAll();
        }

        public static List<Documento> FindAny(Documento oDocument)
        {
            return DocumentDAO.FindAny(oDocument);
        }

        public static Documento FindId(Guid Id)
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
