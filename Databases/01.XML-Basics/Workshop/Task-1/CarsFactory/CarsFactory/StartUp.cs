 namespace CarsFactory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Xml;

    public class StartUp
    {
        public static void Main()
        {
            var inputPath = @"C:\Users\Yanakieva\Desktop\Telerik\Databases\Workshop\Task-1";
            var xmlPath = @"C:\Users\Yanakieva\Desktop\Telerik\Databases\Workshop\Task-1\queries.xml";

            foreach (string file in Directory.EnumerateFiles(inputPath, "*.json"))
            {
                string carsJson = File.ReadAllText(file);

                IEnumerable<CarJsonModel> carJsonModels = JsonConvert.DeserializeObject<IEnumerable<CarJsonModel>>(carsJson);

                var jsonModels = carJsonModels as CarJsonModel[] ?? carJsonModels.ToArray();
                IEnumerable<Car> cars = jsonModels.Select(CarJsonModel.FromJsonModel);

                var carsNew = jsonModels.Select(x => new
                {
                    Dealer = x.Dealer
                });

                IList<XmlQuery> queries = new List<XmlQuery>();

                using (var reader = XmlReader.Create(xmlPath))
                {
                    while (reader.Read())
                    {
                        if (reader.Name == "Query" && reader.IsStartElement())
                        {
                            var xmlQuery = new XmlQuery();

                            reader.Read();

                            while (reader.Read() && reader.Name != "Query")
                            {
                                if (reader.Name == "OrderBy" && reader.IsStartElement())
                                {
                                    xmlQuery.Order = reader.ReadInnerXml();
                                }

                                if (reader.Name == "WhereClauses" && reader.IsStartElement())
                                {
                                    reader.Read();

                                    while (true)
                                    {
                                        reader.Read();

                                        if (reader.Name == "WhereClauses")
                                        {
                                            break;
                                        }

                                        if (reader.Name == "WhereClause" && reader.IsStartElement())
                                        {
                                            var xmlClauese = new XmlWhereClause();
                                            xmlClauese.PropertyName = reader.GetAttribute("PropertyName");
                                            xmlClauese.Type = reader.GetAttribute("Type");
                                            xmlQuery.WhereClauses.Add(xmlClauese);
                                        }
                                    }
                                }
                            }
                            queries.Add(xmlQuery);
                        }
                    }
                }

                var counter = 0;

                foreach (var xmlQuery in queries)
                {
                    counter++;

                    var outputPathUrl = String.Format("C:\\Users\\Yanakieva\\Desktop\\Telerik\\Databases\\Workshop\\Task-1\\xmlResult{0}.xml", counter);

                    var clauses = new HashSet<string>();

                    foreach (var xmlQueryWhereClause in xmlQuery.WhereClauses)
                    {
                        clauses.Add(xmlQueryWhereClause.PropertyName);
                        clauses.Add(xmlQueryWhereClause.Type);
                    }                   

                    using (var writter = XmlWriter.Create(outputPathUrl))
                    {
                        
                    }
                }
            }
        }
    }
}
