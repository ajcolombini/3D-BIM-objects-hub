using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIM.Model;
using BIM.DAL;

namespace BIM.BLL
{
    public class FabricanteBLO
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



    public static class ProdutoBLO {

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

        public static Guid Insert(Documento oDocumento)
        {
            return DocumentoDAO.Insert(oDocumento);
        }

        public static void Delete(Documento oDocumento)
        {
            DocumentoDAO.Delete(oDocumento);
        }

        public static void Update(Documento oDocumento)
        {
            DocumentoDAO.Update(oDocumento);
        }
    }



    public static class FamiliaBLO
    {
        public static List<Familia> FindAll()
        {
            return FamiliaDAO.FindAll();
        }

        public static List<Familia> FindAny(Familia oFamilia)
        {
            return FamiliaDAO.FindAny(oFamilia);
        }

        public static Familia FindId(Guid Id)
        {
            return FamiliaDAO.FindId(Id);
        }

        public static Guid Insert(Familia oFamilia)
        {
            return FamiliaDAO.Insert(oFamilia);
        }

        public static void Delete(Familia oFamilia)
        {
            FamiliaDAO.Delete(oFamilia);
        }

        public static void Update(Familia oFamilia)
        {
            FamiliaDAO.Update(oFamilia);
        }

    }



    public static class SubtipoBLO
    {
        public static List<Subtipo> FindAll()
        {
            return SubtipoDAO.FindAll();
        }

        public static List<Subtipo> FindAny(Subtipo oSubtipo)
        {
            return SubtipoDAO.FindAny(oSubtipo);
        }

        public static Subtipo FindId(Guid Id)
        {
            return SubtipoDAO.FindId(Id);
        }

        public static Guid Insert(Subtipo oSubtipo)
        {
            return SubtipoDAO.Insert(oSubtipo);
        }

        public static void Delete(Subtipo oSubtipo)
        {
            SubtipoDAO.Delete(oSubtipo);
        }

        public static void Update(Subtipo oSubtipo)
        {
            SubtipoDAO.Update(oSubtipo);
        }

    }

}
