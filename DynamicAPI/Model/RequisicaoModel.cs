using System;
using System.Collections.Generic;

namespace DynamicAPI.Model
{
    public class RequisicaoModel
    {
        public RequisicaoDataModel ConteudoEntrada { get; set; }
        public RequisicaoDataModel ConteudoRetorno { get; set; }
        public RequisicaoAutenticacaoModel Autenticacao { get; set; }
        public IList<RequisicaoAutenticacaoModel> Autenticacoes { get; set; }

    }
}
