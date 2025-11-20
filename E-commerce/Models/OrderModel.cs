using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public float Total { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public UserDetail? UserDetail { get; set; }
        public ProductModel? Product { get; set; }
    }
}
