using NetCoders.MicroErp.Common.Dto;
using NetCoders.MicroErp.Common.Dto.Relatorios;
using NetCoders.MicroErp.Common.Factories;
using NetCoders.MicroErp.Common.Interfaces.Dal;
using NetCoders.MicroErp.Dal.Base;
using System.Collections.Generic;
using System.Data;

namespace NetCoders.MicroErp.Dal
{
    public sealed class CompraDal : DalBase<CompraDto>, ICompraDal
    {
        public override CompraDto Get(int id)
        {
            base.ConexaoBase.CommandText = "ConsultarCompraPorIdCompra";
            //base.ConexaoBase.AddParamId(id);
            //return ConexaoBase.GetById(id);
            return base.ConexaoBase.Get(CompraFactory.MetodoComum, id);
        }

        public override IEnumerable<CompraDto> Get()
        {
            base.ConexaoBase.CommandText = "ConsultarCompras";
            return ConexaoBase.GetAll(CompraFactory.MetodoComum);
        }

        public override void Add(CompraDto dto)
        {
            base.ConexaoBase.CommandText = "AdicionarCompra";
            base.ConexaoBase.Add(dto);
        }

        public override void Update(CompraDto dto)
        {
            base.ConexaoBase.CommandText = "AtualizarCompraPorIdCompra";
            base.ConexaoBase.Update(dto: dto);
        }

        public override void Delete(int id)
        {
            base.ConexaoBase.CommandText = "ExcluirCompraPorIdCompra";
            base.ConexaoBase.Delete(id);
        }

        public IEnumerable<RelatorioDeCompraPorFornecedorDto> RelatorioCompraPorFornecedor(int idFornecedor)
        {
            base.ConexaoBase.CommandText = "RelatorioCompraPorIdFornecedor";
            base.ConexaoBase.AddWithValue("@IdFornecedor", idFornecedor, DbType.Int32);
            // Jeito 1º
            //return ConexaoBase.GetAll<RelatorioDeCompraPorFornecedorDto>();

            // Jeito 2º
            //// O x da Lambda da linha abaixo, representa o 1º pârametro da Func (Func<IDataRecord, T> make) o IDataRecord e o 
            //// RelatorioDeCompraPorFornecedorFactory.Create é o método estático que cria a lista de objetos de RelatorioDeCompraPorFornecedorDto
            //// passando um DataRecord.
            // return base.ConexaoBase.GetAll(x => RelatorioDeCompraPorFornecedorFactory.Create(x));

            // Jeito 3º
            return base.ConexaoBase.GetAll(RelatorioDeCompraPorFornecedorFactory.CreateDelegate);
        }

        public CompraDto ConsultarComFornecedor(int idCompra)
        {
            base.ConexaoBase.CommandText = "";
            return base.ConexaoBase.Get(x => CompraFactory.CreateComFornecedor(x, idCompra), idCompra);
        }
    }
}
