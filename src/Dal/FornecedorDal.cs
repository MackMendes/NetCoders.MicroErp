using NetCoders.MicroErp.Common.Dto;
using NetCoders.MicroErp.Common.Interfaces.Dal;
using NetCoders.MicroErp.Dal.Base;
using System.Collections.Generic;

namespace NetCoders.MicroErp.Dal
{
    public class FornecedorDal : DalBase<FornecedorDto>, IFornecedorDal
    {
        public override FornecedorDto Get(int id)
        {
            base.ConexaoBase.CommandText = "ConsultarFornecedorPorIdFornecedor";
            return base.ConexaoBase.GetById(id);
        }

        public override IEnumerable<FornecedorDto> Get()
        {
            base.ConexaoBase.CommandText = "ConsultarFornecedores";
            return base.ConexaoBase.GetAll();
        }

        public override void Add(FornecedorDto dto)
        {
            base.ConexaoBase.CommandText = "AdicionarFornecedor";
            base.ConexaoBase.Add(dto);
        }

        public override void Update(FornecedorDto dto)
        {
            base.ConexaoBase.CommandText = "AtualizarFornecedorPorIdFornecedor";
            base.ConexaoBase.Update(dto);
        }

        public override void Delete(int id)
        {
            base.ConexaoBase.CommandText = "ExcluirFornecedorPorIdFornecedor";
            base.ConexaoBase.Delete(id);
        }
    }
}
