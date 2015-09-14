using NetCoders.MicroErp.Bll.Exceptions;
using NetCoders.MicroErp.Common.Interfaces.Bll;
using System.Collections.Generic;

namespace NetCoders.MicroErp.Bll.Base
{
    public abstract class BllBase<TDto> : IBllBase<TDto>
    {
        public abstract TDto Consultar(int id);
        public abstract IEnumerable<TDto> Consultar();
        public abstract void Atualizar(TDto dto);
        public abstract void Adicionar(TDto dto);
        public abstract void Excluir(int id);

        public virtual void ValidarId(int id)
        {
            if (id < 1)
            {
                throw new BaseException(string.Format("O objeto de código {0} não existe!", id));
            }
        }

        public virtual void ValidaNull(TDto dto)
        {
            if (dto == null)
            {
                throw new BaseException("O objeto não pode ser nulo!");
            }
        }

        public virtual void ValidarExistente(int id)
        {
            if (Consultar(id) == null)
            {
                throw new BaseException("O Objeto não foi encontrado!");
            }

        }

        public bool IsExistente(int id)
        {
            return Consultar(id) != null;
        }
    }
}
