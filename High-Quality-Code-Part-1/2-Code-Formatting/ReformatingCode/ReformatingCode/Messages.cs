namespace ReformatingCode
{
    public static class Messages
    {
        public static void EventAdded()
        {
            Program.Output.Append("Event added\n");
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                Program.Output.AppendFormat("{0} events deleted\n", x);
            }
        }

        public static void NoEventsFound()
        {
            Program.Output.Append("No events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Program.Output.Append(eventToPrint + "\n");
            }
        }
    }
}
