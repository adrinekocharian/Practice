using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }


        public override string ToString()
        {
            return $"{Id}\t\t{Name}\t\t\t{Price}\t\t{Quantity}\t\t{Category}";
        }
    }
}
