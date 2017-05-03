namespace SchoolSystem.CLI.Models
{
    using Enums;
    using SchoolSystem.CLI.Models.Contracts;

    public class Mark : IMark
    {
        // TODO: IMPLEMENT VALIDATIONS
        private float value;
        private Subject subject;

        public Mark(Subject sbject, float value)
        {
            this.Subject = sbject;
            this.Value = value;
        }

        public float Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public Subject Subject
        {
            get
            {
                return this.subject;
            }

            set
            {
                this.subject = value;
            }
        }
    }
}
