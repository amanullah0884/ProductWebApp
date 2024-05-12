using System.ComponentModel.DataAnnotations;

namespace ProductWebApp.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public double Price { get; set; }

        public int Quentity { get ; set; }

        //public static implicit operator Product(List<Product> v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
