using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_MVVM.Model
{
    public enum PaymentStatus
    {
        Pending,
        Paid
    }

    public enum OrderStatus
    {
        Pending,
        Approved,
        Shipped,
        Delivered,
        Cancelled
    }

    public class Order : IPayment
    {

        public int Id { get; set; }
        public int customer_id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<Items> OrdersItemsByCustomer { get; set;  }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        public Order( )
        {
        }
        public bool ProcessPayment() // modify by the customer
        {
            PaymentStatus = PaymentStatus.Paid;
            return true;
        }

    }
}
