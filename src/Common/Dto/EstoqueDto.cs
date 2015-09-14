using NetCoders.MicroErp.Common.Enums;

namespace NetCoders.MicroErp.Common.Dto
{
    public sealed class EstoqueDto
    {

        public EstoqueDto()
        {
            Produto = new ProdutoDto();
        }

        public int IdEstoque { get; set; }
        public ProdutoDto Produto { get; set; }
        public ProdutoLocalizacaoEnum Localizacao { get; set; }
        public int Quantidade { get; set; }
    }
}
