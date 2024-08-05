using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TWLDotNetCore.PizzaOrder.Models
{
    [Table("Tbl_PizzaExtra")]
    public class PizzaExtraModel
    {
        [Key]
        public int PizzaExtraId { get; set; }
        public string PizzaExtraName { get; set; }
        public decimal Price { get; set; }

        [NotMapped]
        public string PriceStr { get { return "$" + Price; } }

    }
}
