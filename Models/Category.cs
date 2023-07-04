using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_app_api.Models
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Product>? Products { get; set; }

    }
}
