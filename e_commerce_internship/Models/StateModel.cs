using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce_internship.Models
{
    public class StateModel
    {
        public int ProductNumber { get; set; }
        public int OrderNumber { get; set; }
        public int PendingOrderNumber { get; set; }
        public int ConfirmedOrderNumber { get; set; }
        public int PackedOrderNumber { get; set; }
        public int ShippedOrderNumber { get; set; }
    }
}