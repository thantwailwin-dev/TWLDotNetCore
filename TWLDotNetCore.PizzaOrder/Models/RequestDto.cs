namespace TWLDotNetCore.PizzaOrder.Models
{
    public class OrderRequestDto
    {
        public int pizzaId { get; set; }
        public int[] extraId { get; set; }
    }    

}
