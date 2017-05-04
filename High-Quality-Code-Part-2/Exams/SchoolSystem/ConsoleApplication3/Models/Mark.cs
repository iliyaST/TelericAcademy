namespace School.Models
{
    using School.Models.Common;

    public class Mark
    {
        private float value;

        public Mark(string sbject, float value)
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
                Validator.NumberValue(value, Constants.MinMarksValue, Constants.MaxMarksValue, Constants.MarksValueShouldBeBetweenMinAndMax);

                this.value = value;
            }
        }

        public string Subject { get; set; }
    }
}
