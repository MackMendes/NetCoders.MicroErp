using System;

namespace NetCoders.MicroErp.Common.Dto
{
    public sealed class ClienteDto
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
