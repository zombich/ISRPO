// Исходный код приложения для рефакторинга.
// Рефакторинг зафиксировать в текстовом документе со столбцами 
// Задание | Исходный код | Код после рефакторинга
// Разнести типы данных по разным файлам.

using Microsoft.EntityFrameworkCore;

namespace OrderManagementApp
{
    // Сервис для работы с заказами
    public class OrderService
    {
        private readonly AppDbContext _dbContext;

        public OrderService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void PrintOrderDetails(int orderId)
        {
            var order = _dbContext.Orders.Include(o => o.Customer).FirstOrDefault(o => o.Id == orderId);
            PrintOrderId(order);
            PrintTotal(order);
            PrintExpressShipping(order);
            order.Customer.PrintEmail();
        }

        private static void PrintExpressShipping(Order? order) =>
            Console.WriteLine("Express Shipping: " + (order.IsExpress ? "Yes" : "No"));

        private static void PrintTotal(Order? order) =>
            Console.WriteLine("Total: " + order.Total);

        private static void PrintOrderId(Order? order) =>
            Console.WriteLine("Order Id: " + order.Id);

        public double CalculateFinalPrice(Order order)
        {
            double tax = 0.2; // НДС
                            // скидка 10% при заказе от 10000
            
            double discountPercent = 0.1;

            int discountThreshold = 10000;

            double discount = order.Total > discountThreshold ? order.Total * discountPercent : 0;

            // итоговая цена
            return order.Total - discount + (order.Total * tax);
        }
    }
}
