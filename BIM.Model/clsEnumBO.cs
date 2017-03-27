using System;

namespace BIM.Model
{

    public enum EnumModule
    {
        Usuario = 1,
        Justificativa = 2,
        PessoaFisica = 4,
        PessoaJuridica = 5,
        AprovacaoCompliance = 7,
        AprovacaoGerencia = 8
    }

    /// <summary>
    /// Perfil de acesso ao sistema.
    /// </summary>
    public enum PerfilAcesso
    {
        NaoInformado = 0,
	    Administrador = 1,
	    Operador1 = 3,
	    Operador2 = 4,
	    Operador3 = 5,
	    Operador4 = 6,
	    ServiceCompliance = 7,
	    Gerente = 8
    }


    /// <summary>
    /// Status utilizado pelo compliance.
    /// </summary>
    public enum Status
    {
        NaoInformado = 0,
        Bloqueado = 1,
        Liberado = 2,
        AguardandoCompliance = 3,
        AguardandoGerente = 4
    }

    public enum TipoPessoa
    {
        PessoaFisica = 0,
        PessoaJuridica = 1
    }


    ///// <summary>
    ///// Status da tabela
    ///// </summary>
    //public enum StatusTabela
    //{
    //    Liberado = 73,
    //    Análise = 3,
    //    Bloqueado = 72
    //}

    public enum TipoMensagem
    {
        NaoInformado = 0,
        Informativo = 1,
        Sucesso = 2,
        Erro = 3
    }

    /// <summary>
    /// Tipo de consulta por Histórico (todas as ocorrências) ou 
    /// Específico (apenas o último registro).
    /// </summary>
    public enum TipoConsulta
    {
        NaoInformado = 0,
        Especifico = 1,
        Historico = 2
    }

    public enum TipoSolicitacao
    {
        Bloquear = 1, // deve ter o mesmo codigo do status "Bloqueado" da tblStatus
        Liberar = 2 //  deve ter o mesmo codigo do status "Liberado" da tblStatus
    }
}
