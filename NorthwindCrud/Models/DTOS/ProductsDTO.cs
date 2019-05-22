using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindCrud.Models.DTOS
{
    public class ProductsDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public string QuanittyPer { get; set; }
        public bool Discontined { get; set; }

    }
}