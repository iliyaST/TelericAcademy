
namespace BankAccounts
{
    using System;

    /// <summary>
    /// Represents mortgage bank account.
    /// </summary>
    public class MortageAccount : Account
    {
        /// <summary>
        /// Initializes new instance of MortageAccount class identified by it's owner, balance and monthly based interest rate.
        /// </summary>
        /// <param name="customer">Account's owner.</param>
        /// <param name="balance">Account balance.</param>
        /// <param name="interestRate">Monlty based interest rate of the account.</param>
        public MortageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        /// <summary>
        /// Calculates interest for a given period.
        /// </summary>
        /// <param name="months">Period of the interest in months.</param>
        /// <returns>Interest for the given period.</returns>
        public override decimal CalculateInterest(int months)
        {
            // Period validation
            if (months <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid month count.");
            }

            // Mortgage account specific cases
            if (this.Customer.Type == CustomerType.Company && months <= 12)
            {
                return base.CalculateInterest(months) / 2;
            }

            if (this.Customer.Type == CustomerType.Individual && months <= 6)
            {
                return 0;
            }

            // Common case
            return base.CalculateInterest(months);
        }
    }
}
