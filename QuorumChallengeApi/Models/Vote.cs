using System.ComponentModel.DataAnnotations;

namespace QuorumChallengeApi.Models
{
    public class Vote : BaseModel
    {
        public int BillId { get; set; }

        public static Vote FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Vote vote = new Vote();
            vote.Id = Convert.ToInt32(values[0]);
            vote.BillId = Convert.ToInt32(values[1]);
            return vote;
        }
    }

    public class VoteApiModel : Vote
    {
        public List<VoteResult> Results { get; set; }
    }

    public class VoteResult : BaseModel
    {
        public int LegislatorId { get; set; }
        public int VoteId { get; set; }

        [AllowedValues(1,2)]
        public int VoteType { get; set; }

        public static VoteResult FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            VoteResult voteResult = new VoteResult();
            voteResult.Id = Convert.ToInt32(values[0]);
            voteResult.LegislatorId = Convert.ToInt32(values[1]);
            voteResult.VoteId = Convert.ToInt32(values[2]);
            voteResult.VoteType = Convert.ToInt32(values[3]);
            return voteResult;
        }
    }
}
