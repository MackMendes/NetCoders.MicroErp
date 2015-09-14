using NetCoders.MicroErp.Common.Dto;
using NetCoders.MicroErp.Common.Dto.Relatorios;
using System.Collections.Generic;

namespace NetCoders.MicroErp.Common.Interfaces.Dal
{
    public interface ICompraDal : IDalBase<CompraDto>
    {
        IEnumerable<RelatorioDeCompraPorFornecedorDto> RelatorioCompraPorFornecedor(int idFornecedor);

        CompraDto ConsultarComFornecedor(int idCompra);
    }
}
