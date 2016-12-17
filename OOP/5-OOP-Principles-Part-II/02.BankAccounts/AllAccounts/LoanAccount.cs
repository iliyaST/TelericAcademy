using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    public class LoanAccount : Account
    {
        /// <summary>
        /// Initializes new isntance of loan bank account identified by it's owner, balance and montly based interest rate.
        /// </summary>
        /// <param name="customer">Account's owner.</param>
        /// <param name="balance">Account balance.</param>
        /// <param name="interestRate">Monlty based interest rate of the account.</param>
        public LoanAccount(Customer customer ,decimal balance,decimal interestRate )
           :base (customer,balance,interestRate)
        {

        }

        public override decimal CalculateInterest(int months)
        {
            // Validate period
            if (months <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid month count.");
            }

            // Loan account specific cases
            if (this.Customer.Type == CustomerType.Individual && months <= 3)
            {
                return 0;
            }

            if (this.Customer.Type == CustomerType.Company && months <= 2)
            {
                return 0;
            }

            // Common case
            return base.CalculateInterest(months);
        }
    }
}
