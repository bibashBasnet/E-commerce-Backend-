namespace E_commerce.Dtos.OrderDto
{
    public class ReadDto
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public float ProductPrice { get; set; }
        public int Quantity { get; set; }
        public float Total { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
