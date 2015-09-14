using System;
using System.Collections.Generic;
using System.Data;

namespace NetCoders.MicroErp.Common.Interfaces.Dal
{
    public interface IDalBase<TDto> where TDto : class
    {
        TDto Get(int id);

        IEnumerable<TDto> Get();

        void Add(TDto dto);

        void Update(TDto dto);

        void Delete(int id);
    }
}
