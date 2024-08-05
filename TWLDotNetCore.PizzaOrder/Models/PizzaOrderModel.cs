using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TWLDotNetCore.PizzaOrder.Models
{
    [Table("Tbl_PizzaOrder")] 
    public class PizzaOrderModel
    {
        [Key]        
        public int PizzaOrderId { get; set; }
        
        public string PizzaOrderInvoiceNo { get; set; }
        
        public int PizzaId { get; set; }
        
        public decimal TotalAmount { get; set; }
    }
}
