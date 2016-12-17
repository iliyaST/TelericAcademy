using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    /// <summary>
    /// Represents deposit bank account.
    /// </summary>
    public class DepositAccount : Account, IWithdrawable
    {
        /// <summary>
        /// Initializes new instance of DepositAccount class identified by it's owner, balance and monthly based interest rate.
        /// </summary>
        /// <param name="customer">Account's owner.</param>
        /// <param name="balance">Account balance.</param>
        /// <param name="interestRate">Monlty based interest rate of the account.</param>
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        /// <summary>
        /// Withdraws funds from account.
        /// </summary>
        /// <param name="amount">Amount to be withdrawed.</param>
        public void Withdraw(decimal amount)
        {
            // Validation
            if (amount <= 0)
            {
                throw new ArgumentException("Invalid withdraw amount");
            }
            if (this.Balance < amount)
            {
                throw new ApplicationException("Insufficient funds.");
            }

            // Withdraw amount.
            this.Balance -= amount;
        }

        /// <summary>
        /// Calculates interest for a given period.
        /// </summary>
        /// <param name="months">Period of the interest in months.</param>
        /// <returns>Interest for the given period.</returns>
        public override decimal CalculateInterest(int months)
        {
            // Validation
            if (months <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid month count.");
            }

            // Deposit account specific case
            if (this.Balance < 1000)
            {
                return 0;
            }

            // Common case
            return base.CalculateInterest(months);
        }
    }
}
