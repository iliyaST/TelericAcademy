namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PhonebookRepository : IPhonebookRepository
    {
        private List<Entry> Entries = new List<Entry>();

        public bool AddPhone(string entryname, IEnumerable<string> phones)
        {
            var entryFound = this.Entries.Find(x => x.EntryName.ToLowerInvariant() == entryname.ToLowerInvariant());

            bool flag;
            if (entryFound == null)
            {
                var newEntry = new Entry(entryname);

                foreach (var num in phones)
                {
                    newEntry.Phones.Add(num);
                }

                this.Entries.Add(newEntry);

                flag = true;
            }
            else
            {
                foreach (var number in phones)
                {
                    entryFound.Phones.Add(number);
                }

                flag = false;
            }

            return flag;
        }

        public int ChangePhone(string oldNumber, string newNumber)
        {
            var allEntriesThatContainTheOldNumber = this.Entries.FindAll(x => x.Phones.Contains(oldNumber));

            int numbersFound = 0;
            foreach (var entry in allEntriesThatContainTheOldNumber)
            {
                entry.Phones.Remove(oldNumber);
                entry.Phones.Add(newNumber);
                numbersFound++;
            }

            return numbersFound;
        }

        public Entry[] ListEntries(int start, int count)
        {
            if (start < 0 || start + count > this.Entries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.Entries.Sort();
            var requiredEntries = new Entry[count];

            for (int i = start; i <= start + count - 1; i++)
            {
                var currentEntry = this.Entries[i];
                requiredEntries[i - start] = currentEntry;
            }

            return requiredEntries;
        }
    }
}
