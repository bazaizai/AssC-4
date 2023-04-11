using Ass.Models;

namespace Ass.IServices
{
    public interface ITeamServices
    {
        public bool CreateTeam(Team i);
        public bool UpdateTeam(Team i);
        public bool DeleteTeam(Guid id);
        public List<Team> GetAllTeams();
        public Team GetTeamById(Guid id);
    }
}
