
namespace BankAccounts
{
    public interface IWithdrawable
    {
        /// <summary>
        /// Defines a method for withdraw from an account.
        /// </summary>       
        void Withdraw(decimal amount);
    }
}
