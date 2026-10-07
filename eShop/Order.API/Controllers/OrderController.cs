using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Services;

namespace OrderMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();

            return Ok(orders);
        }

        [HttpPost("SaveOrder")]
        public IActionResult SaveOrder(
     [FromBody] OrderMicroservice.ApplicationCore.Entities.Order order)
        {
            order.Order_Date = DateTime.Now;
            order.Order_Status = "Pending";

            _orderService.CreateOrder(order);

            return Ok(new
            {
                order.Id,
                order.Order_Date,
                order.CustomerId,
                order.CustomerName,
                order.PaymentMethodId,
                order.PaymentName,
                order.ShippingAddress,
                order.ShippingMethod,
                order.BillAmount,
                order.Order_Status,
                OrderDetails = order.OrderDetails.Select(d => new
                {
                    d.Id,
                    d.Order_Id,
                    d.Product_Id,
                    d.Product_name,
                    d.Qty,
                    d.Price,
                    d.Discount
                })
            });
        }

        [HttpGet("CheckOrderHistory")]
        public IActionResult CheckOrderHistory(int customerId)
        {
            var orders = _orderService.GetOrdersByCustomerId(customerId);

            var result = orders.Select(order => new
            {
                order.Id,
                order.Order_Date,
                order.CustomerId,
                order.CustomerName,
                order.PaymentMethodId,
                order.PaymentName,
                order.ShippingAddress,
                order.ShippingMethod,
                order.BillAmount,
                order.Order_Status,

                OrderDetails = order.OrderDetails.Select(detail => new
                {
                    detail.Id,
                    detail.Order_Id,
                    detail.Product_Id,
                    detail.Product_name,
                    detail.Qty,
                    detail.Price,
                    detail.Discount
                })
            });

            return Ok(result);
        }

        [HttpGet("CheckOrderStatus")]
        public IActionResult CheckOrderStatus(int id)
        {
            var order = _orderService.GetOrderById(id);

            if (order == null)
                return NotFound();

            return Ok(order.Order_Status);
        }

        [HttpPut("CancelOrder")]
        public IActionResult CancelOrder(int id)
        {
            var order = _orderService.GetOrderById(id);

            if (order == null)
                return NotFound();

            _orderService.CancelOrder(id);

            return Ok(new
            {
                Message = "Order cancelled successfully."
            });
        }

        [HttpPost("OrderCompleted")]
        public IActionResult OrderCompleted(int id)
        {
            var order = _orderService.GetOrderById(id);

            if (order == null)
                return NotFound();

            order.Order_Status = "Completed";
            _orderService.UpdateOrder(order);

            return Ok(new
            {
                order.Id,
                order.Order_Date,
                order.CustomerId,
                order.CustomerName,
                order.PaymentMethodId,
                order.PaymentName,
                order.ShippingAddress,
                order.ShippingMethod,
                order.BillAmount,
                order.Order_Status,

                OrderDetails = order.OrderDetails.Select(detail => new
                {
                    detail.Id,
                    detail.Order_Id,
                    detail.Product_Id,
                    detail.Product_name,
                    detail.Qty,
                    detail.Price,
                    detail.Discount
                })
            });
        }

        [HttpPut("UpdateOrder")]
        public IActionResult UpdateOrder(
            [FromBody] OrderMicroservice.ApplicationCore.Entities.Order order)
        {
            var existingOrder = _orderService.GetOrderById(order.Id);

            if (existingOrder == null)
                return NotFound();

            _orderService.UpdateOrder(order);

            return Ok(order);
        }
    }
}