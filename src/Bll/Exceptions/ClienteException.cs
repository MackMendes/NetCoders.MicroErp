using NetCoders.MicroErp.Common.Dto;
using System;

namespace NetCoders.MicroErp.Bll.Exceptions
{
    public class ClienteException : BaseException
    {
        public ClienteDto ClienteDto { get; set; }

        public ClienteException(string mensagem)
            : base(mensagem) { }

        public ClienteException(string mensagem, Exception innerException)
            : base(mensagem, innerException) { }

    }
}
