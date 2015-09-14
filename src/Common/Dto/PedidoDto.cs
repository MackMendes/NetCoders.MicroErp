using System;
using System.Collections.Generic;

namespace NetCoders.MicroErp.Common.Dto
{
    public sealed class PedidoDto
    {
        public PedidoDto()
        {
            Cliente = new ClienteDto();
            Itens = new List<PedidoItemDto>();
            EnderecoEntrega = new EnderecoDto();

        }

        public int IdPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public ClienteDto Cliente { get; set; }
        public IEnumerable<PedidoItemDto> Itens { get; set; }
        public EnderecoDto EnderecoEntrega { get; set; }

    }
}
