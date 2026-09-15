using System.Threading.Channels;

namespace OrderManagementApp
{
    // Класс Customer (клиент)
    public class Customer
    {
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get => name;

            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
            }
        }
        public string Email;
        public List<Order> Orders { get; set; }

        public void PrintEmail() => Console.WriteLine($"Customer Email: {Email}");
    }
}
