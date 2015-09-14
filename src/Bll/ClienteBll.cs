using NetCoders.MicroErp.Bll.Base;
using NetCoders.MicroErp.Bll.Exceptions;
using NetCoders.MicroErp.Common.Dto;
using NetCoders.MicroErp.Common.Interfaces.Bll;
using NetCoders.MicroErp.Common.Interfaces.Dal;
using NetCoders.MicroErp.Dal;
using System.Collections.Generic;

namespace NetCoders.MicroErp.Bll
{
    public sealed class ClienteBll : BllBase<ClienteDto>, IClienteBll
    {
        private IClienteDal _clienteDal;

        public ClienteBll()
        {
            this._clienteDal = new ClienteDal();
        }

        public void ValidarNome(ClienteDto cliente)
        {
            base.ValidaNull(cliente);

            if (string.IsNullOrWhiteSpace(cliente.Nome))
            {
                throw new ClienteException("O nome do cliente não pode estar em branco!");
            }
        }

        public override void Adicionar(ClienteDto dto)
        {
            this.ValidarNome(dto);
            if (dto.IdCliente > 0)
            {
                throw new ClienteException(string.Format("O cliente {0} já existe!", dto.Nome));
            }
            _clienteDal.Add(dto);
        }

        public override void Atualizar(ClienteDto dto)
        {
            this.ValidarNome(dto);
            base.ValidarId(dto.IdCliente);
            _clienteDal.Update(dto);
        }

        public override IEnumerable<ClienteDto> Consultar()
        {
            return _clienteDal.Get();
        }

        public override ClienteDto Consultar(int id)
        {
            return _clienteDal.Get(id);
        }

        public override void Excluir(int id)
        {
            _clienteDal.Delete(id);
        }

    }
}
