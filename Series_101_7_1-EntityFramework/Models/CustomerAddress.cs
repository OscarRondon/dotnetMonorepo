using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDb.Models;

public partial class CustomerAddress
{
    public string FullAddress
    {
        get => $"{Address}, {City}, {State} {ZipCode},  {Country}";
    }
}