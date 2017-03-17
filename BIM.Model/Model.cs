using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIM.Model
{


    [Serializable]
    public class Fabricante : IDisposable
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public byte[] Logo { get; set; }
        public List<Produto> products { get; set; }

        public Fabricante() { this.products = new List<Produto>(); }

        public void Dispose()
        {
            this.products = null;
        }
    }

    [Serializable]
    public class Produto : IDisposable
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public int IdFabricante { get; set; }
        public int IdFamilia { get; set; }
        public int IdSubtipo { get; set; }
        //public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Dimensoes { get; set; }
        public string Voltagem { get; set; }
        public string ClasseConsumo { get; set; }
        public decimal Preco { get; set; }
        public string Status { get; set; }
        public byte[] Imagem { get; set; }
        public List<Documento> docs { get; set; }


        public Produto() { this.docs = new List<Documento>(); }

        public void Dispose()
        {
            this.docs = null;
        }
    }

    [Serializable]
    public class Documento : IDisposable
    {
        public Guid Id { get; set; }
        public Guid IdProduto { get; set; }
        public string Titulo { get; set; }
        public string Formato { get; set; }
        public double TamanhoKb { get; set; }
        public byte[] Objeto { get; set; }

        public void Dispose()
        {
        }
    }


    [Serializable]
    public class Familia : IDisposable
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public void Dispose()
        {
        }
    }


    [Serializable]
    public class Subtipo : IDisposable
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public void Dispose()
        {
        }
    }



}