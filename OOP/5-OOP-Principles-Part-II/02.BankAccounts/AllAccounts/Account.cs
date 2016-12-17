
namespace BankAccounts
{
    using System;

    /// <summary>
    /// Represent abstract model of bank account.
    /// </summary>
    public abstract class Account : IDepositable
    {
        /// <summary>
        /// Initialize base properties of the bank account. Used only by derived classes.
        /// </summary>
        /// <param name="customer">Account owner.</param>
        /// <param name="balance">Account balance.</param>
        /// <param name="interestRate">Monthly interest rate of the account.</param>
        protected Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        /// <summary>
        /// Gets owner of the bank account.
        /// </summary>
        public Customer Customer { get; private set; }

        /// <summary>
        /// Gets account balance.
        /// </summary>
        public decimal Balance { get; protected set; }

        /// <summary>
        /// Gets monthly interest rate of the account.
        /// </summary>
        public decimal InterestRate { get; private set; }

        /// <summary>
        /// Common case of interest calculation.
        /// </summary>
        /// <param name="months">Interest period in months.</param>
        /// <returns>Interest for given period.</returns>
        public virtual decimal CalculateInterest(int months)
        {
            return this.InterestRate * months * this.Balance;
        }

        /// <summary>
        /// Deposits funds into the account balance.
        /// </summary>
        /// <param name="amount"></param>
        public void Deposit(decimal amount)
        {
            if (amount <= 0 )
            {
                throw new ArgumentException("Invalid deposit amount!");
            }

            this.Balance += amount;
        }
    }
}
