using System.Collections.Generic;

namespace CarsFactory
{
    public class XmlQuery
    {
        public string Order { get; set; }

        public string OutputFile { get; set; }

        public IList<XmlWhereClause> WhereClauses { get; set; } = new List<XmlWhereClause>();
    }
}
