using QuorumChallengeApi.Models;

namespace QuorumChallengeApi.Services
{
    public class BillService
    {
        public List<BillApiModel> GetBills()
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

            List<Legislator> legislators = new LegislatorService().LegislatorList();

            List<BillApiModel> bills = System.IO.File.ReadAllLines("Data\\bills_(2).csv")
                .Skip(1)
                                             .Select(v => Bill.FromCsv(v))
                                             .ToList()
                                             .Select(b => new BillApiModel()
                                             {
                                                  Id = b.Id,
                                                  Title = b.Title,
                                                  PrimarySponsor = b.PrimarySponsor,
                                                  Supporters = votes.Count(v => v.BillId == b.Id && v.Results.Any(r => r.VoteType == 1)),
                                                  Opposers = votes.Count(v => v.BillId == b.Id && v.Results.Any(r => r.VoteType == 2)),
                                                  PrimarySponsorLegislator = legislators.FirstOrDefault(l => l.Id == b.PrimarySponsor)?.Name ?? "Unknown"
                                             }).ToList();

            return bills;
        }
    }
}
