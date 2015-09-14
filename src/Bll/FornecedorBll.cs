using NetCoders.MicroErp.Bll.Base;
using NetCoders.MicroErp.Bll.Exceptions;
using NetCoders.MicroErp.Common.Dto;
using NetCoders.MicroErp.Common.Interfaces.Bll;
using NetCoders.MicroErp.Common.Interfaces.Dal;
using NetCoders.MicroErp.Dal;
using System.Collections.Generic;

namespace NetCoders.MicroErp.Bll
{
    public class FornecedorBll : BllBase<FornecedorDto>, IFornecedorBll
    {
        private IFornecedorDal _fornecedor;

        public FornecedorBll()
        {
            _fornecedor = new FornecedorDal();
        }

        public void ValidarNome(FornecedorDto fornecedor)
        {
            base.ValidaNull(fornecedor);

            if (string.IsNullOrWhiteSpace(fornecedor.Nome))
            {
                throw new FornecedorException("O nome do fornecedor não pode estar em branco!");
            }
        }

        public override FornecedorDto Consultar(int id)
        {
            return _fornecedor.Get(id);
        }

        public override IEnumerable<FornecedorDto> Consultar()
        {
            return _fornecedor.Get();
        }

        public override void Atualizar(FornecedorDto dto)
        {
            this.ValidarNome(dto);
            base.ValidarId(dto.IdFornecedor);
            _fornecedor.Add(dto);
        }

        public override void Adicionar(FornecedorDto dto)
        {
            this.ValidarNome(dto);
            if (dto.IdFornecedor > 0)
            {
                throw new FornecedorException(string.Format("O fornecedor {0} já existe!", dto.Nome));
            }
            _fornecedor.Add(dto);
        }

        public override void Excluir(int id)
        {
            _fornecedor.Delete(id);
        }

    }
}
