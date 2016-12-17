
namespace BankAccounts
{
    /// <summary>
    /// Defines a method for account deposit.
    /// </summary>
    public interface IDepositable
    {
        void Deposit(decimal amount);
    }
}
