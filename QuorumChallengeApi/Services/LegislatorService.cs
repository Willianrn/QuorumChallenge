using QuorumChallengeApi.Models;

namespace QuorumChallengeApi.Services
{
    public class LegislatorService
    {
        public List<LegislatorApiModel> GetLegislators()
        {
            var voteService = new VoteService();
            List<VoteResult> results = voteService.VoteResultList();

            List<VoteApiModel> votes = voteService.VoteList()
                                           .Select(v => new VoteApiModel()
                                           {
                                               Id = v.Id,
                                               BillId = v.BillId,
                                               Results = results.Where(r => r.VoteId == v.Id).ToList()
                                           }).ToList();

            List<LegislatorApiModel> legislators = LegislatorList()
                .Select(l => new LegislatorApiModel()
                {
                    Id = l.Id,
                    Name = l.Name,
                    SupportedBills = votes.Count(v => v.Results.Any(r => r.LegislatorId == l.Id && r.VoteType == 1)),
                    OpposedBills = votes.Count(v => v.Results.Any(r => r.LegislatorId == l.Id && r.VoteType == 2))
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
