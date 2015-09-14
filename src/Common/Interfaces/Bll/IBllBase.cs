
using System.Collections.Generic;
namespace NetCoders.MicroErp.Common.Interfaces.Bll
{
    public interface IBllBase<TDto>
    {
        TDto Consultar(int id);
        IEnumerable<TDto> Consultar();
        void Atualizar(TDto dto);
        void Adicionar(TDto dto);
        void Excluir(int id);
        void ValidarId(int id);
        void ValidaNull(TDto dto);
        void ValidarExistente(int id);
        bool IsExistente(int id);
    }
}
