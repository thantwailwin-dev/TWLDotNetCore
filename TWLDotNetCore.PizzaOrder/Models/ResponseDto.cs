namespace TWLDotNetCore.PizzaOrder.Models
{
    public class OrderResponseDto
    {
        public string message { get; set; }
        public string invoiceNo { get; set; }
        public decimal totalAmount { get; set; }
    }

    public class OrderInvoiceHeadResponseDto
    {
        public int PizzaOrderId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Pizza { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderInvoiceDetailResponseDto
    {
        public int PizzaOrderDetailId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaExtraId { get; set; }
        public string PizzaExtraName { get; set; }
        public decimal Price { get; set; }

    }

    public class OrderInvoiceResponseDto
    {
        public OrderInvoiceHeadResponseDto Order { get; set; }
        public List<OrderInvoiceDetailResponseDto> OrderDetail { get; set; }
    }
}
