using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TWLDotNetCore.PizzaOrder.Db;
using TWLDotNetCore.PizzaOrder.Models;
using TWLDotNetCore.PizzaOrder.Queries;
using TWLDotNetCore.Shared;

namespace TWLDotNetCore.PizzaOrder.Features.PizzaOrder
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaOrderController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly DapperService _dapperService;       

        public PizzaOrderController()
        {
            _appDbContext = new AppDbContext();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        [HttpGet("Pizza")]
        public async Task<IActionResult> GetPizzaAsync()
        {
            var lst = await _appDbContext.Pizzas.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Extra")]
        public async Task<IActionResult> GetExtraAsync()
        {
            var lst = await _appDbContext.Extras.ToListAsync();
            return Ok(lst);
        }

        [HttpPost("Order")]
        public async Task<IActionResult> OrderAsync(OrderRequestDto orDto)
        {
            var p = await _appDbContext.Pizzas.FirstOrDefaultAsync(p => p.PizzaId == orDto.pizzaId);
            var total = p.Price;

            if (orDto.extraId.Length > 0)
            {
                var els = await _appDbContext.Extras.Where(e => orDto.extraId.Contains(e.PizzaExtraId)).ToListAsync();
                /*total = total + els.Sum(e => e.Price);*/
                total += els.Sum(e => e.Price);
            }

            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");

            PizzaOrderModel poModel = new PizzaOrderModel() 
            { 
                PizzaId = orDto.pizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = total,
            };

            List<PizzaOrderDetailModel> podModel = orDto.extraId.Select(eId => new PizzaOrderDetailModel
            {
                PizzaExtraId = eId,
                PizzaOrderInvoiceNo = invoiceNo
            }).ToList();


            await _appDbContext.Orders.AddAsync(poModel);            
            await _appDbContext.OrderDetails.AddRangeAsync(podModel);            
            await _appDbContext.SaveChangesAsync();

            OrderResponseDto responseDto = new OrderResponseDto()
            { 
                message = "Thank you for your order!Enjoy your pizza!",
                invoiceNo = invoiceNo,
                totalAmount = total,
            };

            return Ok(responseDto);
        }

        /*[HttpGet("Order/{invoiceNo}")]
        public async Task<IActionResult> PizzaOrderAsync(string invoiceNo)
        {
            var item = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNo == invoiceNo);
            var lst = await _appDbContext.OrderDetails.Where(x => x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();
            return Ok(new { 
                Order = item,
                OrderDetail = lst
            });
        }*/

        [HttpGet("Order/{invoiceNo}")]
        public IActionResult GetOrder(string invoiceNo)
        {
            var item = _dapperService.QueryFirstOrDefault<OrderInvoiceHeadResponseDto>
                (
                    PizzaQuery.PizzaOrderQuery,
                    new { PizzaOrderInvoiceNo = invoiceNo }
                );

            var lst = _dapperService.Query<OrderInvoiceDetailResponseDto>
                (
                    PizzaQuery.PizzaOrderDetailQuery,
                    new { PizzaOrderInvoiceNo = invoiceNo }
                );

            var model = new OrderInvoiceResponseDto
            {
                Order = item,
                OrderDetail = lst
            };

            return Ok(model);
        }
    }
}
