using System.ComponentModel.DataAnnotations.Schema;

namespace Series_101_7_0_EntityFramework.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}