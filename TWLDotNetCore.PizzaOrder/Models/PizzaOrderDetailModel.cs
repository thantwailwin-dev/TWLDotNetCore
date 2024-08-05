using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TWLDotNetCore.PizzaOrder.Models
{
    [Table("Tbl_PizzaOrderDetail")]
    public class PizzaOrderDetailModel
    {
        [Key]        
        public int PizzaOrderDetailId { get; set; }        
        public string PizzaOrderInvoiceNo { get; set; }        
        public int PizzaExtraId { get; set; }
    }
}
