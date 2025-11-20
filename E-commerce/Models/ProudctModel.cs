using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public float ProductPrice { get; set; } 
        public int ProductQuantity { get; set; }
        public ICollection<OrderModel> Orders { get; set; } =  new List<OrderModel>();
    }
}
