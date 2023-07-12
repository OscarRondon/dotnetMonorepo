using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PizzaDb.Models;

[Table("CustomerAddress")]
[Index("CustomerId", Name = "IX_CustomerAddress_CustomerId")]
public partial class CustomerAddress
{
    [Key]
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public string State { get; set; } = null!;

    public string City { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("CustomerAddresses")]
    public virtual Customer Customer { get; set; } = null!;
}
