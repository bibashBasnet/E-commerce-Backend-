using E_commerce.Context;
using E_commerce.Dtos.OrderDto;
using E_commerce.Models;
using E_commerce.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace E_commerce.Services.Service
{
    public class OrderService(ECommerceContext _context): IOrderService
    {
        public async Task<IEnumerable<ReadDto>?> GetAllOrdersAsync()
        {
            var orders = await _context.orders
                .Include(u => u.Product)
                .Include(u => u.UserDetail)
                .ToListAsync();
            if (orders is null)
                return null;
            return orders.Select(o => new ReadDto
            {
                OrderId = o.OrderId,
                ProductName = o.Product!.ProductName,
                ProductPrice = o.Product!.ProductPrice,
                Quantity = o.Quantity,
                Total = o.Total,
                Name = o.UserDetail!.Name,
                Phone = o.UserDetail!.Phone,
            });
        }

        public async Task<ReadDto?> GetOrderByIdAsync(int id)
        {
            var order = await _context.orders
                .Include (u => u.Product)
                .Include(u => u.UserDetail)
                .FirstOrDefaultAsync(u =>  u.OrderId == id);
            if (order is null)
                return null;
            return new ReadDto
            {
                OrderId = order.OrderId,
                ProductName = order.Product!.ProductName,
                ProductPrice = order.Product!.ProductPrice,
                Quantity = order.Quantity,
                Total = order.Total,
                Name = order.UserDetail!.Name,
                Phone = order.UserDetail!.Phone,
            };
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto order)
        {
            var newOrder = new OrderModel
            {
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                Total = order.Total,
                UserId = order.UserId
            };
            await _context.orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return new OrderDto
            {
                OrderId = newOrder.OrderId,
                ProductId = newOrder.ProductId,
                Quantity = newOrder.Quantity,
                Total = newOrder.Total,
                UserId = newOrder.UserId
            };
        }

        public async Task<OrderDto?> DeleteOrderAsync(int id) 
        {
            Console.WriteLine($"The id in service {id}");
            var order = await _context.orders.FindAsync(id);
            Console.WriteLine("This is service" + JsonSerializer.Serialize(order));
            if (order == null)
                return null;
            var deleteOrder = new OrderDto
            {
                OrderId = order.OrderId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                Total = order.Total,
                UserId = order.UserId
            };
            _context.orders.Remove(order);
            await _context.SaveChangesAsync();
            return deleteOrder;
        }

        public async Task<OrderDto?> UpdateOrderAsync(int id, UpdateDto updateOrder)
        {
            var order = await _context.orders.FindAsync(id);
            if (order is null)
                return null;
            order.Quantity = updateOrder.Quantity;
            order.Total = updateOrder.Total;
            await _context.SaveChangesAsync();
            return new OrderDto
            {
                OrderId = order.OrderId,
                ProductId = order.ProductId,
                UserId = order.UserId,
                Quantity = order.Quantity,
                Total = order.Total
            };
        }
    }
}
