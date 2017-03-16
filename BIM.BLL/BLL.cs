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
            return FabricanteDAO.FindAll();
        }

        public static List<Fabricante> FindAny(Fabricante oManufacturer)
        {
            return FabricanteDAO.FindAny(oManufacturer);
        }

        public static Fabricante FindId(Guid Id)
        {
            return FabricanteDAO.FindId(Id);
        }

        public static Guid Insert(Fabricante oManufacturer)
        {
           return FabricanteDAO.Insert(oManufacturer);
        }

        public static void Delete(Fabricante oManufacturer)
        {
            FabricanteDAO.Delete(oManufacturer);
        }

        public static void Update(Fabricante oManufacturer)
        {
            FabricanteDAO.Update(oManufacturer);
        }
    }

    public static class ProductBLO {
        public static List<Produto> FindAll()
        {
            return ProdutoDAO.FindAll();
        }

        public static List<Produto> FindAny(Produto oProduct)
        {
            return ProdutoDAO.FindAny(oProduct);
        }

        public static Produto FindId(Guid Id)
        {
            return ProdutoDAO.FindId(Id);
        }

        public static Guid Insert(Produto oProduct)
        {
            return ProdutoDAO.Insert(oProduct);
        }

        public static void Delete(Produto oProduct)
        {
            ProdutoDAO.Delete(oProduct);
        }

        public static void Update(Produto oProduct)
        {
            ProdutoDAO.Update(oProduct);
        }

    }

    public static class DocumentBLO {

        public static List<Documento> FindAll()
        {
            return DocumentoDAO.FindAll();
        }

        public static List<Documento> FindAny(Documento oDocument)
        {
            return DocumentoDAO.FindAny(oDocument);
        }

        public static Documento FindId(Guid Id)
        {
            return DocumentoDAO.FindId(Id);
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
