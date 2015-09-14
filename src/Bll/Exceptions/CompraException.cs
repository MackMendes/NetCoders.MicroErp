using NetCoders.MicroErp.Common.Dto;
using System;

namespace NetCoders.MicroErp.Bll.Exceptions
{
    public class CompraException : BaseException
    {
        public CompraDto Compra { get; set; }

        public CompraException(string mensagem)
            : base(mensagem) { }

        public CompraException(string mensagem, Exception innerException)
            : base(mensagem, innerException) { }
    }
}
