using NetCoders.MicroErp.Common.Attributes;
using System;
using System.Collections.Generic;

namespace NetCoders.MicroErp.Common.Dto
{
    public sealed class CompraDto
    {

        public CompraDto()
        {
            Fornecedor = new FornecedorDto();
            Itens = new List<CompraItemDto>();
        }

        [IsId]
        public int IdCompra { get; set; }

        [IsBind(false)]
        public FornecedorDto Fornecedor { get; set; }

        [IsBind("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [IsBind(false)]
        public IEnumerable<CompraItemDto> Itens { get; set; }

    }
}
