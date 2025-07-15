using Microsoft.Extensions.Diagnostics.HealthChecks;
using SampleBlazor.Data;

namespace SampleBlazor.Utility
{
    public static class SD
    {
        public static string Role_Admin = "Admin";
        public static string Role_Customer = "Customer";

        public static string StatusPending = "Pending";
        public static string StatusReadyForPickUp = "ReadyForPickUp";
        public static string StatusCompleted = "Completed";
        public static string StatusCancelled = "Cancelled";

        public static List<OrderDetail> ConvertShoppingCartListToOrderDetail(List<ShoppingCart> cartList)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (ShoppingCart cart in cartList)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    ProductId = cart.ProductId,
                    Count = cart.Count,
                    Price = Convert.ToDouble(cart.Product.Price),
                    ProductName = cart.Product.Name,
                };
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }
    }
}
