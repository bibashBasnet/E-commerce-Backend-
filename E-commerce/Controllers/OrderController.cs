using E_commerce.Dtos.OrderDto;
using E_commerce.Services.Interface;
using E_commerce.Utiltiy;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpGet("getAllOrders")]
        public async Task<ActionResult<ReadDto>> GetAllOrder()
        {
            try
            {
                var orders = await orderService.GetAllOrdersAsync();
                if (orders == null)
                {
                    return BadRequest(new ErrorResponse<string>("Something went wrong."));
                }
                return Ok(new SuccessResponse<IEnumerable<ReadDto>>(orders, "Order list retrieved successfully."));
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse<string>("Something went wrong."));
            }
        }

        [HttpGet("getOrderById/{id}")]
        public async Task<ActionResult<ReadDto>> GetOrderbyId(int id)
        {
            try
            {
                var order = await orderService.GetOrderByIdAsync(id);
                if (order == null)
                    return NotFound(new ErrorResponse<string>("Order not found."));
                return Ok(new SuccessResponse<ReadDto>(order, "Order retrieved successfully."));
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse<string>("Something went wrong."));
            }
        }

        [HttpPost("createOrder")]
        public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto order)
        {
            try
            {
                var createdOrder = await orderService.CreateOrderAsync(order);
                if (createdOrder is null)
                    return BadRequest(new ErrorResponse<string>("Something went wrong."));
                return Ok(new SuccessResponse<OrderDto>(createdOrder, "Order created successfully."));
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse<string>("Something went wrong."));
            }
        }

        [HttpDelete("deleteOrder/{id}")]
        public async Task<ActionResult<ReadDto>> DeleteOrder(int id)
        {
            Console.WriteLine($"This is from controller id = {id}");
            try
            {
                var deletedOrder = await orderService.DeleteOrderAsync(id);
                Console.WriteLine(JsonSerializer.Serialize(deletedOrder));
                if (deletedOrder is null)
                    return BadRequest(new ErrorResponse<string>("Something went wrong."));
                return Ok(new SuccessResponse<OrderDto>(deletedOrder, "Order deleted successfully."));
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse<string>("Something went wrong."));
            }
        }

        [HttpPut("updateOrder/{id}")]
        public async Task<ActionResult<OrderDto>> UpdateOrder(int id, UpdateDto updateOrder)
        {
            try
            {
                var order = await orderService.UpdateOrderAsync(id, updateOrder);
                if (order is null)
                    return BadRequest(new ErrorResponse<string>("Something went wrong."));
                return Ok(new SuccessResponse<OrderDto>(order, "Order updated successfully."));
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse<string>("Something went wrong."));
            }
        }
    }
}
