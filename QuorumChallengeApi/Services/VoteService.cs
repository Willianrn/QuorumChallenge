using QuorumChallengeApi.Models;

namespace QuorumChallengeApi.Services
{
    public class VoteService
    {
        public List<Vote> VoteList()
        {
            return System.IO.File.ReadAllLines("Data\\votes_(2).csv")
                .Skip(1)
                .Select(v => Vote.FromCsv(v))
                .ToList();
        }

        public List<VoteResult> VoteResultList()
        {
            return System.IO.File.ReadAllLines("Data\\vote_results_(2).csv")
                .Skip(1)
                .Select(v => VoteResult.FromCsv(v))
                .ToList();
        }
    }
}
