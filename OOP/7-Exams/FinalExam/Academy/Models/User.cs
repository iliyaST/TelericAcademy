using Academy.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public abstract class User : IUser
    {
        private string username;

        public User(string username)
        {
            this.Username = username;
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                Validator.NullOrEmpty(value, String.Format(Constants.StringCannotBeNullOrEmpty,
                    nameof(Username)));

                Validator.StringBetweenNumbers(value, Constants.MinTrainerNameLength,
                    Constants.MaxTrainerNameLength, Constants.UserNameLenghtMustBeBetweenMinAndMax);

                this.username = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(String.Format(" - Username: {0}", this.Username));

            return sb.ToString();
        }
    }
}
