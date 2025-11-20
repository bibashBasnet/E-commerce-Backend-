using E_commerce.Dtos.OrderDto;

namespace E_commerce.Services.Interface
{
    public interface IOrderService
    {
        public Task<IEnumerable<ReadDto>?> GetAllOrdersAsync();
        public Task<ReadDto?> GetOrderByIdAsync(int id);
        public Task<OrderDto> CreateOrderAsync(OrderDto product);
        public Task<OrderDto?> DeleteOrderAsync(int id);
        public Task<OrderDto?> UpdateOrderAsync(int id, UpdateDto order);

    }
}
