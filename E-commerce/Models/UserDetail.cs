using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace E_commerce.Models
{
    public class UserDetail
    {
        [Key]
        public int UserId { get; set; } 
        public string Name { get; set; } = string.Empty;    
        public DateOnly DOB { get; set; }

        public string Phone { get; set; } = string.Empty;
        public int CredentialId { get; set; }
        public UserCredential? Credential { get; set; } = null;
        public ICollection<OrderModel> Orders = new List<OrderModel>();
    }
}
