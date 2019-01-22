using System;
using System.Collections.Generic;
using System.Text;

namespace KeepHome.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }

        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
