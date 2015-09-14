using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoders.MicroErp.UI.Mvc.Models
{
    public class CompraModel
    {
        [Key]
        public int IdCompraModel { get; set; }

        public int IdFornecedor { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataCompra { get; set; }
    }
}