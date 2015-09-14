
namespace NetCoders.MicroErp.Common.Dto
{
    public sealed class PedidoItemDto
    {
        public int IdPedidoItem { get; set; }
        public PedidoItemDto Pedido { get; set; }
        public ProdutoDto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal Total { get; set; }

    }
}
