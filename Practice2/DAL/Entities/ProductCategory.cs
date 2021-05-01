using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public enum ProductCategory
    {
        Dairy = 1,
        Fruit = 2,
        Sweet = 3
    }

    public class Category
    {
        public int Id { get; set; }
        
        //[Column(TypeName = "nvarchar(10)")]
        public ProductCategory Name { get; set; }
    }

}