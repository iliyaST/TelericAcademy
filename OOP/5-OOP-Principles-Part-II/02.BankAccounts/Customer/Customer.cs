
namespace BankAccounts
{
    /// <summary>
    /// Represents a bank customer and account holder.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Initializes new instance of Customer class identified by name and customer type.
        /// </summary>
        /// <param name="name">Customer's name</param>
        /// <param name="customerType">Customer's type.</param>
        public Customer(string name, CustomerType customerType)
        {
            this.Name = name;
            this.Type = customerType;
        }

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets customer type.
        /// </summary>
        public CustomerType Type { get; private set; }

    }
}
