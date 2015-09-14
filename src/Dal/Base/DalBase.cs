using NetCoders.MicroErp.Common.Interfaces.Dal;
using System.Collections.Generic;

namespace NetCoders.MicroErp.Dal.Base
{
    public abstract class DalBase<TDto> : IDalBase<TDto> where TDto : class
    {        
        internal IConexao<TDto> ConexaoBase { get; private set; }

        public DalBase()
        {
            ConexaoBase = new Conexao<TDto>("NetCodersMicroErp");
        }

        public abstract TDto Get(int id);

        public abstract IEnumerable<TDto> Get();

        public abstract void Add(TDto dto);

        public abstract void Update(TDto dto);

        public abstract void Delete(int id);
    }
}
