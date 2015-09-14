using NetCoders.MicroErp.Bll;
using NetCoders.MicroErp.Common.Interfaces.Bll;
using SimpleInjector;

namespace NetCoders.MicroErp.IoC.Containers
{
    public static class BllContainer
    {

        public static void Register(Container container, Lifestyle lifestyle)
        {
            container.Register<ICompraBll, CompraBll>(lifestyle);
            container.Register<IClienteBll, ClienteBll>(lifestyle);
            container.Register<IFornecedorBll, FornecedorBll>(lifestyle);
        }
    }
}
