using System.Data;
using tokoharu.Models;
using TokoHaru.Repositories;

namespace TokoHaru.Controllers
{
    public class OrderController
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(DBConnection dbConnection)
        {
            _orderRepository = new OrderRepository(dbConnection);
        }

        public DataTable GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public bool AddOrder(string customerName, string menu, string price)
        {
            return _orderRepository.AddOrder(customerName, menu, price);
        }

        public bool UpdateOrder(int orderId, string customerName, string menu, string price)
        {
            return _orderRepository.UpdateOrder(orderId, customerName, menu, price);
        }

        public bool DeleteOrder(int orderId)
        {
            return _orderRepository.DeleteOrder(orderId);
        }
    }
}