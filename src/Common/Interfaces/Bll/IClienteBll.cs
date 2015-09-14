using NetCoders.MicroErp.Common.Dto;

namespace NetCoders.MicroErp.Common.Interfaces.Bll
{
    public interface IClienteBll : IBllBase<ClienteDto>
    {
        void ValidarNome(ClienteDto cliente);
    }
}
