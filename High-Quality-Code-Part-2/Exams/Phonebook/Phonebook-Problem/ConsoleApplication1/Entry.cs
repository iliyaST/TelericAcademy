namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Entry : IComparable<Entry>
    {
        public Entry(string entryname)
        {
            this.EntryName = entryname;
            this.Phones = new SortedSet<string>();
        }

        public string EntryName { get; set; }

        public SortedSet<string> Phones { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var phones = String.Join(", ", this.Phones);

            sb.Append('[' + this.EntryName + ": " + phones +"]");

            return sb.ToString();
        }

        public int CompareTo(Entry other)
        {
            return this.EntryName.CompareTo(other.EntryName);
        }
    }
}
