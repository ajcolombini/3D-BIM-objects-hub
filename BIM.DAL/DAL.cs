﻿using System;
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
        
        public static List<Fabricante> FindAll()
        {
            return clsCrudGenericDAO.FindAll<Fabricante>("[spGetFabricante]", null);
        }

        public static List<Fabricante> FindAny(Fabricante oManufacturer)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("@Nome", oManufacturer.Nome),
                new SqlParameter("@RazaoSocial", oManufacturer.RazaoSocial)
            };

            return clsCrudGenericDAO.FindAny<Fabricante>("[spGetFabricante]", _paramList);
        }

        public static Fabricante FindId(Guid Id)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>() { (new SqlParameter("@Id", Id))};
            return clsCrudGenericDAO.FindId<Fabricante>("[spGetFabricante]", _paramList);
        }

        public static Guid Insert(Fabricante oManufacturer)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Insert),
                new SqlParameter("@Nome", oManufacturer.Nome),
                new SqlParameter("@RazaoSocial", oManufacturer.RazaoSocial),
                new SqlParameter("@Telefone", oManufacturer.Telefone),
                new SqlParameter("@Site", oManufacturer.Site),
                new SqlParameter("@Email", oManufacturer.Email),
                new SqlParameter("@Logo", oManufacturer.Logo)
            };

            return clsCrudGenericDAO.InsertAndReturnGuid("[spSetFabricante]", _paramList);
        }

        public static void Delete(Fabricante oManufacturer)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Delete),
                new SqlParameter("@Id", oManufacturer.Id)
            };

            clsCrudGenericDAO.Delete("[spSetFabricante]", _paramList);
        }

        public static void Update(Fabricante oManufacturer)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Update),
                new SqlParameter("@Id", oManufacturer.Id),
                new SqlParameter("@Nome", oManufacturer.Nome),
                new SqlParameter("@RazaoSocial", oManufacturer.RazaoSocial),
                new SqlParameter("@Telefone", oManufacturer.Telefone),
                new SqlParameter("@Site", oManufacturer.Site),
                new SqlParameter("@Email", oManufacturer.Email),
                new SqlParameter("@Logo", oManufacturer.Logo)
            };

             clsCrudGenericDAO.Update("[spSetFabricante]", _paramList);
        }

    }
    #endregion

    #region Produto
    public static class ProductDAO
    {
        public static List<Produto> FindAll()
        {
            return clsCrudGenericDAO.FindAll<Produto>("[spGetProduto]", null);
        }

        public static Produto FindId(Guid Id)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>() { (new SqlParameter("@Id", Id)) };
            return clsCrudGenericDAO.FindId<Produto>("[spGetProduto]", _paramList);
        }

        public static List<Produto> FindAny(Produto oProduct)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("@Codigo", oProduct.Codigo),
                new SqlParameter("@Nome", oProduct.Nome),
                new SqlParameter("@Descricao", oProduct.Descricao),
                new SqlParameter("@Dimensoes", oProduct.Dimensoes),
                new SqlParameter("@Voltagem", oProduct.Voltagem),
                new SqlParameter("@ClasseConsumo", oProduct.ClasseConsumo),
                new SqlParameter("@Preco", oProduct.Preco),
                new SqlParameter("@Status", oProduct.Status)
            };

            return clsCrudGenericDAO.FindAny<Produto>("[spGetProduto]", _paramList);
        }

        public static Guid Insert(Produto oProduct)
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
                new SqlParameter("@IdFabricante", oProduct.IdFabricante),
                new SqlParameter("@Codigo", oProduct.Codigo),
                new SqlParameter("@Nome", oProduct.Nome),
                new SqlParameter("@Descricao", oProduct.Descricao),
                new SqlParameter("@IdCategoria", oProduct.IdCategoria),
                new SqlParameter("@IdFamilia", oProduct.IdFamilia),
                new SqlParameter("@IdSubtipo", oProduct.IdSubtipo),
                new SqlParameter("@Dimensoes", oProduct.Dimensoes),
                new SqlParameter("@Voltagem", oProduct.Voltagem),
                new SqlParameter("@ClasseConsumo", oProduct.ClasseConsumo),
                new SqlParameter("@Preco", oProduct.Preco),
                new SqlParameter("@Status", oProduct.Status),
                new SqlParameter("@Imagem", oProduct.Imagem)
                
            };

            return clsCrudGenericDAO.InsertAndReturnGuid("[spSetProducto]", _paramList);
        }

        public static void Delete(Produto oProduct)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Delete),
                new SqlParameter("@Id", oProduct.Id)
            };

            clsCrudGenericDAO.Delete("[spSetProducto]", _paramList);
        }

        public static void Update(Produto oProduct)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Update),
                new SqlParameter("@Id", oProduct.Id),
                new SqlParameter("@IdFabricante", oProduct.IdFabricante),
                new SqlParameter("@Codigo", oProduct.Codigo),
                new SqlParameter("@Nome", oProduct.Nome),
                new SqlParameter("@Descricao", oProduct.Descricao),
                new SqlParameter("@IdCategoria", oProduct.IdCategoria),
                new SqlParameter("@IdFamilia", oProduct.IdFamilia),
                new SqlParameter("@IdSubtipo", oProduct.IdSubtipo),
                new SqlParameter("@Dimensoes", oProduct.Dimensoes),
                new SqlParameter("@Voltagem", oProduct.Voltagem),
                new SqlParameter("@ClasseConsumo", oProduct.ClasseConsumo),
                new SqlParameter("@Preco", oProduct.Preco),
                new SqlParameter("@Status", oProduct.Status),
                new SqlParameter("@Imagem", oProduct.Imagem)
            };

            clsCrudGenericDAO.Update("[spSetProducto]", _paramList);
        }

      
    }
    #endregion


    #region Documento
    public static class DocumentDAO
    {
        public static List<Documento> FindAll()
        { 
            return clsCrudGenericDAO.FindAll<Documento>("[spGetDocumento]", null);
        }

        public static List<Documento> FindAny(Documento oDocument)
        {
            throw new NotImplementedException();
        }

        public static Documento FindId(Guid Id)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>() { (new SqlParameter("@Id", Id)) };
            return clsCrudGenericDAO.FindId<Documento>("[spGetDocumento]", _paramList);
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

