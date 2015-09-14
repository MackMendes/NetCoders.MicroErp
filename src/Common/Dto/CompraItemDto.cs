namespace NetCoders.MicroErp.Common.Dto
{
    public sealed class CompraItemDto
    {

        public CompraItemDto()
        {
            Compra = new CompraDto();

        }

        public int IdCompraItem { get; set; }
        public CompraDto Compra { get; set; }
        public ProdutoDto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal Total { get; set; }
    }
}
