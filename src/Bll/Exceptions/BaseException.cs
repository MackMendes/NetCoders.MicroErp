using System;

namespace NetCoders.MicroErp.Bll.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string mensagem)
            : base(mensagem)
        {

        }

        public BaseException(string mensagem, Exception innerException)
            : base(mensagem, innerException)
        {

        }
    }
}
