namespace TWLDotNetCore.PizzaOrder.Queries
{
    public class PizzaQuery
    {
        public static string PizzaOrderQuery { get; } = 
                        @"select pzor.*,pz.Pizza,pz.Price from [dbo].[Tbl_PizzaOrder] pzor 
                        inner join [dbo].[Tbl_Pizza] pz on pzor.PizzaId = pz.PizzaId 
                        where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo";

        public static string PizzaOrderDetailQuery { get; } = 
                        @"select pzord.*,pze.PizzaExtraName,pze.Price from [dbo].[Tbl_PizzaOrderDetail] pzord 
                        inner join [dbo].[Tbl_PizzaExtra] pze on pzord.PizzaExtraId = pze.PizzaExtraId 
                        where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo";
    }
}
