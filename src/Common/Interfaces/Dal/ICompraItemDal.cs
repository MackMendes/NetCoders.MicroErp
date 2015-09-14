using NetCoders.MicroErp.Common.Dto;
using System.Collections.Generic;

namespace NetCoders.MicroErp.Common.Interfaces.Dal
{
    public interface ICompraItemDal : IDalBase<CompraItemDto>
    {
        IEnumerable<CompraItemDto> GetByIdCompra(int idCompra);

        void DeleteByIdCompra(int idCompra);
    }
}
