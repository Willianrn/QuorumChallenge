using QuorumChallengeApi.Models;

namespace QuorumChallengeApi.Services
{
    public class LegislatorService
    {
        public List<LegislatorApiModel> GetLegislators()
        {
            var voteService = new VoteService();
            List<VoteResult> results = voteService.VoteResultList();

            List<LegislatorApiModel> legislators = LegislatorList()
                .Select(l => new LegislatorApiModel()
                {
                    Id = l.Id,
                    Name = l.Name,
                    SupportedBills = results.Count(c => c.LegislatorId == l.Id && c.VoteType == 1),
                    OpposedBills = results.Count(c => c.LegislatorId == l.Id && c.VoteType == 2)
                }).ToList();

            return legislators;
        }

        public List<Legislator> LegislatorList()
        {
            return System.IO.File.ReadAllLines("Data\\legislators_(2).csv")
                .Skip(1)
                .Select(v => Legislator.FromCsv(v))
                .ToList();
        }
    }
}
