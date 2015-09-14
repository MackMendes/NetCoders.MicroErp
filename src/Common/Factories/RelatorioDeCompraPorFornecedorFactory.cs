using NetCoders.MicroErp.Common.Dto.Relatorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoders.MicroErp.Common.Factories
{
    public static class RelatorioDeCompraPorFornecedorFactory
    {
        public static RelatorioDeCompraPorFornecedorDto Create(IDataRecord dataRecord)
        {
            return new RelatorioDeCompraPorFornecedorDto
            {
                NomeFornecedor = (string)dataRecord["NomeFornecedor"],
                QuantidadeCompras = (int)dataRecord["QuantidadeCompras"],
                Total = (decimal)dataRecord["Total"]
            };
        }

        // Esse método é a mesma coisa deste método de CIMA! Mas, esse método abaixo é com Delegate.
        public static Func<IDataRecord, RelatorioDeCompraPorFornecedorDto> CreateDelegate 
            = (dataRecord) => new RelatorioDeCompraPorFornecedorDto
            {
                NomeFornecedor = (string)dataRecord["NomeFornecedor"],
                QuantidadeCompras = (int)dataRecord["QuantidadeCompras"],
                Total = (decimal)dataRecord["Total"]
            };

        
    }
}
