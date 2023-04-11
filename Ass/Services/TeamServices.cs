using Ass.IServices;
using Ass.Models;

namespace Ass.Services
{
    public class TeamServices : ITeamServices
    {
        AssDBContext dbContext;
        public TeamServices()
        {
            dbContext = new AssDBContext();
        }

        public bool CreateTeam(Team i)
        {
            try
            {
                dbContext.Teams.Add(i);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteTeam(Guid id)
        {
            try
            {
                var product = dbContext.Teams.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    dbContext.Teams.Remove(product);
                    dbContext.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Team> GetAllTeams()
        {
            return dbContext.Teams.ToList();
        }

        public Team GetTeamById(Guid id)
        {
            return dbContext.Teams.FirstOrDefault(c => c.Id == id);
        }

        public bool UpdateTeam(Team i)
        {
            try
            {
                var x = dbContext.Teams.FirstOrDefault(p => p.Id == i.Id);
                x.Ten = i.Ten;
                x.TrangThai = i.TrangThai;
                dbContext.Teams.Update(x);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
