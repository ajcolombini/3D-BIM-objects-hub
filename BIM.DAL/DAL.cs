using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Data;
using BIM.Model;
using System.Data.SqlClient;

namespace BIM.DAL
{
    public enum OperatinType
    {
        Insert = 1,
        Update = 2,
        Delete = 3,
        Search = 4
    }

    #region Fabricante
    public static class ManufacturerDAO
    {
        
        public static List<Manufacturer> FindAll()
        {
            return clsCrudGenericDAO.FindAll<Manufacturer>("[spGetFabricante]", null);
        }

        public static List<Manufacturer> FindAny(Manufacturer oManufacturer)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("@Nome", oManufacturer.name),
                new SqlParameter("@RazaoSocial", oManufacturer.formalName)
            };

            return clsCrudGenericDAO.FindAny<Manufacturer>("[spGetFabricante]", _paramList);
        }

        public static Manufacturer FindId(Guid Id)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>() { (new SqlParameter("@Id", Id))};
            return clsCrudGenericDAO.FindId<Manufacturer>("[spGetFabricante]", _paramList);
        }

        public static Guid Insert(Manufacturer oManufacturer)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Insert),
                new SqlParameter("@Nome", oManufacturer.name),
                new SqlParameter("@RazaoSocial", oManufacturer.formalName),
                new SqlParameter("@Telefone", oManufacturer.phone),
                new SqlParameter("@Site", oManufacturer.webSite),
                new SqlParameter("@Email", oManufacturer.eMail),
                new SqlParameter("@Logo", oManufacturer.logo)
            };

            return clsCrudGenericDAO.InsertAndReturnGuid("[spSetFabricante]", _paramList);
        }

        public static void Delete(Manufacturer oManufacturer)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Delete),
                new SqlParameter("@Id", oManufacturer.id)
            };

            clsCrudGenericDAO.Delete("[spSetFabricante]", _paramList);
        }

        public static void Update(Manufacturer oManufacturer)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Update),
                new SqlParameter("@Id", oManufacturer.id),
                new SqlParameter("@Nome", oManufacturer.name),
                new SqlParameter("@RazaoSocial", oManufacturer.formalName),
                new SqlParameter("@Telefone", oManufacturer.phone),
                new SqlParameter("@Site", oManufacturer.webSite),
                new SqlParameter("@Email", oManufacturer.eMail),
                new SqlParameter("@Logo", oManufacturer.logo)
            };

             clsCrudGenericDAO.Update("[spSetFabricante]", _paramList);
        }

    }
    #endregion

    #region Produto
    public static class ProductDAO
    {
        public static List<Product> FindAll()
        {
            return clsCrudGenericDAO.FindAll<Product>("[spGetProduto]", null);
        }

        public static Product FindId(Guid Id)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>() { (new SqlParameter("@Id", Id)) };
            return clsCrudGenericDAO.FindId<Product>("[spGetProduto]", _paramList);
        }

        public static List<Product> FindAny(Product oProduct)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("@Codigo", oProduct.code),
                new SqlParameter("@Nome", oProduct.name),
                new SqlParameter("@Descricao", oProduct.description),
                new SqlParameter("@Dimensoes", oProduct.dimensions),
                new SqlParameter("@Voltagem", oProduct.voltage),
                new SqlParameter("@ClasseConsumo", oProduct.energyConsumpsionClass),
                new SqlParameter("@Preco", oProduct.price),
                new SqlParameter("@Status", oProduct.status)
            };

            return clsCrudGenericDAO.FindAny<Product>("[spGetProduto]", _paramList);
        }

        public static Guid Insert(Product oProduct)
        {
            /*@OpType int = null,
								  @Id uniqueidentifier = null,
								  @IdFabricante  uniqueidentifier = null,
								  @Codigo varchar(150) = null,
								  @Nome varchar(250) = null,
								  @Descricao  varchar(500) = null,
								  @IdCategoria int = null,
								  @IdFamilia int = null,
								  @IdSubtipo int = null,
								  @Dimensoes varchar(150) = null,
								  @Voltagem varchar(50) = null,
								  @ClasseConsumo  varchar(50) = null,
								  @Preco decimal(10,2) = null,
								  @Status varchar(250) = null,
								  @Imagem varchar(1000) = null
               */
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Insert),
                new SqlParameter("@IdFabricante", oProduct.manufacturerId),
                new SqlParameter("@Codigo", oProduct.code),
                new SqlParameter("@Nome", oProduct.name),
                new SqlParameter("@Descricao", oProduct.description),
                new SqlParameter("@IdCategoria", oProduct.categoryId),
                new SqlParameter("@IdFamilia", oProduct.familyId),
                new SqlParameter("@IdSubtipo", oProduct.subTypeId),
                new SqlParameter("@Dimensoes", oProduct.dimensions),
                new SqlParameter("@Voltagem", oProduct.voltage),
                new SqlParameter("@ClasseConsumo", oProduct.energyConsumpsionClass),
                new SqlParameter("@Preco", oProduct.price),
                new SqlParameter("@Status", oProduct.status),
                new SqlParameter("@Imagem", oProduct.image)
                
            };

            return clsCrudGenericDAO.InsertAndReturnGuid("[spSetProducto]", _paramList);
        }

        public static void Delete(Product oProduct)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Delete),
                new SqlParameter("@Id", oProduct.id)
            };

            clsCrudGenericDAO.Delete("[spSetProducto]", _paramList);
        }

        public static void Update(Product oProduct)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Update),
                new SqlParameter("@Id", oProduct.id),
                new SqlParameter("@IdFabricante", oProduct.manufacturerId),
                new SqlParameter("@Codigo", oProduct.code),
                new SqlParameter("@Nome", oProduct.name),
                new SqlParameter("@Descricao", oProduct.description),
                new SqlParameter("@IdCategoria", oProduct.categoryId),
                new SqlParameter("@IdFamilia", oProduct.familyId),
                new SqlParameter("@IdSubtipo", oProduct.subTypeId),
                new SqlParameter("@Dimensoes", oProduct.dimensions),
                new SqlParameter("@Voltagem", oProduct.voltage),
                new SqlParameter("@ClasseConsumo", oProduct.energyConsumpsionClass),
                new SqlParameter("@Preco", oProduct.price),
                new SqlParameter("@Status", oProduct.status),
                new SqlParameter("@Imagem", oProduct.image)
            };

            clsCrudGenericDAO.Update("[spSetProducto]", _paramList);
        }

      
    }
    #endregion


    #region Documento
    public static class DocumentDAO
    {
        public static List<Document> FindAll()
        { 
            return clsCrudGenericDAO.FindAll<Document>("[spGetDocumento]", null);
        }

        public static List<Document> FindAny(Document oDocument)
        {
            throw new NotImplementedException();
        }

        public static Document FindId(Guid Id)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>() { (new SqlParameter("@Id", Id)) };
            return clsCrudGenericDAO.FindId<Document>("[spGetDocumento]", _paramList);
        }

        //public static Guid Insert(Document oDocument)
        //{
           
        //    List<SqlParameter> _paramList = new List<SqlParameter>()
        //    {
        //        new SqlParameter("OpType", (int)OperatinType.Insert),
        //        new SqlParameter("@IdFabricante", oDocument.manufacturerId),
        //        new SqlParameter("@Codigo", oDocument.code),
        //        new SqlParameter("@Nome", oDocument.name),
        //        new SqlParameter("@Descricao", oDocument.description),
        //        new SqlParameter("@IdCategoria", oDocument.categoryId),
        //        new SqlParameter("@IdFamilia", oDocument.familyId),
        //        new SqlParameter("@IdSubtipo", oDocument.subTypeId),
        //        new SqlParameter("@Dimensoes", oDocument.dimensions),
        //        new SqlParameter("@Voltagem", oDocument.voltage),
        //        new SqlParameter("@ClasseConsumo", oDocument.energyConsumpsionClass),
        //        new SqlParameter("@Preco", oDocument.price),
        //        new SqlParameter("@Status", oDocument.status),
        //        new SqlParameter("@Imagem", oDocument.image)

        //    };

        //    return clsCrudGenericDAO.InsertAndReturnGuid("[spSetDocumento]", _paramList);
        //}

        //public static void Delete(Document oDocument)
        //{
        //    List<SqlParameter> _paramList = new List<SqlParameter>()
        //    {
        //        new SqlParameter("OpType", (int)OperatinType.Delete),
        //        new SqlParameter("@Id", oDocument.id)
        //    };

        //    clsCrudGenericDAO.Delete("[spSetDocumento]", _paramList);
        //}

        //public static void Update(Document oDocument)
        //{
        //    List<SqlParameter> _paramList = new List<SqlParameter>()
        //    {
        //        new SqlParameter("OpType", (int)OperatinType.Update),
        //        new SqlParameter("@Id", oDocument.id),
        //        new SqlParameter("@IdFabricante", oDocument.manufacturerId),
        //        new SqlParameter("@Codigo", oDocument.code),
        //        new SqlParameter("@Nome", oDocument.name),
        //        new SqlParameter("@Descricao", oDocument.description),
        //        new SqlParameter("@IdCategoria", oDocument.categoryId),
        //        new SqlParameter("@IdFamilia", oDocument.familyId),
        //        new SqlParameter("@IdSubtipo", oDocument.subTypeId),
        //        new SqlParameter("@Dimensoes", oDocument.dimensions),
        //        new SqlParameter("@Voltagem", oDocument.voltage),
        //        new SqlParameter("@ClasseConsumo", oDocument.energyConsumpsionClass),
        //        new SqlParameter("@Preco", oDocument.price),
        //        new SqlParameter("@Status", oDocument.status),
        //        new SqlParameter("@Imagem", oDocument.image)
        //    };

        //    clsCrudGenericDAO.Update("[spSetDocumento]", _paramList);
        //}
    }
    #endregion


}

