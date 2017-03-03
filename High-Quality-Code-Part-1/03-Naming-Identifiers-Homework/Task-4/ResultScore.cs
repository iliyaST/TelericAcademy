namespace NamingIdentifiers
{
    public class ResultScore
    {
        public ResultScore()
        {
        }

        public ResultScore(string name, int scorePoints)
        {
            this.Name = name;
            this.ScorePoints = scorePoints;
        }

        public string Name { get; set; }

        public int ScorePoints { get; set; }       
    }
}
