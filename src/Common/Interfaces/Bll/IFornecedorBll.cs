using NetCoders.MicroErp.Common.Dto;

namespace NetCoders.MicroErp.Common.Interfaces.Bll
{
    public interface IFornecedorBll : IBllBase<FornecedorDto>
    {
        void ValidarNome(FornecedorDto fornecedor);
    }
}
