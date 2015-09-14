using NetCoders.MicroErp.Common.Dto;
using NetCoders.MicroErp.Common.Interfaces.Dal;
using NetCoders.MicroErp.Dal.Base;
using System.Collections.Generic;
using System.Data;

namespace NetCoders.MicroErp.Dal
{
    public sealed class CompraItemDal : DalBase<CompraItemDto>, ICompraItemDal
    {
        public override CompraItemDto Get(int id)
        {
            base.ConexaoBase.CommandText = "ConsultarCompraItemPorIdCompraItem";
            return base.ConexaoBase.GetById(id);
        }

        public override IEnumerable<CompraItemDto> Get()
        {
            base.ConexaoBase.CommandText = "ConsultarComprasItens";
            return base.ConexaoBase.GetAll();
        }

        public override void Add(CompraItemDto dto)
        {
            base.ConexaoBase.CommandText = "AdicionarCompraItem";
            base.ConexaoBase.AddWithValue("@IdCompra", dto.Compra.IdCompra, DbType.Int32);
            base.ConexaoBase.Add(dto);
        }

        public override void Update(CompraItemDto dto)
        {
            base.ConexaoBase.CommandText = "AtualizarCompraItemPorIdCompraItem";
            base.ConexaoBase.Update(dto);
        }

        public override void Delete(int id)
        {
            base.ConexaoBase.CommandText = "ExcluirCompraItemPorIdCompraItem";
            base.ConexaoBase.Delete(id);
        }

        public IEnumerable<CompraItemDto> GetByIdCompra(int idCompra)
        {
            base.ConexaoBase.CommandText = "ConsultarCompraItemPorIdCompra";
            base.ConexaoBase.AddWithValue("@IdCompra", idCompra, DbType.Int32);
            return base.ConexaoBase.GetAll();
        }

        public void DeleteByIdCompra(int idCompra)
        {
            base.ConexaoBase.CommandText = "ExcluirCompraItemPorIdCompra";
            base.ConexaoBase.AddWithValue("@IdCompra", idCompra, DbType.Int32);
            base.ConexaoBase.ExecuteNonQuery();
        }
    }
}
