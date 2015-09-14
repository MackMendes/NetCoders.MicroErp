using NetCoders.MicroErp.Common.Dto;
using NetCoders.MicroErp.Common.Dto.Relatorios;
using System.Collections.Generic;

namespace NetCoders.MicroErp.Common.Interfaces.Bll
{
    public interface ICompraBll : IBllBase<CompraDto>
    {
        void ValidarItensExistentes(CompraDto dto);

        IEnumerable<RelatorioDeCompraPorFornecedorDto> RelatorioCompraPorFornecedor(int idFornecedor);

        CompraDto ConsultarCompraComItens(int idCompra);
    }
}
