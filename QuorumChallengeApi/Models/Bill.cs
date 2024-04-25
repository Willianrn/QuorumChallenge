namespace QuorumChallengeApi.Models
{
    public class Bill : BaseModel
    {
        public string Title { get; set; }
        public int PrimarySponsor { get; set; }

        public static Bill FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Bill bill = new Bill();
            bill.Id = Convert.ToInt32(values[0]);
            bill.Title = values[1];
            bill.PrimarySponsor = Convert.ToInt32(values[2]);
            return bill;
        }
    }

    public class BillApiModel : Bill
    {
        public int Supporters { get; set; }
        public int Opposers { get; set; }
        public string PrimarySponsorLegislator { get;set; }
    }
}
