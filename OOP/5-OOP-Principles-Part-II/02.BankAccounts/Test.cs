
namespace BankAccounts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Test
    {
        public static void Main()
        {
            List<Account> bankAccounts = new List<Account>()
            {
                new LoanAccount(new Customer("Gosho", CustomerType.Individual), 267M, 0.02M),
                new DepositAccount(new Customer("Dreamworld Ltd.", CustomerType.Company), 5438.32M, 0.028M),
                new MortageAccount(new Customer("Pesho", CustomerType.Individual), 15345.23M, 0.01M),
            };

            DepositAccount someAccountOther = new DepositAccount(new Customer("BatBoikosCompany", CustomerType.Company), 2011111M, 0.9M);
            someAccountOther.Withdraw(300000M);
            LoanAccount someAccount = new LoanAccount(new Customer("BatBoiko", CustomerType.Individual), 201M,0.1M);
            someAccount.Deposit(300000M);

            bankAccounts.Add(someAccountOther);
            bankAccounts.Add(someAccount);
            // Calculate interest of the accounts
            foreach (var account in bankAccounts)
            {
                Console.WriteLine("Bank account with owner {0} has yearly interest of {1:C}", account.Customer.Name, account.CalculateInterest(6));
            }
        }
    }
}
