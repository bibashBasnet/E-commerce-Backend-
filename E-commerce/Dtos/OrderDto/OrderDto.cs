namespace E_commerce.Dtos.OrderDto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public float Total { get; set; }
        
    }
}
