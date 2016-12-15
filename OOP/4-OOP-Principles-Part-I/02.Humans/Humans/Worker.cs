
namespace Humans
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Worker : Human
    {
        /// <summary>
        /// Initializes new instance of a worker class to a specified firstname, lastname, weeksalary and workhours.
        /// </summary>
        /// <param name="firstName">First name of a worker.</param>
        /// <param name="lastName">Last name of a worker.</param>
        /// <param name="weekSalary">Week salary of a worker.</param>
        /// <param name="workHoursPerDay">Work hours per day.</param>
        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        /// <summary>
        /// Properties
        /// </summary>
        public int WeekSalary { get; set; }
        public int WorkHoursPerDay { get; set; }

        /// <summary>
        /// Calculates money that worker makes per hour
        /// </summary>
        /// <returns>the value</returns>
        public double MoneyPerHour()
        {
            double moneyPerHour = this.WeekSalary / WorkHoursPerDay;

            return moneyPerHour;
        }
    }
}
