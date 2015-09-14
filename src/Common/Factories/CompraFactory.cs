using NetCoders.MicroErp.Common.Dto;
using System;
using System.Data;

namespace NetCoders.MicroErp.Common.Factories
{
    public static class CompraFactory
    {
        // Um método com dois parâmetros de entrada, (IDataRecord, int)
        public static Func<IDataRecord, int, CompraDto> CreateComFornecedor
            = (x, idCompra) => new CompraDto
        {
            IdCompra = idCompra,
            Fornecedor = new FornecedorDto
            {
                IdFornecedor = (int)x["IdFornecedor"],
                Nome = (string)x["NomeFornecedor"],
                DataCadastro = (DateTime)x["DataCadastroFornecedor"]
            },
            DataCadastro = (DateTime)x["DataCadastro"]
        };

        public static CompraDto MetodoComum(IDataRecord x)
        {
            var compra = new CompraDto
            {
                IdCompra = (int)x["IdCompra"],
                DataCadastro = (DateTime)x["DataCadastro"],
                Fornecedor = new FornecedorDto
                {
                    IdFornecedor = (int)x["IdFornecedor"]
                }
            };

            return compra;
        }
    }
}
