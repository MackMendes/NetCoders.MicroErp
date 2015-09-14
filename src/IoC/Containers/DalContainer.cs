using NetCoders.MicroErp.Common.Interfaces.Dal;
using NetCoders.MicroErp.Dal;
using SimpleInjector;

namespace NetCoders.MicroErp.IoC.Containers
{
    public static class DalContainer
    {
        public static void Register(Container container, Lifestyle lifestyle)
        {
            //container.RegisterAll<IConexao<T>>(Conexao<T>)>(lifestyle);
            container.Register<ICompraDal, CompraDal>(lifestyle);
            container.Register<ICompraItemDal, CompraItemDal>(lifestyle);
            container.Register<IClienteDal, ClienteDal>(lifestyle);
            container.Register<IFornecedorDal, FornecedorDal>(lifestyle);
        }

    }
}
