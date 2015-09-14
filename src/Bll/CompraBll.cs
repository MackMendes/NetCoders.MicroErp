using NetCoders.MicroErp.Bll.Base;
using NetCoders.MicroErp.Bll.Exceptions;
using NetCoders.MicroErp.Common.Dto;
using NetCoders.MicroErp.Common.Dto.Relatorios;
using NetCoders.MicroErp.Common.Interfaces.Bll;
using NetCoders.MicroErp.Common.Interfaces.Dal;
using System.Collections.Generic;
using System.Linq;

namespace NetCoders.MicroErp.Bll
{
    public sealed class CompraBll : BllBase<CompraDto>, ICompraBll
    {
        private ICompraDal _compraDal;
        private ICompraItemDal _compraItemDal;

        public CompraBll(ICompraDal compraDal, ICompraItemDal compraItemDal)
        {
            if (compraDal == null)
            {
                throw new CompraException("CompraDal não pode ser nulo!");
            }

            if (compraItemDal == null)
            {
                throw new CompraException("CompraItemDal não pode ser nulo!");
            }

            _compraDal = compraDal;
            _compraItemDal = compraItemDal;
        }

        public override CompraDto Consultar(int id)
        {
            base.ValidarId(id);
            var compra = _compraDal.Get(id);
            compra.Itens = _compraItemDal.GetByIdCompra(id);
            return compra;
        }

        /// <summary>
        /// No cenário atual, é inviavel implmenetar uma consulta sem WHERE... então, não será implementado!
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<CompraDto> Consultar()
        {
            //throw new CompraException("Esse modo de consulta não é permitido!");
            return _compraDal.Get();
        }

        public override void Atualizar(CompraDto dto)
        {
            base.ValidarId(dto.IdCompra);
            ValidarItensExistentes(dto);

            // Salva os itens da compra
            foreach (var itemDto in dto.Itens)
            {
                _compraItemDal.Update(itemDto);
            }

            // Salva os dados da compra
            _compraDal.Update(dto);
        }

        public void ValidarItensExistentes(CompraDto dto)
        {
            if (!dto.Itens.Any())
            {
                throw new CompraException("A compra não têm itens!");
            }
        }

        public override void Adicionar(CompraDto dto)
        {
            this.ValidarItensExistentes(dto);
            _compraDal.Add(dto);

            foreach (var compraItensDto in dto.Itens)
            {
                _compraItemDal.Add(compraItensDto);
            }
        }

        public override void Excluir(int id)
        {
            base.ValidarId(id);

            // Excluir os itens da compra
            _compraItemDal.DeleteByIdCompra(id);
            // Excluir a compra
            _compraDal.Delete(id);
        }

        public IEnumerable<RelatorioDeCompraPorFornecedorDto> RelatorioCompraPorFornecedor(int idFornecedor)
        {
            return _compraDal.RelatorioCompraPorFornecedor(idFornecedor);
        }

        public CompraDto ConsultarCompraComItens(int idCompra)
        {
            var compra = _compraDal.Get(idCompra);
            compra.Itens = _compraItemDal.GetByIdCompra(idCompra);
            return compra;
        }

        /*
        void Teste()
        {
            // 1º Forma que foi feita
            // Quando a gente coloco (=>) estavamos falando que o retorno é um new CompraDto() 
            //_compraDal.Get(x => new CompraDto()
            //{
            //    DataCadastro = (DateTime)x["DataCadastro"],
            //    Fornecedor = new FornecedorDto { IdFornecedor = (int)x["IdFornecedor"] },
            //    IdCompra = (int)x["IdCompra"],
            //    Itens = new List<CompraItemDto>()
            //}, 1);

            _compraDal.Get(ExemploDelegateNomeado, 1);

        }

        CompraDto ExemploDelegateNomeado(IDataRecord x)
        {
            return new CompraDto()
            {
                DataCadastro = (DateTime)x["DataCadastro"],
                Fornecedor = new FornecedorDto { IdFornecedor = (int)x["IdFornecedor"] },
                IdCompra = (int)x["IdCompra"],
                Itens = new List<CompraItemDto>()
            };
        }
         * 
         * */
    }
}
