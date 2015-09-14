using NetCoders.MicroErp.Common.Dto;
using System;

namespace NetCoders.MicroErp.Bll.Exceptions
{

    public class FornecedorException : BaseException
    {
        public FornecedorDto Fornecedor { get; set; }

        public FornecedorException(string message)
            : base(message) { }

        public FornecedorException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
