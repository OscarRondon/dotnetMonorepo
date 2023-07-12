using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PizzaDb.Models;

[Table("OrderDetail")]
[Index("OrderId", Name = "IX_OrderDetail_OrderId")]
[Index("ProductId", Name = "IX_OrderDetail_ProductId")]
public partial class OrderDetail
{
    [Key]
    public int Id { get; set; }

    public int Quantity { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetails")]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("OrderDetails")]
    public virtual Product Product { get; set; } = null!;
}
