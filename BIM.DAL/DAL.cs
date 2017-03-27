using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Data;
using BIM.Model;
using System.Data.SqlClient;
using System.Data;

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
    public static class FabricanteDAO
    {
        public static DataSet FindAnything(string param)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>() { new SqlParameter("@param", param) };
            return (new clsConexaoDAO()).ReturnDataSet("[spGetAll]", _paramList);
        }

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
    public static class ProdutoDAO
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
            #region procParams
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
            #endregion

            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Insert),
                new SqlParameter("@Id", oProduct.Id),
                new SqlParameter("@IdFabricante", oProduct.IdFabricante),
                new SqlParameter("@Codigo", oProduct.Codigo),
                new SqlParameter("@Nome", oProduct.Nome),
                new SqlParameter("@Descricao", oProduct.Descricao),
                //new SqlParameter("@IdCategoria", oProduct.IdCategoria),
                new SqlParameter("@IdFamilia", oProduct.IdFamilia),
                new SqlParameter("@IdSubtipo", oProduct.IdSubtipo),
                new SqlParameter("@Dimensoes", oProduct.Dimensoes),
                new SqlParameter("@Voltagem", oProduct.Voltagem),
                new SqlParameter("@ClasseConsumo", oProduct.ClasseConsumo),
                new SqlParameter("@Preco", oProduct.Preco),
                new SqlParameter("@Status", oProduct.Status),
                new SqlParameter("@Imagem", oProduct.Imagem)
                
            };

            return clsCrudGenericDAO.InsertAndReturnGuid("[spSetProduto]", _paramList);
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
                //new SqlParameter("@IdCategoria", oProduct.IdCategoria),
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
    public static class DocumentoDAO
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

        public static Guid Insert(Documento oDocumento)
        {

            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Insert),
                new SqlParameter("@IdProduto", oDocumento.IdProduto),
                new SqlParameter("@Titulo", oDocumento.Titulo),
                new SqlParameter("@Formato", oDocumento.Formato),
                new SqlParameter("@TamanhoKb", oDocumento.TamanhoKb),
                new SqlParameter("@Objeto", oDocumento.Objeto)
            };

            return clsCrudGenericDAO.InsertAndReturnGuid("[spSetDocumento]", _paramList);
        }

        public static void Delete(Documento oDocumento)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Delete),
                new SqlParameter("@Id", oDocumento.Id)
            };

            clsCrudGenericDAO.Delete("[spSetDocumento]", _paramList);
        }

        public static void Update(Documento oDocumento)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Update),
                new SqlParameter("@Id", oDocumento.Id),
                new SqlParameter("@IdProduto", oDocumento.IdProduto),
                new SqlParameter("@Titulo", oDocumento.Titulo),
                new SqlParameter("@Formato", oDocumento.Formato),
                new SqlParameter("@TamanhoKb", oDocumento.TamanhoKb),
                new SqlParameter("@Objeto", oDocumento.Objeto)
            };

            clsCrudGenericDAO.Update("[spSetDocumentoo]", _paramList);
        }
    }
    #endregion

    #region Familia
    public static class FamiliaDAO
    {
        public static List<Familia> FindAll()
        {
            return clsCrudGenericDAO.FindAll<Familia>("[spGetFamilia]", null);
        }

        public static List<Familia> FindAny(Familia oFamilia)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("@Nome", oFamilia.Descricao),
                new SqlParameter("@Ativo", oFamilia.Ativo)
            };

            return clsCrudGenericDAO.FindAny<Familia>("[spGetFamilia]", _paramList);
        }

        public static Familia FindId(Guid Id)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>() { (new SqlParameter("@Id", Id)) };
            return clsCrudGenericDAO.FindId<Familia>("[spGetFamilia]", _paramList);
        }

        public static Guid Insert(Familia oFamilia)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("@Descricao", oFamilia.Descricao),
                new SqlParameter("@Ativo", oFamilia.Ativo)
            };

            return clsCrudGenericDAO.InsertAndReturnGuid("[spSetFamilia]", _paramList);
        }

        public static void Delete(Familia oFamilia)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Delete),
                new SqlParameter("@Id", oFamilia.Id)
            };

            clsCrudGenericDAO.Delete("[spSetFamilia]", _paramList);
        }

        public static void Update(Familia oFamilia)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Update),
                new SqlParameter("@Id", oFamilia.Id),
                new SqlParameter("@Nome", oFamilia.Descricao),
                new SqlParameter("@Ativo", oFamilia.Ativo)
            };

            clsCrudGenericDAO.Update("[spSetFamilia]", _paramList);
        }

    }
    #endregion

    #region Subtipo
    public static class SubtipoDAO
    {
        public static List<Subtipo> FindAll()
        {
            return clsCrudGenericDAO.FindAll<Subtipo>("[spGetSubtipo]", null);
        }

        public static List<Subtipo> FindAny(Subtipo oSubtipo)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("@Nome", oSubtipo.Descricao),
                new SqlParameter("@Ativo", oSubtipo.Ativo)
            };

            return clsCrudGenericDAO.FindAny<Subtipo>("[spGetSubtipo]", _paramList);
        }

        public static Subtipo FindId(Guid Id)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>() { (new SqlParameter("@Id", Id)) };
            return clsCrudGenericDAO.FindId<Subtipo>("[spGetSubtipo]", _paramList);
        }

        public static Guid Insert(Subtipo oSubtipo)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("@Descricao", oSubtipo.Descricao),
                new SqlParameter("@Ativo", oSubtipo.Ativo)
            };

            return clsCrudGenericDAO.InsertAndReturnGuid("[spSetSubtipo]", _paramList);
        }

        public static void Delete(Subtipo oSubtipo)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Delete),
                new SqlParameter("@Id", oSubtipo.Id)
            };

            clsCrudGenericDAO.Delete("[spSetSubtipo]", _paramList);
        }

        public static void Update(Subtipo oSubtipo)
        {
            List<SqlParameter> _paramList = new List<SqlParameter>()
            {
                new SqlParameter("OpType", (int)OperatinType.Update),
                new SqlParameter("@Id", oSubtipo.Id),
                new SqlParameter("@Nome", oSubtipo.Descricao),
                new SqlParameter("@Ativo", oSubtipo.Ativo)
            };

            clsCrudGenericDAO.Update("[spSetSubtipo]", _paramList);
        }

    }
    #endregion


}

