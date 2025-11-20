namespace E_commerce.Dtos.ProductDto
{
    public class ProductDto
    {
        public int ProductId { get; set; } 
        public string ProductName { get; set; } = string.Empty;
        public float ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}
