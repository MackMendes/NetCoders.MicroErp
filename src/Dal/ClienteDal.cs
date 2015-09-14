using NetCoders.MicroErp.Common.Dto;
using NetCoders.MicroErp.Common.Interfaces.Dal;
using NetCoders.MicroErp.Dal.Base;
using System;
using System.Collections.Generic;

namespace NetCoders.MicroErp.Dal
{
    public class ClienteDal : DalBase<ClienteDto>, IClienteDal
    {
        public override ClienteDto Get(int id)
        {
            base.ConexaoBase.CommandText = "ConsultarClientePorId";
            return base.ConexaoBase.GetById(id);
        }

        public override IEnumerable<ClienteDto> Get()
        {
            base.ConexaoBase.CommandText = "ConsultarClientes";
            return base.ConexaoBase.GetAll();
        }

        public override void Add(ClienteDto dto)
        {
            base.ConexaoBase.CommandText = "AdicionarCliente";
            base.ConexaoBase.Add(dto);
        }

        public override void Update(ClienteDto dto)
        {
            base.ConexaoBase.CommandText = "AtualizarClientePorIdCliente";
            base.ConexaoBase.Update(dto);
        }

        public override void Delete(int id)
        {
            base.ConexaoBase.CommandText = "ExcluirClientePorIdCliente";
            base.ConexaoBase.Delete(id);
        }
    }
}
