using NetCoders.MicroErp.Bll;
using NetCoders.MicroErp.Common.Dto;
using NetCoders.MicroErp.Common.Interfaces.Bll;
using NetCoders.MicroErp.UI.Mvc.Models;
using System.Linq;
using System.Web.Mvc;

namespace NetCoders.MicroErp.UI.Mvc.Controllers
{
    public class CompraController : Controller
    {
        private readonly ICompraBll _compraBll;

        public CompraController(ICompraBll compraBll)
        {
            _compraBll = compraBll;
        }

        // GET: Compra
        public ActionResult Index()
        {
            var compras = _compraBll.Consultar();

            //AutoMapper na mão!
            var comprasModel = compras.ToList()
                .ConvertAll(x => new CompraModel()
                {
                    IdCompraModel = x.IdCompra,
                    DataCompra = x.DataCadastro,
                    IdFornecedor = x.Fornecedor.IdFornecedor
                });
            return View(comprasModel);
        }

        // GET: Compra/Details/5
        public ActionResult Details(int id)
        {
            var compra = _compraBll.Consultar(id);
            var compraModel = new CompraModel
            {
                IdCompraModel = compra.IdCompra,
                DataCompra = compra.DataCadastro
            };
            return View(compraModel);
        }

        // GET: Compra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compra/Create
        [HttpPost]
        public ActionResult Create(CompraModel compraModel)
        {
            try
            {
                var compra = new CompraDto
                {
                    Fornecedor = new FornecedorDto { IdFornecedor = compraModel.IdFornecedor },
                    IdCompra = compraModel.IdCompraModel,
                    DataCadastro = compraModel.DataCompra
                };

                _compraBll.Adicionar(compra);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/Edit/5
        public ActionResult Edit(int id)
        {
            var compra = _compraBll.Consultar(id);
            var compraModel = new CompraModel
            {
                IdCompraModel = compra.IdCompra,
                IdFornecedor = compra.Fornecedor.IdFornecedor,
                DataCompra = compra.DataCadastro
            };
            return View(compraModel);
        }

        // POST: Compra/Edit/5
        [HttpPost]
        public ActionResult Edit(CompraModel compraModel)
        {
            try
            {
                var compraDto = new CompraDto
                {
                    Fornecedor = new FornecedorDto
                    {
                        IdFornecedor = compraModel.IdFornecedor
                    },
                    IdCompra = compraModel.IdCompraModel
                };
                _compraBll.Atualizar(compraDto);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/Delete/5
        public ActionResult Delete(int id)
        {
            var compra = _compraBll.Consultar(id);
            var compraModel = new CompraModel
            {
                IdCompraModel = compra.IdCompra,
                IdFornecedor = compra.Fornecedor.IdFornecedor,
                DataCompra = compra.DataCadastro
            };
            return View(compraModel);
        }

        // POST: Compra/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmado(int id)
        {
            try
            {
                _compraBll.Excluir(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
