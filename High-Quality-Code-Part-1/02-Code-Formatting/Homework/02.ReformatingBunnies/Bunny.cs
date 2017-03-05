﻿namespace ReformatingBunnies
{
    using System;
    using System.Text;
    using ReformatingBunnies.Common;
    using ReformatingBunnies.Contracts;

    [Serializable]
    public class Bunny
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public FurType FurType { get; set; }

        public void Introduce(IWriter writer)
        {
            writer.WriteLine(string.Format("{0} - \"I am {1} years old!\"", this.Name, this.Age));
            writer.WriteLine(string.Format("{0} - \"And I am {1}", this.Name, this.FurType.ToString().SplitToSeparateWordsByUppercaseLetter()));
        }

        public override string ToString()
        {
            var builderSize = 200;
            var builder = new StringBuilder(builderSize);
            builder.AppendLine($"Bunny name: {this.Name}");
            builder.AppendLine($"Bunny age: {this.Age}");
            builder.AppendLine($"Bunny fur: {this.FurType.ToString().SplitToSeparateWordsByUppercaseLetter()}");

            return builder.ToString();
        }
    }
}
