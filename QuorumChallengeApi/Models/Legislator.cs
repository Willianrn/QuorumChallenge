namespace QuorumChallengeApi.Models
{
    public class Legislator : BaseModel
    {
        public string Name { get; set; }
        public static Legislator FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Legislator legislator = new Legislator();
            legislator.Id = Convert.ToInt32(values[0]);
            legislator.Name = values[1];
            return legislator;
        }
    }

    public class  LegislatorApiModel : Legislator
    {
        public int SupportedBills { get; set; }
        public int OpposedBills { get; set; }
    }
}
